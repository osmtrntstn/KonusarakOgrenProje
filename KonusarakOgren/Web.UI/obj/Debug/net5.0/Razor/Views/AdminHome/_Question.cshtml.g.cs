#pragma checksum "C:\Users\osmtr\source\repos\KonusarakOgren\Web.UI\Views\AdminHome\_Question.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e87d487bb488c2e4ae97c402fff5b675fb3a6851"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdminHome__Question), @"mvc.1.0.view", @"/Views/AdminHome/_Question.cshtml")]
namespace AspNetCore
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
#line 1 "C:\Users\osmtr\source\repos\KonusarakOgren\Web.UI\Views\_ViewImports.cshtml"
using Web.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\osmtr\source\repos\KonusarakOgren\Web.UI\Views\_ViewImports.cshtml"
using Web.UI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e87d487bb488c2e4ae97c402fff5b675fb3a6851", @"/Views/AdminHome/_Question.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df0e2cf8e78cd83a6bfb064a4477c91f71396fa5", @"/Views/_ViewImports.cshtml")]
    public class Views_AdminHome__Question : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "-1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "A", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "B", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "C", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "D", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\osmtr\source\repos\KonusarakOgren\Web.UI\Views\AdminHome\_Question.cshtml"
   
    int counter = Model;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row col-12 pt-1 question-line m-1\">\r\n    <div class=\"row col-12\">\r\n        <div class=\"col-12 p-1 question\" >\r\n            <div class=\"input-group\">\r\n                <label style=\"width:10%\">Soru ");
#nullable restore
#line 9 "C:\Users\osmtr\source\repos\KonusarakOgren\Web.UI\Views\AdminHome\_Question.cshtml"
                                          Write(counter+1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" )</label>\r\n                <input");
            BeginWriteAttribute("name", " name=\"", 300, "\"", 339, 3);
            WriteAttributeValue("", 307, "Questions[", 307, 10, true);
#nullable restore
#line 10 "C:\Users\osmtr\source\repos\KonusarakOgren\Web.UI\Views\AdminHome\_Question.cshtml"
WriteAttributeValue("", 317, counter, 317, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 325, "].QuestionText", 325, 14, true);
            EndWriteAttribute();
            WriteLiteral(@" class=""form-control input-sm"" type=""text"" style=""width:90%"" />
            </div>

        </div>
    </div>



    <div class=""row col-12 "">
        <div class=""col-6 p-1 question"">
            <div class=""row col-12"">
                <div class=""col-2"">
                    <label>A)</label>
                </div>
                <div class=""col-10"">
                    <input");
            BeginWriteAttribute("name", " name=\"", 736, "\"", 786, 3);
            WriteAttributeValue("", 743, "Questions[", 743, 10, true);
#nullable restore
#line 25 "C:\Users\osmtr\source\repos\KonusarakOgren\Web.UI\Views\AdminHome\_Question.cshtml"
WriteAttributeValue("", 753, counter, 753, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 761, "].OuestionOptions[0].Text", 761, 25, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"form-control input-sm\" type=\"text\" />\r\n                    <input");
            BeginWriteAttribute("name", " name=\"", 860, "\"", 910, 3);
            WriteAttributeValue("", 867, "Questions[", 867, 10, true);
#nullable restore
#line 26 "C:\Users\osmtr\source\repos\KonusarakOgren\Web.UI\Views\AdminHome\_Question.cshtml"
WriteAttributeValue("", 877, counter, 877, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 885, "].OuestionOptions[0].Type", 885, 25, true);
            EndWriteAttribute();
            WriteLiteral(@" type=""hidden"" value=""A"" />
                </div>
            </div>

        </div>
        <div class=""col-6 p-1 question"">
            <div class=""row col-12"">
                <div class=""col-2"">
                    <label>B)</label>
                </div>
                <div class=""col-10"">
                    <input");
            BeginWriteAttribute("name", " name=\"", 1246, "\"", 1296, 3);
            WriteAttributeValue("", 1253, "Questions[", 1253, 10, true);
#nullable restore
#line 37 "C:\Users\osmtr\source\repos\KonusarakOgren\Web.UI\Views\AdminHome\_Question.cshtml"
WriteAttributeValue("", 1263, counter, 1263, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1271, "].OuestionOptions[1].Text", 1271, 25, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"form-control input-sm\" type=\"text\" />\r\n                    <input");
            BeginWriteAttribute("name", " name=\"", 1370, "\"", 1420, 3);
            WriteAttributeValue("", 1377, "Questions[", 1377, 10, true);
