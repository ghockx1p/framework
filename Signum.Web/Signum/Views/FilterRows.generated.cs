﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
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
    
    #line 3 "..\..\Signum\Views\FilterRows.cshtml"
    using Signum.Engine.DynamicQuery;
    
    #line default
    #line hidden
    using Signum.Entities;
    
    #line 1 "..\..\Signum\Views\FilterRows.cshtml"
    using Signum.Entities.DynamicQuery;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Signum\Views\FilterRows.cshtml"
    using Signum.Entities.Reflection;
    
    #line default
    #line hidden
    using Signum.Utilities;
    using Signum.Web;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Signum/Views/FilterRows.cshtml")]
    public partial class _Signum_Views_FilterRows_cshtml : System.Web.Mvc.WebViewPage<Context>
    {
        public _Signum_Views_FilterRows_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 6 "..\..\Signum\Views\FilterRows.cshtml"
  
    var filterOptions = (List<FilterOption>)ViewData[ViewDataKeys.FilterOptions];

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 10 "..\..\Signum\Views\FilterRows.cshtml"
 for (int i = 0; i < filterOptions.Count; i++)
{
    FilterOption filter = filterOptions[i];
    
            
            #line default
            #line hidden
            
            #line 13 "..\..\Signum\Views\FilterRows.cshtml"
Write(Html.NewFilter(filter, Model, i));

            
            #line default
            #line hidden
            
            #line 13 "..\..\Signum\Views\FilterRows.cshtml"
                                     
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
