#pragma checksum "E:\Projects\Billing System\Microsoft-Teams-Billing-System\BillingPortal\Pages\Reports\OutgoingCallsByCountry.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b4414610cbbeab13e806b277b3496f607e6dbf8f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(BillingPortal.Pages.Reports.Pages_Reports_OutgoingCallsByCountry), @"mvc.1.0.razor-page", @"/Pages/Reports/OutgoingCallsByCountry.cshtml")]
namespace BillingPortal.Pages.Reports
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
#line 1 "E:\Projects\Billing System\Microsoft-Teams-Billing-System\BillingPortal\Pages\_ViewImports.cshtml"
using BillingPortal;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4414610cbbeab13e806b277b3496f607e6dbf8f", @"/Pages/Reports/OutgoingCallsByCountry.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a03e81cf30a155b2c21d0417890d015001a2f58", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Reports_OutgoingCallsByCountry : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Reports/CountryOutgoingReport", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "E:\Projects\Billing System\Microsoft-Teams-Billing-System\BillingPortal\Pages\Reports\OutgoingCallsByCountry.cshtml"
  
    Layout = "_LayoutTables";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"right_col\" role=\"main\">\r\n    <div");
            BeginWriteAttribute("class", " class=\"", 154, "\"", 162, 0);
            EndWriteAttribute();
            WriteLiteral(@">
        <div class=""page-title"">
            <div class=""title_left"">
                <h3>Countries <small>List of Countries</small></h3>
            </div>


        </div>

        <div class=""clearfix""></div>
        <div class=""row"" style=""display: block;"">
            <div class=""col-md-12 col-sm-12  "">
                <div class=""x_panel"">
                    <div class=""x_title"">
                        <h2>List of Users <small></small></h2>
                        <div class=""clearfix""></div>
                    </div>
                    <div class=""x_content"">
                        <table class=""table "" id=""datatable"">
                            <thead>
                                <tr>
                                    <td>Country Name</td>
                                    <td>Actions</td>
                                </tr>

                            </thead>
                            <tbody>
");
#nullable restore
#line 34 "E:\Projects\Billing System\Microsoft-Teams-Billing-System\BillingPortal\Pages\Reports\OutgoingCallsByCountry.cshtml"
                                 foreach (var item in Model._RecordsTable)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 38 "E:\Projects\Billing System\Microsoft-Teams-Billing-System\BillingPortal\Pages\Reports\OutgoingCallsByCountry.cshtml"
                                       Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n\r\n                                        <td>\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b4414610cbbeab13e806b277b3496f607e6dbf8f6032", async() => {
                WriteLiteral("View Report");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 42 "E:\Projects\Billing System\Microsoft-Teams-Billing-System\BillingPortal\Pages\Reports\OutgoingCallsByCountry.cshtml"
                                                                                           WriteLiteral(item.Replace(" ","-"));

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 45 "E:\Projects\Billing System\Microsoft-Teams-Billing-System\BillingPortal\Pages\Reports\OutgoingCallsByCountry.cshtml"

                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n\r\n\r\n\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n\r\n        </div>\r\n        <div class=\"clearfix\"></div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BillingPortal.Pages.Reports.OutgoingCallsByCountryModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BillingPortal.Pages.Reports.OutgoingCallsByCountryModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BillingPortal.Pages.Reports.OutgoingCallsByCountryModel>)PageContext?.ViewData;
        public BillingPortal.Pages.Reports.OutgoingCallsByCountryModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
