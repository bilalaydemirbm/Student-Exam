#pragma checksum "C:\Users\bilag\Student-Exam-Automation\Exam\Exam.Web\Areas\Admin\Views\Shared\PartialViews\_StatusPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a430ddf1746c99c464b596a8d47f7f9fa085e5c5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared_PartialViews__StatusPartial), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/PartialViews/_StatusPartial.cshtml")]
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
#line 3 "C:\Users\bilag\Student-Exam-Automation\Exam\Exam.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Exam.Model.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\bilag\Student-Exam-Automation\Exam\Exam.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Exam.Core.Entity.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a430ddf1746c99c464b596a8d47f7f9fa085e5c5", @"/Areas/Admin/Views/Shared/PartialViews/_StatusPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f0ef07a3fabd7503379987856d10f7360f20b7f", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared_PartialViews__StatusPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Exam.Core.Entity.Enums.Status>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\bilag\Student-Exam-Automation\Exam\Exam.Web\Areas\Admin\Views\Shared\PartialViews\_StatusPartial.cshtml"
 switch (Model)
{
    case Exam.Core.Entity.Enums.Status.None:

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span class=\"badge badge-primary\">????lem Yap??lmad??</span>\r\n");
#nullable restore
#line 6 "C:\Users\bilag\Student-Exam-Automation\Exam\Exam.Web\Areas\Admin\Views\Shared\PartialViews\_StatusPartial.cshtml"
        break;
    case Exam.Core.Entity.Enums.Status.Active:

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span class=\"badge badge-secondary\">Aktif</span>\r\n");
#nullable restore
#line 9 "C:\Users\bilag\Student-Exam-Automation\Exam\Exam.Web\Areas\Admin\Views\Shared\PartialViews\_StatusPartial.cshtml"
        break;
    case Exam.Core.Entity.Enums.Status.Passive:

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span class=\"badge badge-primary\">Pasif</span>\r\n");
#nullable restore
#line 12 "C:\Users\bilag\Student-Exam-Automation\Exam\Exam.Web\Areas\Admin\Views\Shared\PartialViews\_StatusPartial.cshtml"
        break;
    case Exam.Core.Entity.Enums.Status.Deleted:

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span class=\"badge badge-danger\">Silindi</span>\r\n");
#nullable restore
#line 15 "C:\Users\bilag\Student-Exam-Automation\Exam\Exam.Web\Areas\Admin\Views\Shared\PartialViews\_StatusPartial.cshtml"
        break;
    case Exam.Core.Entity.Enums.Status.Updated:

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span class=\"badge badge-info\">G??ncellendi</span>\r\n");
#nullable restore
#line 18 "C:\Users\bilag\Student-Exam-Automation\Exam\Exam.Web\Areas\Admin\Views\Shared\PartialViews\_StatusPartial.cshtml"
        break;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Exam.Core.Entity.Enums.Status> Html { get; private set; }
    }
}
#pragma warning restore 1591
