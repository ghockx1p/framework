﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Signum.Utilities;

namespace Signum.Engine.Linq
{
    class UpdateDeleteSimplifier: DbExpressionVisitor
    {
        bool removeSelectRowCount;

        public static CommandExpression Simplify(CommandExpression ce, bool removeSelectRowCount)
        {
            return (CommandExpression)new UpdateDeleteSimplifier { removeSelectRowCount = removeSelectRowCount }.Visit(ce);
        }

        protected override Expression VisitSelectRowCount(SelectRowCountExpression src)
        {
            if (removeSelectRowCount)
                return null;

            return base.VisitSelectRowCount(src);
        }

        protected override Expression VisitDelete(DeleteExpression delete)
        {
            var select = delete.Source as SelectExpression;

            TableExpression table = select.From as TableExpression;

            if (table == null || delete.Table.Name != table.Name)
                return delete;

            if (TrivialWhere(delete, select))
                return delete;

            return new DeleteExpression(delete.Table, select.From, select.Where);
        }

        private bool TrivialWhere(DeleteExpression delete, SelectExpression select)
        {
            if (delete.Where == null || delete.Where.NodeType == ExpressionType.Equal)
                return false;

            var b = (BinaryExpression)delete.Where;

            var ce1 = b.Left as ColumnExpression;
            var ce2 = b.Right as ColumnExpression;

            if (ce1 == null || ce2 == null)
                return false;

            ce1 = ResolveColumn(ce1, select);
            ce2 = ResolveColumn(ce2, select);

            return ce1.Equals(ce2); 
        }

        private ColumnExpression ResolveColumn(ColumnExpression ce, SelectExpression select)
        {
            if (ce.Alias == select.Alias)
            {
                var cd = select.Columns.SingleEx(a => a.Name == ce.Name);

                var result = cd.Expression as ColumnExpression;

                if(result == null)
                    return ce;

                TableExpression table = (TableExpression)select.From;

                if (table.Alias == result.Alias)
                {
                    return new ColumnExpression(result.Type, Alias.Raw(table.Name), result.Name);
                }

                return result;
            }

            return ce;
        }
    }
}