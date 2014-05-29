﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Signum.Web.Views
{
    using System;
    using System.Collections.Generic;
    
    #line 3 "..\..\Signum\Views\SearchControl.cshtml"
    using System.Configuration;
    
    #line default
    #line hidden
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
    
    #line 2 "..\..\Signum\Views\SearchControl.cshtml"
    using Signum.Engine.DynamicQuery;
    
    #line default
    #line hidden
    using Signum.Entities;
    
    #line 1 "..\..\Signum\Views\SearchControl.cshtml"
    using Signum.Entities.DynamicQuery;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Signum\Views\SearchControl.cshtml"
    using Signum.Entities.Reflection;
    
    #line default
    #line hidden
    using Signum.Utilities;
    using Signum.Web;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Signum/Views/SearchControl.cshtml")]
    public partial class SearchControl : System.Web.Mvc.WebViewPage<Context>
    {
        public SearchControl()
        {
        }
        public override void Execute()
        {
            
            #line 6 "..\..\Signum\Views\SearchControl.cshtml"
   
    Model.ReadOnly = false; /*SearchControls Context should never inherit Readonly property of parent context */
    FindOptions findOptions = (FindOptions)ViewData[ViewDataKeys.FindOptions];
    QueryDescription queryDescription = (QueryDescription)ViewData[ViewDataKeys.QueryDescription];
    var entityColumn = queryDescription.Columns.SingleEx(a => a.IsEntity);
    Type entitiesType = Lite.Extract(entityColumn.Type);
    Implementations implementations = entityColumn.Implementations.Value;
    findOptions.Pagination = findOptions.Pagination ?? (Navigator.Manager.QuerySettings.GetOrThrow(findOptions.QueryName, "Missing QuerySettings for QueryName {0}").Pagination) ?? FindOptions.DefaultPagination;

    ViewData[ViewDataKeys.FindOptions] = findOptions;

    var prefix = Model.Compose("sfSearchControl");

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteAttribute("id", Tuple.Create(" id=\"", 990), Tuple.Create("\"", 1002)
            
            #line 19 "..\..\Signum\Views\SearchControl.cshtml"
, Tuple.Create(Tuple.Create("", 995), Tuple.Create<System.Object, System.Int32>(prefix
            
            #line default
            #line hidden
, 995), false)
);

WriteLiteral(" \r\n     class=\"sf-search-control SF-control-container\"");

WriteLiteral(" \r\n     data-prefix=\"");

            
            #line 21 "..\..\Signum\Views\SearchControl.cshtml"
             Write(Model.Prefix);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(" \r\n     data-find-url=\"");

            
            #line 22 "..\..\Signum\Views\SearchControl.cshtml"
               Write(Navigator.FindRoute(findOptions.QueryName));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(" \r\n     data-queryName=\"");

            
            #line 23 "..\..\Signum\Views\SearchControl.cshtml"
                Write(QueryUtils.GetQueryUniqueKey(findOptions.QueryName));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(" \r\n     >\r\n\r\n");

WriteLiteral("    ");

            
            #line 26 "..\..\Signum\Views\SearchControl.cshtml"
Write(Html.Hidden(Model.Compose("sfEntityTypeNames"),
                                implementations.IsByAll ? EntityBase.ImplementedByAllKey :
                                implementations.Types.ToString(t => Navigator.ResolveWebTypeName(t), ","), new { disabled = "disabled" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 29 "..\..\Signum\Views\SearchControl.cshtml"
Write(Html.Hidden(Model.Compose("sfEntityTypeNiceNames"),
                                implementations.IsByAll ? EntityBase.ImplementedByAllKey :
                                implementations.Types.ToString(t => t.NiceName(), ","), new { disabled = "disabled" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\r\n");

            
            #line 34 "..\..\Signum\Views\SearchControl.cshtml"
    
            
            #line default
            #line hidden
            
            #line 34 "..\..\Signum\Views\SearchControl.cshtml"
      
        bool filtersAlwaysHidden = !findOptions.ShowHeader || !findOptions.ShowFilters && !findOptions.ShowFilterButton;
    
            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    <div");

WriteAttribute("style", Tuple.Create(" style=\"", 1955), Tuple.Create("\"", 2012)
, Tuple.Create(Tuple.Create("", 1963), Tuple.Create("display:", 1963), true)
            
            #line 38 "..\..\Signum\Views\SearchControl.cshtml"
, Tuple.Create(Tuple.Create("", 1971), Tuple.Create<System.Object, System.Int32>(filtersAlwaysHidden ? "none" : "block"
            
            #line default
            #line hidden
, 1971), false)
);

WriteLiteral(">\r\n");

            
            #line 39 "..\..\Signum\Views\SearchControl.cshtml"
        
            
            #line default
            #line hidden
            
            #line 39 "..\..\Signum\Views\SearchControl.cshtml"
          
            ViewData[ViewDataKeys.FilterOptions] = findOptions.FilterOptions;
            ViewData[ViewDataKeys.FiltersVisible] = findOptions.ShowFilters;
            ViewData[ViewDataKeys.ShowAddColumn] = string.IsNullOrEmpty(Model.Prefix) && findOptions.AllowChangeColumns;
            Html.RenderPartial(Navigator.Manager.FilterBuilderView); 
        
            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n\r\n\r\n\r\n\r\n    <div");

WriteLiteral(" class=\"sf-query-button-bar\"");

WriteAttribute("style", Tuple.Create(" style=\"", 2445), Tuple.Create("\"", 2502)
            
            #line 50 "..\..\Signum\Views\SearchControl.cshtml"
, Tuple.Create(Tuple.Create("", 2453), Tuple.Create<System.Object, System.Int32>(findOptions.ShowHeader ? null : "display:none"
            
            #line default
            #line hidden
, 2453), false)
);

WriteLiteral(">\r\n");

            
            #line 51 "..\..\Signum\Views\SearchControl.cshtml"
        
            
            #line default
            #line hidden
            
            #line 51 "..\..\Signum\Views\SearchControl.cshtml"
         if (!filtersAlwaysHidden)
        {

            
            #line default
            #line hidden
WriteLiteral("            <a");

WriteAttribute("class", Tuple.Create("  class=\"", 2567), Tuple.Create("\"", 2668)
, Tuple.Create(Tuple.Create("", 2576), Tuple.Create("sf-query-button", 2576), true)
, Tuple.Create(Tuple.Create(" ", 2591), Tuple.Create("sf-filters-header", 2592), true)
, Tuple.Create(Tuple.Create(" ", 2609), Tuple.Create("btn", 2610), true)
, Tuple.Create(Tuple.Create(" ", 2613), Tuple.Create("btn-default", 2614), true)
            
            #line 53 "..\..\Signum\Views\SearchControl.cshtml"
, Tuple.Create(Tuple.Create(" ", 2625), Tuple.Create<System.Object, System.Int32>(findOptions.ShowFilters ? "active" : ""
            
            #line default
            #line hidden
, 2626), false)
);

WriteAttribute("onclick", Tuple.Create("\r\n            onclick=\"", 2669), Tuple.Create("\"", 2744)
            
            #line 54 "..\..\Signum\Views\SearchControl.cshtml"
, Tuple.Create(Tuple.Create("", 2692), Tuple.Create<System.Object, System.Int32>(JsFunction.SFControlThen(prefix, "toggleFilters()")
            
            #line default
            #line hidden
, 2692), false)
);

WriteAttribute("title", Tuple.Create("\r\n            title=\"", 2745), Tuple.Create("\"", 2886)
            
            #line 55 "..\..\Signum\Views\SearchControl.cshtml"
, Tuple.Create(Tuple.Create("", 2766), Tuple.Create<System.Object, System.Int32>(findOptions.ShowFilters ? JavascriptMessage.hideFilters.NiceToString() : JavascriptMessage.showFilters.NiceToString()
            
            #line default
            #line hidden
, 2766), false)
);

WriteLiteral(">\r\n                <span");

WriteLiteral(" class=\"glyphicon glyphicon glyphicon-filter\"");

WriteLiteral("></span>\r\n            </a>\r\n");

            
            #line 58 "..\..\Signum\Views\SearchControl.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"sf-query-button sf-search btn btn-primary\"");

WriteAttribute("id", Tuple.Create(" id=\"", 3074), Tuple.Create("\"", 3105)
            
            #line 59 "..\..\Signum\Views\SearchControl.cshtml"
    , Tuple.Create(Tuple.Create("", 3079), Tuple.Create<System.Object, System.Int32>(Model.Compose("qbSearch")
            
            #line default
            #line hidden
, 3079), false)
);

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 3106), Tuple.Create("\"", 3161)
            
            #line 59 "..\..\Signum\Views\SearchControl.cshtml"
                                         , Tuple.Create(Tuple.Create("", 3116), Tuple.Create<System.Object, System.Int32>(JsFunction.SFControlThen(prefix, "search()")
            
            #line default
            #line hidden
, 3116), false)
);

WriteLiteral(" >");

            
            #line 59 "..\..\Signum\Views\SearchControl.cshtml"
                                                                                                                                                                    Write(SearchMessage.Search.NiceToString());

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n\r\n");

            
            #line 61 "..\..\Signum\Views\SearchControl.cshtml"
        
            
            #line default
            #line hidden
            
            #line 61 "..\..\Signum\Views\SearchControl.cshtml"
         if (findOptions.Create)
        {

            
            #line default
            #line hidden
WriteLiteral("            <a");

WriteLiteral(" class=\"sf-query-button btn btn-default sf-line-button sf-create\"");

WriteAttribute("id", Tuple.Create(" id=\"", 3337), Tuple.Create("\"", 3374)
            
            #line 63 "..\..\Signum\Views\SearchControl.cshtml"
    , Tuple.Create(Tuple.Create("", 3342), Tuple.Create<System.Object, System.Int32>(Model.Compose("qbSearchCreate")
            
            #line default
            #line hidden
, 3342), false)
);

WriteAttribute("title", Tuple.Create(" title=\"", 3375), Tuple.Create("\"", 3530)
            
            #line 63 "..\..\Signum\Views\SearchControl.cshtml"
                                             , Tuple.Create(Tuple.Create("", 3383), Tuple.Create<System.Object, System.Int32>(SearchMessage.CreateNew0.NiceToString(implementations.IsByAll ? EntityBase.ImplementedByAllKey : implementations.Types.CommaOr(a => a.NiceName()))
            
            #line default
            #line hidden
, 3383), false)
);

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 3531), Tuple.Create("\"", 3592)
            
            #line 63 "..\..\Signum\Views\SearchControl.cshtml"
                                                                                                                                                                                                           , Tuple.Create(Tuple.Create("", 3541), Tuple.Create<System.Object, System.Int32>(JsFunction.SFControlThen(prefix, "create_click()")
            
            #line default
            #line hidden
, 3541), false)
);

WriteLiteral(">\r\n                <span");

WriteLiteral(" class=\"glyphicon glyphicon-plus\"");

WriteLiteral("></span>\r\n            </a>\r\n");

            
            #line 66 "..\..\Signum\Views\SearchControl.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 68 "..\..\Signum\Views\SearchControl.cshtml"
        
            
            #line default
            #line hidden
            
            #line 68 "..\..\Signum\Views\SearchControl.cshtml"
         if (findOptions.ShowContextMenu)
        {


            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n                <button");

WriteLiteral(" class=\"sf-query-button sf-tm-selected btn btn-default dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteAttribute("id", Tuple.Create(" id=\"", 3901), Tuple.Create("\"", 3935)
            
            #line 72 "..\..\Signum\Views\SearchControl.cshtml"
                                          , Tuple.Create(Tuple.Create("", 3906), Tuple.Create<System.Object, System.Int32>(Model.Compose("btnSelected")
            
            #line default
            #line hidden
, 3906), false)
);

WriteLiteral(" disabled=\"disabled\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 73 "..\..\Signum\Views\SearchControl.cshtml"
               Write(JavascriptMessage.Selected);

            
            #line default
            #line hidden
WriteLiteral("\r\n                    (<span");

WriteAttribute("id", Tuple.Create(" id=\"", 4034), Tuple.Create("\"", 4072)
            
            #line 74 "..\..\Signum\Views\SearchControl.cshtml"
, Tuple.Create(Tuple.Create("", 4039), Tuple.Create<System.Object, System.Int32>(Model.Compose("btnSelectedSpan")
            
            #line default
            #line hidden
, 4039), false)
);

WriteLiteral(">0</span>)\r\n                <span");

WriteLiteral(" class=\"caret\"");

WriteLiteral("></span>\r\n                </button>\r\n                <ul");

WriteLiteral(" class=\"dropdown-menu\"");

WriteAttribute("id", Tuple.Create(" id=\"", 4198), Tuple.Create("\"", 4240)
            
            #line 77 "..\..\Signum\Views\SearchControl.cshtml"
, Tuple.Create(Tuple.Create("", 4203), Tuple.Create<System.Object, System.Int32>(Model.Compose("btnSelectedDropDown")
            
            #line default
            #line hidden
, 4203), false)
);

WriteLiteral(">\r\n                    <li>hi there!</li>\r\n                </ul>\r\n            </d" +
"iv>\r\n");

            
            #line 81 "..\..\Signum\Views\SearchControl.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 83 "..\..\Signum\Views\SearchControl.cshtml"
   Write(ButtonBarQueryHelper.GetButtonBarElementsForQuery(new QueryButtonContext
       {
           Url = Url,
           ControllerContext = this.ViewContext,
           QueryName = findOptions.QueryName,
           ManualQueryButtons = (ToolBarButton[])ViewData[ViewDataKeys.ManualToolbarButtons],
           EntityType = entitiesType,
           Prefix = Model.Prefix
       }).ToStringButton(Html));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 93 "..\..\Signum\Views\SearchControl.cshtml"
        
            
            #line default
            #line hidden
            
            #line 93 "..\..\Signum\Views\SearchControl.cshtml"
         if ((bool?)ViewData[ViewDataKeys.AvoidFullScreenButton] != true)
        { 

            
            #line default
            #line hidden
WriteLiteral("             <a");

WriteAttribute("id", Tuple.Create(" id=\"", 4857), Tuple.Create("\"", 4892)
            
            #line 95 "..\..\Signum\Views\SearchControl.cshtml"
, Tuple.Create(Tuple.Create("", 4862), Tuple.Create<System.Object, System.Int32>(Model.Compose("sfFullScreen")
            
            #line default
            #line hidden
, 4862), false)
);

WriteLiteral(" class=\"sf-query-button btn btn-default\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n                <span");

WriteLiteral(" class=\"glyphicon glyphicon-new-window\"");

WriteLiteral("></span>\r\n            </a>\r\n");

            
            #line 98 "..\..\Signum\Views\SearchControl.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n    <div");

WriteAttribute("id", Tuple.Create(" id=\"", 5066), Tuple.Create("\"", 5099)
            
            #line 101 "..\..\Signum\Views\SearchControl.cshtml"
, Tuple.Create(Tuple.Create("", 5071), Tuple.Create<System.Object, System.Int32>(Model.Compose("divResults")
            
            #line default
            #line hidden
, 5071), false)
);

WriteLiteral(" class=\"sf-search-results-container table-responsive\"");

WriteLiteral(">\r\n        <table");

WriteAttribute("id", Tuple.Create(" id=\"", 5170), Tuple.Create("\"", 5203)
            
            #line 102 "..\..\Signum\Views\SearchControl.cshtml"
, Tuple.Create(Tuple.Create("", 5175), Tuple.Create<System.Object, System.Int32>(Model.Compose("tblResults")
            
            #line default
            #line hidden
, 5175), false)
);

WriteLiteral(" class=\"sf-search-results  table table-hover  table-condensed\"");

WriteLiteral(">\r\n            <thead>\r\n                <tr>\r\n");

            
            #line 105 "..\..\Signum\Views\SearchControl.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 105 "..\..\Signum\Views\SearchControl.cshtml"
                     if (findOptions.AllowSelection)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <th");

WriteLiteral(" class=\"sf-th-selection\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 108 "..\..\Signum\Views\SearchControl.cshtml"
                       Write(Html.CheckBox(Model.Compose("cbSelectAll"), false, new { onclick = JsFunction.SFControlThen(prefix, "toggleSelectAll()") }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </th>\r\n");

            
            #line 110 "..\..\Signum\Views\SearchControl.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                    ");

            
            #line 111 "..\..\Signum\Views\SearchControl.cshtml"
                     if (findOptions.Navigate)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <th");

WriteLiteral(" class=\"sf-th-entity\"");

WriteLiteral("></th>\r\n");

            
            #line 114 "..\..\Signum\Views\SearchControl.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                    ");

            
            #line 115 "..\..\Signum\Views\SearchControl.cshtml"
                      List<Column> columns = findOptions.MergeColumns(); 
            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 116 "..\..\Signum\Views\SearchControl.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 116 "..\..\Signum\Views\SearchControl.cshtml"
                     foreach (var col in columns)
                    {
                        var order = findOptions.OrderOptions.FirstOrDefault(oo => oo.Token.FullKey() == col.Name);
                        OrderType? orderType = null;
                        if (order != null)
                        {
                            orderType = order.OrderType;
                        }
                        
            
            #line default
            #line hidden
            
            #line 124 "..\..\Signum\Views\SearchControl.cshtml"
                   Write(SearchControlHelper.Header(col, orderType));

            
            #line default
            #line hidden
            
            #line 124 "..\..\Signum\Views\SearchControl.cshtml"
                                                                   
                    }

            
            #line default
            #line hidden
WriteLiteral("                </tr>\r\n            </thead>\r\n            <tbody>\r\n");

            
            #line 129 "..\..\Signum\Views\SearchControl.cshtml"
                
            
            #line default
            #line hidden
            
            #line 129 "..\..\Signum\Views\SearchControl.cshtml"
                   int columnsCount = columns.Count + (findOptions.Navigate ? 1 : 0) + (findOptions.AllowSelection ? 1 : 0); 
            
            #line default
            #line hidden
WriteLiteral("\r\n                <tr>\r\n                    <td");

WriteAttribute("colspan", Tuple.Create(" colspan=\"", 6608), Tuple.Create("\"", 6631)
            
            #line 131 "..\..\Signum\Views\SearchControl.cshtml"
, Tuple.Create(Tuple.Create("", 6618), Tuple.Create<System.Object, System.Int32>(columnsCount
            
            #line default
            #line hidden
, 6618), false)
);

WriteLiteral(">");

            
            #line 131 "..\..\Signum\Views\SearchControl.cshtml"
                                           Write(JavascriptMessage.searchForResults.NiceToString());

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n    </div>\r" +
"\n\r\n");

            
            #line 137 "..\..\Signum\Views\SearchControl.cshtml"
    
            
            #line default
            #line hidden
            
            #line 137 "..\..\Signum\Views\SearchControl.cshtml"
      
        ViewData[ViewDataKeys.ShowFooter] = findOptions.ShowFooter;
        ViewData[ViewDataKeys.Pagination] = findOptions.Pagination;
        
            
            #line default
            #line hidden
            
            #line 140 "..\..\Signum\Views\SearchControl.cshtml"
   Write(Html.Partial(Navigator.Manager.PaginationSelectorView, Model));

            
            #line default
            #line hidden
            
            #line 140 "..\..\Signum\Views\SearchControl.cshtml"
                                                                      
    
            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n    require([\"Finder\"], function(Finder) { new Finder.SearchControl($(\"#");

            
            #line 144 "..\..\Signum\Views\SearchControl.cshtml"
                                                                   Write(Model.Compose("sfSearchControl"));

            
            #line default
            #line hidden
WriteLiteral("\"), ");

            
            #line 144 "..\..\Signum\Views\SearchControl.cshtml"
                                                                                                         Write(MvcHtmlString.Create(findOptions.ToJS(Model.Prefix).ToString()));

            
            #line default
            #line hidden
WriteLiteral(").ready();});\r\n</script>\r\n");

        }
    }
}
#pragma warning restore 1591
