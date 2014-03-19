﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Signum.Web.Views
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 3 "..\..\Signum\Views\SearchResults.cshtml"
    using Signum.Engine;
    
    #line default
    #line hidden
    using Signum.Entities;
    
    #line 1 "..\..\Signum\Views\SearchResults.cshtml"
    using Signum.Entities.DynamicQuery;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Signum\Views\SearchResults.cshtml"
    using Signum.Entities.Reflection;
    
    #line default
    #line hidden
    using Signum.Utilities;
    using Signum.Web;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Signum/Views/SearchResults.cshtml")]
    public partial class SearchResults : System.Web.Mvc.WebViewPage<Context>
    {
        public SearchResults()
        {
        }
        public override void Execute()
        {
            
            #line 6 "..\..\Signum\Views\SearchResults.cshtml"
   
   QueryDescription queryDescription = (QueryDescription)ViewData[ViewDataKeys.QueryDescription];
   var entityColumn = queryDescription.Columns.SingleEx(a => a.IsEntity);
   Implementations implementations = entityColumn.Implementations.Value;
   bool navigable = (bool)ViewData[ViewDataKeys.Navigate] && (implementations.IsByAll ? true : implementations.Types.Any(t => Navigator.IsNavigable(t, null, isSearchEntity: true)));
   bool allowSelection = (bool)ViewData[ViewDataKeys.AllowSelection];
   
   ResultTable queryResult = (ResultTable)ViewData[ViewDataKeys.Results];
   Dictionary<int, CellFormatter> formatters = (Dictionary<int, CellFormatter>)ViewData[ViewDataKeys.Formatters];

   int columnsCount = queryResult.Columns.Count() + (navigable ? 1 : 0) + (allowSelection ? 1 : 0);

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 19 "..\..\Signum\Views\SearchResults.cshtml"
 if (ViewData.ContainsKey(ViewDataKeys.MultipliedMessage))
{ 

            
            #line default
            #line hidden
WriteLiteral("    <tr");

WriteLiteral(" class=\"sf-tr-multiply\"");

WriteLiteral(">\r\n        <td");

WriteLiteral(" class=\"sf-td-multiply alert alert-warning\"");

WriteAttribute("colspan", Tuple.Create(" colspan=\"", 1073), Tuple.Create("\"", 1096)
            
            #line 22 "..\..\Signum\Views\SearchResults.cshtml"
, Tuple.Create(Tuple.Create("", 1083), Tuple.Create<System.Object, System.Int32>(columnsCount
            
            #line default
            #line hidden
, 1083), false)
);

WriteLiteral(">\r\n            <span");

WriteLiteral(" class=\"glyphicon glyphicon-exclamation-sign\"");

WriteLiteral("></span>\r\n");

WriteLiteral("            ");

            
            #line 24 "..\..\Signum\Views\SearchResults.cshtml"
       Write(ViewData[ViewDataKeys.MultipliedMessage]);

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n    </tr>\r\n");

            
            #line 27 "..\..\Signum\Views\SearchResults.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 29 "..\..\Signum\Views\SearchResults.cshtml"
 foreach (var row in queryResult.Rows)
{
    Lite<IIdentifiable> entityField = row.Entity;

            
            #line default
            #line hidden
WriteLiteral("    <tr");

WriteLiteral(" data-entity=\"");

            
            #line 32 "..\..\Signum\Views\SearchResults.cshtml"
                Write(entityField.Key());

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n");

            
            #line 33 "..\..\Signum\Views\SearchResults.cshtml"
        
            
            #line default
            #line hidden
            
            #line 33 "..\..\Signum\Views\SearchResults.cshtml"
         if (allowSelection)
        {

            
            #line default
            #line hidden
WriteLiteral("            <td>\r\n");

WriteLiteral("                ");

            
            #line 36 "..\..\Signum\Views\SearchResults.cshtml"
           Write(Html.CheckBox(
                    Model.Compose("rowSelection", row.Index.ToString()),
                        new 
                        {
                            @class = "sf-td-selection", 
                            value = entityField.Id.ToString() + "__" + Navigator.ResolveWebTypeName(entityField.EntityType) + "__" + entityField.ToString() 
                        }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </td>\r\n");

            
            #line 44 "..\..\Signum\Views\SearchResults.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        ");

            
            #line 45 "..\..\Signum\Views\SearchResults.cshtml"
         if (navigable)
        {

            
            #line default
            #line hidden
WriteLiteral("            <td>\r\n");

WriteLiteral("                ");

            
            #line 48 "..\..\Signum\Views\SearchResults.cshtml"
           Write(QuerySettings.EntityFormatRules.Last(fr => fr.IsApplyable(entityField)).Formatter(Html, entityField));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </td>\r\n");

            
            #line 50 "..\..\Signum\Views\SearchResults.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        ");

            
            #line 51 "..\..\Signum\Views\SearchResults.cshtml"
         foreach (var col in queryResult.Columns)
        {
            var value = row[col];
            var ft = formatters[col.Index];
            

            
            #line default
            #line hidden
WriteLiteral("            <td ");

            
            #line 56 "..\..\Signum\Views\SearchResults.cshtml"
           Write(ft.WriteDataAttribute(value));

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 57 "..\..\Signum\Views\SearchResults.cshtml"
           Write(ft.Formatter(Html, value));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </td>\r\n");

            
            #line 59 "..\..\Signum\Views\SearchResults.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </tr>\r\n");

            
            #line 61 "..\..\Signum\Views\SearchResults.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 63 "..\..\Signum\Views\SearchResults.cshtml"
 if (queryResult.Rows.IsNullOrEmpty())
{

            
            #line default
            #line hidden
WriteLiteral("    <tr>\r\n        <td");

WriteAttribute("colspan", Tuple.Create(" colspan=\"", 2453), Tuple.Create("\"", 2476)
            
            #line 66 "..\..\Signum\Views\SearchResults.cshtml"
, Tuple.Create(Tuple.Create("", 2463), Tuple.Create<System.Object, System.Int32>(columnsCount
            
            #line default
            #line hidden
, 2463), false)
);

WriteLiteral(">");

            
            #line 66 "..\..\Signum\Views\SearchResults.cshtml"
                               Write(SearchMessage.NoResultsFound.NiceToString());

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n    </tr>\r\n");

            
            #line 68 "..\..\Signum\Views\SearchResults.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 70 "..\..\Signum\Views\SearchResults.cshtml"
   
    ViewData[ViewDataKeys.Pagination] = queryResult.Pagination;
    ViewData[ViewDataKeys.SearchControlColumnsCount] = columnsCount;

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 74 "..\..\Signum\Views\SearchResults.cshtml"
Write(Html.Partial(Navigator.Manager.PaginationSelectorView, Model));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591
