#pragma checksum "/Users/gunelyusubova/Desktop/FrontToBack/Areas/AdminArea/Views/Role/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c612ee7aabb99643adc46b68f41856ee822661c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(FrontToBack.Areas.Admin.Views.Role.Areas_AdminArea_Views_Role_Index), @"mvc.1.0.view", @"/Areas/AdminArea/Views/Role/Index.cshtml")]
namespace FrontToBack.Areas.Admin.Views.Role
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
#line 2 "/Users/gunelyusubova/Desktop/FrontToBack/Areas/AdminArea/Views/_ViewImports.cshtml"
using FrontToBack.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/gunelyusubova/Desktop/FrontToBack/Areas/AdminArea/Views/_ViewImports.cshtml"
using FrontToBack.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/gunelyusubova/Desktop/FrontToBack/Areas/AdminArea/Views/_ViewImports.cshtml"
using FronToBack.Areas.AdminArea.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "/Users/gunelyusubova/Desktop/FrontToBack/Areas/AdminArea/Views/Role/Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c612ee7aabb99643adc46b68f41856ee822661c1", @"/Areas/AdminArea/Views/Role/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"815562b8f7cf1ec577ed9a1b499897bf90a54bc9", @"/Areas/AdminArea/Views/_ViewImports.cshtml")]
    public class Areas_AdminArea_Views_Role_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<IdentityRole>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n\n");
#nullable restore
#line 5 "/Users/gunelyusubova/Desktop/FrontToBack/Areas/AdminArea/Views/Role/Index.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>");
#nullable restore
#line 7 "/Users/gunelyusubova/Desktop/FrontToBack/Areas/AdminArea/Views/Role/Index.cshtml"
  Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n");
#nullable restore
#line 8 "/Users/gunelyusubova/Desktop/FrontToBack/Areas/AdminArea/Views/Role/Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<IdentityRole>> Html { get; private set; }
    }
}
#pragma warning restore 1591
