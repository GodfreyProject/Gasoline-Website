#pragma checksum "C:\Users\vera2\source\repos\Gasoline@BV_Website\Gasoline@BV_Website\Pages\Supplier_Section.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3690e724dc210dd572bc931880c4212029087b70"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Gasoline_BV_Website.Pages.Pages_Supplier_Section), @"mvc.1.0.razor-page", @"/Pages/Supplier_Section.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3690e724dc210dd572bc931880c4212029087b70", @"/Pages/Supplier_Section.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"915b5fe930275e31cac2496caa92747b15f011de", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Supplier_Section : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\vera2\source\repos\Gasoline@BV_Website\Gasoline@BV_Website\Pages\Supplier_Section.cshtml"
  
    Layout = "Supplier_Layout";
    ViewData["Title"] = "Supplier_Sectioin";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h4>Welcome to Your Page:");
#nullable restore
#line 9 "C:\Users\vera2\source\repos\Gasoline@BV_Website\Gasoline@BV_Website\Pages\Supplier_Section.cshtml"
                    Write(Model.supplier.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Gasoline_BV_Website.Pages.Supplier_SectionModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Gasoline_BV_Website.Pages.Supplier_SectionModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Gasoline_BV_Website.Pages.Supplier_SectionModel>)PageContext?.ViewData;
        public Gasoline_BV_Website.Pages.Supplier_SectionModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591