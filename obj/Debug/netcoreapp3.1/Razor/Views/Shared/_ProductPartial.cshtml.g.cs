#pragma checksum "/Users/gunelyusubova/Desktop/FrontToBack/Views/Shared/_ProductPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e744b544bf058ad8f13ed6161321a8458ae1e535"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(FrontToBack.Views.Shared.Views_Shared__ProductPartial), @"mvc.1.0.view", @"/Views/Shared/_ProductPartial.cshtml")]
namespace FrontToBack.Views.Shared
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
#line 2 "/Users/gunelyusubova/Desktop/FrontToBack/Views/_ViewImports.cshtml"
using FrontToBack.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/gunelyusubova/Desktop/FrontToBack/Views/_ViewImports.cshtml"
using FrontToBack.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e744b544bf058ad8f13ed6161321a8458ae1e535", @"/Views/Shared/_ProductPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9a7ae2cb9cc7b3d5ec6630098c4f646b54e1471", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ProductPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PRODUCTS1>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/gunelyusubova/Desktop/FrontToBack/Views/Shared/_ProductPartial.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div");
            BeginWriteAttribute("class", " class=\"", 69, "\"", 140, 4);
            WriteAttributeValue("", 77, "product-list", 77, 12, true);
#nullable restore
#line 4 "/Users/gunelyusubova/Desktop/FrontToBack/Views/Shared/_ProductPartial.cshtml"
WriteAttributeValue(" ", 89, item.CATEGORY1.Name.ToLower(), 90, 30, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 120, "d-none", 121, 7, true);
            WriteAttributeValue(" ", 127, "same_product", 128, 13, true);
            EndWriteAttribute();
            WriteLiteral(" data-id=\"");
#nullable restore
#line 4 "/Users/gunelyusubova/Desktop/FrontToBack/Views/Shared/_ProductPartial.cshtml"
                                                                                     Write(item.CATEGORY1?.DataId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\n        <div class=\"col-lg-3 col-md-6 col-xs-12\">\n            <div class=\"card\" data-id=\"");
#nullable restore
#line 6 "/Users/gunelyusubova/Desktop/FrontToBack/Views/Shared/_ProductPartial.cshtml"
                                  Write(item.CATEGORY1?.DataId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\n                <div class=\"image\">\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e744b544bf058ad8f13ed6161321a8458ae1e5354923", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 358, "~/Products-Images/", 358, 18, true);
#nullable restore
#line 8 "/Users/gunelyusubova/Desktop/FrontToBack/Views/Shared/_ProductPartial.cshtml"
AddHtmlAttributeValue("", 376, item.ImageUrl, 376, 14, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                </div>\n                <div class=\"title text-center\">\n                    <p>");
#nullable restore
#line 11 "/Users/gunelyusubova/Desktop/FrontToBack/Views/Shared/_ProductPartial.cshtml"
                  Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                    <div class=""add-cart"">
                        <p class=""addBasket"">Add to cart</p>
                    </div>
                    <div class=""price"">
                        <span>$</span>
                        <span class=""totalPrice"">");
#nullable restore
#line 17 "/Users/gunelyusubova/Desktop/FrontToBack/Views/Shared/_ProductPartial.cshtml"
                                            Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n");
#nullable restore
#line 23 "/Users/gunelyusubova/Desktop/FrontToBack/Views/Shared/_ProductPartial.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PRODUCTS1>> Html { get; private set; }
    }
}
#pragma warning restore 1591
