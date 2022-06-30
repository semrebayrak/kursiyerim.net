#pragma checksum "C:\Users\benim\source\repos\Kursiyerim\KursiyerimNET\Views\Courses\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c408bc1b4f9d9bdda2906ac875f9eaa95cde5a6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Courses_Index), @"mvc.1.0.view", @"/Views/Courses/Index.cshtml")]
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
#line 1 "C:\Users\benim\source\repos\Kursiyerim\KursiyerimNET\Views\_ViewImports.cshtml"
using Test;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\benim\source\repos\Kursiyerim\KursiyerimNET\Views\_ViewImports.cshtml"
using Test.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c408bc1b4f9d9bdda2906ac875f9eaa95cde5a6", @"/Views/Courses/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b938626c1cb27b4184c87d029e4bd0625527155", @"/Views/_ViewImports.cshtml")]
    public class Views_Courses_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\benim\source\repos\Kursiyerim\KursiyerimNET\Views\Courses\Index.cshtml"
     ViewData["Title"] = "Courses"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n  <section id=\"courses\" class=\"bg-gray-50\">\n    <h2 class=\"mt-10 text-4xl text-center\">Courses</h2>\n    <div class=\"dropdown\">\n      <button class=\"dropbtn\">Categories</button>\n      <div class=\"dropdown-content\">\n");
#nullable restore
#line 9 "C:\Users\benim\source\repos\Kursiyerim\KursiyerimNET\Views\Courses\Index.cshtml"
       foreach(var item in Model.categoryList){
       

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\benim\source\repos\Kursiyerim\KursiyerimNET\Views\Courses\Index.cshtml"
  Write(Html.ActionLink( (string) @item.name, "Index","Courses",new{ category= @item.name }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\benim\source\repos\Kursiyerim\KursiyerimNET\Views\Courses\Index.cshtml"
                                                                                            
      }

#line default
#line hidden
#nullable disable
            WriteLiteral("      </div>\n    </div>\n    <ul class=\"grid-row my-40\">\n");
#nullable restore
#line 15 "C:\Users\benim\source\repos\Kursiyerim\KursiyerimNET\Views\Courses\Index.cshtml"
       foreach(var item in Model.courseList){

#line default
#line hidden
#nullable disable
            WriteLiteral("      <li>\n        <a");
            BeginWriteAttribute("href", " href=\'", 540, "\'", 621, 1);
#nullable restore
#line 17 "C:\Users\benim\source\repos\Kursiyerim\KursiyerimNET\Views\Courses\Index.cshtml"
WriteAttributeValue("", 547, Url.Action("Course", "Courses", 
         new { courseName = item.name }), 547, 74, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card\">\n          <img");
            BeginWriteAttribute("src", "\n            src=", 651, "", 687, 1);
            WriteAttributeValue("", 668, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
                  
#nullable restore
#line 20 "C:\Users\benim\source\repos\Kursiyerim\KursiyerimNET\Views\Courses\Index.cshtml"
             Write(item.coverPhoto);

#line default
#line hidden
#nullable disable
                                  
                PopWriter();
            }
            ), 668, 19, false);
            EndWriteAttribute();
            WriteLiteral("\n            class=\"card__image\"");
            BeginWriteAttribute("alt", "\n            alt=\"", 719, "\"", 737, 0);
            EndWriteAttribute();
            WriteLiteral("\n          />");
            WriteLiteral("          <div class=\"card__overlay\">\n            <div class=\"card__header\">\n              <img\n                class=\"card thumb\"\n                src=\"https://i.imgur.com/7D7I6dI.png\"");
            BeginWriteAttribute("alt", "\n                alt=\"", 936, "\"", 958, 0);
            EndWriteAttribute();
            WriteLiteral("\n              />\n              <div class=\"card__header-text\">\n                <h3 class=\"card__title\">");
#nullable restore
#line 32 "C:\Users\benim\source\repos\Kursiyerim\KursiyerimNET\Views\Courses\Index.cshtml"
                                     Write(item.trainer.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n                <span class=\"card__status\">");
#nullable restore
#line 33 "C:\Users\benim\source\repos\Kursiyerim\KursiyerimNET\Views\Courses\Index.cshtml"
                                        Write(item.trainer.profession);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n              </div>\n            </div>\n            <p class=\"card__description\">\n");
#nullable restore
#line 37 "C:\Users\benim\source\repos\Kursiyerim\KursiyerimNET\Views\Courses\Index.cshtml"
           Write(item.description);

#line default
#line hidden
#nullable disable
            WriteLiteral("            </p>\n          </div>\n        </a>\n      </li>\n");
#nullable restore
#line 42 "C:\Users\benim\source\repos\Kursiyerim\KursiyerimNET\Views\Courses\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\n  </section>\n\n\n</Test.Models.trainer>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591