#nullable restore
#line 38 "C:\Users\osmtr\source\repos\KonusarakOgren\Web.UI\Views\AdminHome\_Question.cshtml"
WriteAttributeValue("", 1387, counter, 1387, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1395, "].OuestionOptions[1].Type", 1395, 25, true);
            EndWriteAttribute();
            WriteLiteral(@" type=""hidden"" value=""B"" />

                </div>
            </div>
        </div>
        <div class=""col-6 p-1 question"">
            <div class=""row col-12"">
                <div class=""col-2"">
                    <label>C)</label>
                </div>
                <div class=""col-10"">
                    <input");
            BeginWriteAttribute("name", " name=\"", 1756, "\"", 1806, 3);
            WriteAttributeValue("", 1763, "Questions[", 1763, 10, true);
#nullable restore
#line 49 "C:\Users\osmtr\source\repos\KonusarakOgren\Web.UI\Views\AdminHome\_Question.cshtml"
WriteAttributeValue("", 1773, counter, 1773, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1781, "].OuestionOptions[2].Text", 1781, 25, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"form-control input-sm\" type=\"text\" />\r\n                    <input");
            BeginWriteAttribute("name", " name=\"", 1880, "\"", 1930, 3);
            WriteAttributeValue("", 1887, "Questions[", 1887, 10, true);
#nullable restore
#line 50 "C:\Users\osmtr\source\repos\KonusarakOgren\Web.UI\Views\AdminHome\_Question.cshtml"
WriteAttributeValue("", 1897, counter, 1897, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1905, "].OuestionOptions[2].Type", 1905, 25, true);
            EndWriteAttribute();
            WriteLiteral(@" type=""hidden"" value=""C"" />

                </div>
            </div>
        </div>
        <div class=""col-6 p-1 question"" >
            <div class=""row col-12"">
                <div class=""col-2"">
                    <label>D)</label>
                </div>
                <div class=""col-10"">
                    <input");
            BeginWriteAttribute("name", " name=\"", 2267, "\"", 2317, 3);
            WriteAttributeValue("", 2274, "Questions[", 2274, 10, true);
#nullable restore
#line 61 "C:\Users\osmtr\source\repos\KonusarakOgren\Web.UI\Views\AdminHome\_Question.cshtml"
WriteAttributeValue("", 2284, counter, 2284, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2292, "].OuestionOptions[3].Text", 2292, 25, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"form-control input-sm\" type=\"text\" />\r\n                    <input");
            BeginWriteAttribute("name", " name=\"", 2391, "\"", 2441, 3);
            WriteAttributeValue("", 2398, "Questions[", 2398, 10, true);
#nullable restore
#line 62 "C:\Users\osmtr\source\repos\KonusarakOgren\Web.UI\Views\AdminHome\_Question.cshtml"
WriteAttributeValue("", 2408, counter, 2408, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2416, "].OuestionOptions[3].Type", 2416, 25, true);
            EndWriteAttribute();
            WriteLiteral(" type=\"hidden\" value=\"D\" />\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"row col-12 justify-content-center\">\r\n        <div class=\"col-8 p-1 question\" style=\"text-align: center\">\r\n\r\n            <select");
            BeginWriteAttribute("name", " name=\"", 2690, "\"", 2731, 3);
            WriteAttributeValue("", 2697, "Questions[", 2697, 10, true);
#nullable restore
#line 72 "C:\Users\osmtr\source\repos\KonusarakOgren\Web.UI\Views\AdminHome\_Question.cshtml"
WriteAttributeValue("", 2707, counter, 2707, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2715, "].QuestionAnsver", 2715, 16, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"form-control\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e87d487bb488c2e4ae97c402fff5b675fb3a685112537", async() => {
                WriteLiteral("Doğru Cevap Seç");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e87d487bb488c2e4ae97c402fff5b675fb3a685113722", async() => {
                WriteLiteral("A");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e87d487bb488c2e4ae97c402fff5b675fb3a685114893", async() => {
                WriteLiteral("B");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e87d487bb488c2e4ae97c402fff5b675fb3a685116064", async() => {
                WriteLiteral("C");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e87d487bb488c2e4ae97c402fff5b675fb3a685117235", async() => {
                WriteLiteral("D");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </select>\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591
