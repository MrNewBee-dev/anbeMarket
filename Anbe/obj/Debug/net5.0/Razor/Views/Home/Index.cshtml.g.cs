#pragma checksum "C:\Users\milad\Desktop\Anbe\Anbe\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5002347933758f5d96d811e67fb1f6e58a1ecd77"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\milad\Desktop\Anbe\Anbe\Views\_ViewImports.cshtml"
using Anbe;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\milad\Desktop\Anbe\Anbe\Views\_ViewImports.cshtml"
using Anbe.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5002347933758f5d96d811e67fb1f6e58a1ecd77", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ae50f5c9563bb3704ef36079c8ba760f5f29e21", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Anbe.Models.Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""col-lg-9 col-md-9 col-xs-12 pl"">
    <div class=""shop-archive-content mt-3 d-block"">
        <div class=""archive-header"">
            <h2 class=""archive-header-title"">آرشیو محصولات</h2>
            <div class=""sort-tabs mt-0 d-inline-block pr"">
                <h4>مرتب‌سازی بر اساس :</h4>
            </div>
            <div class=""nav-sort-tabs-res"">
                <ul class=""nav sort-tabs-options"" id=""myTab"" role=""tablist"">


                    <li class=""nav-item"">
                        <a class=""nav-link"" id=""newest-tab"" data-toggle=""tab"" href=""#newest""
                           role=""tab"" aria-controls=""newest"" aria-selected=""false"">جدیدترین</a>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link"" id=""cheapest-tab"" data-toggle=""tab"" href=""#cheapest""
                           role=""tab"" aria-controls=""cheapest"" aria-selected=""false"">ارزان‌ترین</a>
                    </li>
                    <li class=""nav-item");
            WriteLiteral(@""">
                        <a class=""nav-link"" id=""most-expensive-tab"" data-toggle=""tab""
                           href=""#most-expensive"" role=""tab"" aria-controls=""most-expensive""
                           aria-selected=""false"">گران‌ترین</a>
                    </li>
                </ul>
            </div>
        </div>
        <div class=""product-items"">
            <div class=""tab-content"" id=""myTabContent"">
                <div class=""tab-pane fade show active"" id=""Most-visited"" role=""tabpanel""
                     aria-labelledby=""newest-tab"">
                    <div class=""row"">
");
#nullable restore
#line 35 "C:\Users\milad\Desktop\Anbe\Anbe\Views\Home\Index.cshtml"
                         foreach (var item in @Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""col-lg-3 col-md-3 col-xs-12 order-1 d-block mb-3"">
                                <section class=""product-box product product-type-simple"">
                                    <div class=""thumb"">
                                        <a href=""#"" class=""d-block"">
                                            <div class=""promotion-badge"">فروش ویژه</div>
                                            <div class=""product-rate"">
                                                <i class=""fa fa-star active""></i>
                                                <i class=""fa fa-star active""></i>
                                                <i class=""fa fa-star active""></i>
                                                <i class=""fa fa-star""></i>
                                                <i class=""fa fa-star""></i>
                                            </div>
                                            <div hidden class=""discount-d"">
                      ");
            WriteLiteral(@"                          <span>10%</span>
                                            </div>
                                            <img src=""assets/images/slider-product/boxing.jpg"">
                                        </a>
                                    </div>
                                    <div class=""title"">
                                        <a href=""#"">
                                            ");
#nullable restore
#line 57 "C:\Users\milad\Desktop\Anbe\Anbe\Views\Home\Index.cshtml"
                                       Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </a>
                                    </div>
                                    <div class=""price"">
                                        <span class=""amount"">
                                            
                                            ");
#nullable restore
#line 63 "C:\Users\milad\Desktop\Anbe\Anbe\Views\Home\Index.cshtml"
                                       Write(item.Price.ToString("#,0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            <span>تومان</span>\r\n                                        </span>\r\n                                    </div>\r\n                                </section>\r\n                            </div>\r\n");
#nullable restore
#line 69 "C:\Users\milad\Desktop\Anbe\Anbe\Views\Home\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        

                    </div>
                </div>


            </div>
        </div>
        <div class=""pagination-product"">
            <nav aria-label=""Page navigation example"">
                <ul class=""pagination"">
                    <li class=""page-item"">
                        <a class=""page-link"" href=""#"" aria-label=""Previous"">
                            <span aria-hidden=""true"">&laquo;</span>
                        </a>
                    </li>
                    <li class=""page-item"">
                        <a class=""page-link active"" href=""#"">1</a>
                    </li>
                    <li class=""page-item"">
                        <a class=""page-link"" href=""#"">2</a>
                    </li>
                    <li class=""page-item"">
                        <a class=""page-link"" href=""#"">3</a>
                    </li>
                    <li class=""page-item"">
                        <a class=""page-link"" href=""#"" aria-label=""Next");
            WriteLiteral("\">\r\n                            <span aria-hidden=\"true\">&raquo;</span>\r\n                        </a>\r\n                    </li>\r\n                </ul>\r\n            </nav>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Anbe.Models.Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
