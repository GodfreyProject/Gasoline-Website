#pragma checksum "C:\Users\vera2\source\repos\Gasoline@BV_Website\Gasoline@BV_Website\Pages\AdminHome.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f279e86e9c4819845b94802f2ee6e83059f8946"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Gasoline_BV_Website.Pages.Pages_AdminHome), @"mvc.1.0.razor-page", @"/Pages/AdminHome.cshtml")]
namespace Gasoline_BV_Website.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\vera2\source\repos\Gasoline@BV_Website\Gasoline@BV_Website\Pages\_ViewImports.cshtml"
using Gasoline_BV_Website;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f279e86e9c4819845b94802f2ee6e83059f8946", @"/Pages/AdminHome.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"915b5fe930275e31cac2496caa92747b15f011de", @"/Pages/_ViewImports.cshtml")]
    public class Pages_AdminHome : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\vera2\source\repos\Gasoline@BV_Website\Gasoline@BV_Website\Pages\AdminHome.cshtml"
  
    Layout = "Admin_Layout";
    ViewData["Title"] = "AdminHome";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Welcome to Admin Section</h1>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Gasoline_BV_Website.Pages.AdminHomeModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Gasoline_BV_Website.Pages.AdminHomeModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Gasoline_BV_Website.Pages.AdminHomeModel>)PageContext?.ViewData;
        public Gasoline_BV_Website.Pages.AdminHomeModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
