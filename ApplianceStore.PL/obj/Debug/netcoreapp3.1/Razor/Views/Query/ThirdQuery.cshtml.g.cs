#pragma checksum "C:\Users\Sergey\Desktop\ApplianceStore\ApplianceStore.PL\Views\Query\ThirdQuery.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ef989ca25fe66ac52e713781ebd4a4aeb16260d3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Query_ThirdQuery), @"mvc.1.0.view", @"/Views/Query/ThirdQuery.cshtml")]
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
#line 1 "C:\Users\Sergey\Desktop\ApplianceStore\ApplianceStore.PL\Views\_ViewImports.cshtml"
using ApplianceStore.PL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Sergey\Desktop\ApplianceStore\ApplianceStore.PL\Views\_ViewImports.cshtml"
using ApplianceStore.PL.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Sergey\Desktop\ApplianceStore\ApplianceStore.PL\Views\_ViewImports.cshtml"
using ApplianceStore.PL.Models.BindingModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Sergey\Desktop\ApplianceStore\ApplianceStore.PL\Views\_ViewImports.cshtml"
using ApplianceStore.PL.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef989ca25fe66ac52e713781ebd4a4aeb16260d3", @"/Views/Query/ThirdQuery.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"430dd507dd650b82e7b6cc8903b45c7ac12c243e", @"/Views/_ViewImports.cshtml")]
    public class Views_Query_ThirdQuery : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ProductViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\Sergey\Desktop\ApplianceStore\ApplianceStore.PL\Views\Query\ThirdQuery.cshtml"
  
    ViewData["Title"] = "Query";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<table class=\"table_price\">\n    <caption>Результат</caption>\n    <tr>\n        <th>\n            ");
#nullable restore
#line 11 "C:\Users\Sergey\Desktop\ApplianceStore\ApplianceStore.PL\Views\Query\ThirdQuery.cshtml"
       Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </th>\n        <th>\n            ");
#nullable restore
#line 14 "C:\Users\Sergey\Desktop\ApplianceStore\ApplianceStore.PL\Views\Query\ThirdQuery.cshtml"
       Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </th>\n    </tr>\n\n");
#nullable restore
#line 18 "C:\Users\Sergey\Desktop\ApplianceStore\ApplianceStore.PL\Views\Query\ThirdQuery.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <td>\n                ");
#nullable restore
#line 22 "C:\Users\Sergey\Desktop\ApplianceStore\ApplianceStore.PL\Views\Query\ThirdQuery.cshtml"
           Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 25 "C:\Users\Sergey\Desktop\ApplianceStore\ApplianceStore.PL\Views\Query\ThirdQuery.cshtml"
           Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n        </tr>\n");
#nullable restore
#line 28 "C:\Users\Sergey\Desktop\ApplianceStore\ApplianceStore.PL\Views\Query\ThirdQuery.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ProductViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
