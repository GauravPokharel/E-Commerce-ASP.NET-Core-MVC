#pragma checksum "E:\Programs\Dot_net\ProductManagement\ProductManagement\Views\Cart\CartDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7b2d95202a877ece8a9a21cd69f32c48822f3485"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_CartDetails), @"mvc.1.0.view", @"/Views/Cart/CartDetails.cshtml")]
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
#line 1 "E:\Programs\Dot_net\ProductManagement\ProductManagement\Views\_ViewImports.cshtml"
using ProductManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Programs\Dot_net\ProductManagement\ProductManagement\Views\_ViewImports.cshtml"
using ProductManagement.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b2d95202a877ece8a9a21cd69f32c48822f3485", @"/Views/Cart/CartDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c621dd867d338bcdfee01b9a24a289ec153efff", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_CartDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CartModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delivered", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"<div class=""text-center"">
    <h1 class=""display-4"">Cart Details</h1>
</div>
<div class=""text-center"">
    <table class=""table table-bordered table-hover"">
        <thead>
            <tr>
                <th scope=""col"">#</th>
                <th scope=""col"">Product Name</th>
                <th scope=""col"">Price Per Product (Kg|Piece)</th>
                <th scope=""col"">Quantity</th>
                <th scope=""col"">Price</th>
                <th scope=""col"">Customer Name</th>
                <th scope=""col"">Delivery Destination</th>
                <th scope=""col"">Action</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 22 "E:\Programs\Dot_net\ProductManagement\ProductManagement\Views\Cart\CartDetails.cshtml"
              int index = 1;
                double TotalPrice = 0.0;

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "E:\Programs\Dot_net\ProductManagement\ProductManagement\Views\Cart\CartDetails.cshtml"
             foreach (var item in @Model)
            {
                double price = 0.0;

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td scope=\"row\">");
#nullable restore
#line 28 "E:\Programs\Dot_net\ProductManagement\ProductManagement\Views\Cart\CartDetails.cshtml"
                           Write(index);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 29 "E:\Programs\Dot_net\ProductManagement\ProductManagement\Views\Cart\CartDetails.cshtml"
               Write(item.ProductInfo.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 30 "E:\Programs\Dot_net\ProductManagement\ProductManagement\Views\Cart\CartDetails.cshtml"
                 if (item.ProductInfo.Discount == null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>");
#nullable restore
#line 32 "E:\Programs\Dot_net\ProductManagement\ProductManagement\Views\Cart\CartDetails.cshtml"
                   Write(item.ProductInfo.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 33 "E:\Programs\Dot_net\ProductManagement\ProductManagement\Views\Cart\CartDetails.cshtml"

                    price = item.ProductInfo.Price * item.OrderQuantity;
                    TotalPrice += price;
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "E:\Programs\Dot_net\ProductManagement\ProductManagement\Views\Cart\CartDetails.cshtml"
                 if (item.ProductInfo.Discount != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n                        Discount=");
#nullable restore
#line 40 "E:\Programs\Dot_net\ProductManagement\ProductManagement\Views\Cart\CartDetails.cshtml"
                            Write(item.ProductInfo.Discount);

#line default
#line hidden
#nullable disable
            WriteLiteral("%\r\n                        <hr />\r\n                        Price=<del>");
#nullable restore
#line 42 "E:\Programs\Dot_net\ProductManagement\ProductManagement\Views\Cart\CartDetails.cshtml"
                              Write(item.ProductInfo.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</del>\r\n                        <hr />\r\n                        Discounted Price<ins>");
#nullable restore
#line 44 "E:\Programs\Dot_net\ProductManagement\ProductManagement\Views\Cart\CartDetails.cshtml"
                                        Write(item.ProductInfo.DiscountedPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</ins>\r\n                    </td>\r\n");
#nullable restore
#line 46 "E:\Programs\Dot_net\ProductManagement\ProductManagement\Views\Cart\CartDetails.cshtml"

                    price = item.ProductInfo.DiscountedPrice * item.OrderQuantity;
                    TotalPrice += price;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>");
#nullable restore
#line 50 "E:\Programs\Dot_net\ProductManagement\ProductManagement\Views\Cart\CartDetails.cshtml"
               Write(item.OrderQuantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 51 "E:\Programs\Dot_net\ProductManagement\ProductManagement\Views\Cart\CartDetails.cshtml"
               Write(price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 52 "E:\Programs\Dot_net\ProductManagement\ProductManagement\Views\Cart\CartDetails.cshtml"
               Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 53 "E:\Programs\Dot_net\ProductManagement\ProductManagement\Views\Cart\CartDetails.cshtml"
               Write(item.DeliveryDestination);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7b2d95202a877ece8a9a21cd69f32c48822f34859527", async() => {
                WriteLiteral("Delivered");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 55 "E:\Programs\Dot_net\ProductManagement\ProductManagement\Views\Cart\CartDetails.cshtml"
                                                                      WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 58 "E:\Programs\Dot_net\ProductManagement\ProductManagement\Views\Cart\CartDetails.cshtml"
                index++;
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <th colspan=\"4\">Total</th>\r\n                <td colspan=\"4\">");
#nullable restore
#line 62 "E:\Programs\Dot_net\ProductManagement\ProductManagement\Views\Cart\CartDetails.cshtml"
                           Write(TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CartModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
