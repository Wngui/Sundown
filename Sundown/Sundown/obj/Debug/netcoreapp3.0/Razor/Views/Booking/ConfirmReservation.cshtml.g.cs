#pragma checksum "C:\Users\LHRBO\source\repos\Sundown\Sundown\Views\Booking\ConfirmReservation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "955e90f0f363a65739f4254dd34495b7fc7a981a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Booking_ConfirmReservation), @"mvc.1.0.view", @"/Views/Booking/ConfirmReservation.cshtml")]
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
#line 1 "C:\Users\LHRBO\source\repos\Sundown\Sundown\Views\_ViewImports.cshtml"
using Sundown;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LHRBO\source\repos\Sundown\Sundown\Views\_ViewImports.cshtml"
using Sundown.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"955e90f0f363a65739f4254dd34495b7fc7a981a", @"/Views/Booking/ConfirmReservation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"922381d7f8f7b1ae597cfbba9d1b7296bd6bdc56", @"/Views/_ViewImports.cshtml")]
    public class Views_Booking_ConfirmReservation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\LHRBO\source\repos\Sundown\Sundown\Views\Booking\ConfirmReservation.cshtml"
  
    ViewData["Title"] = "Reservation successful";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center option\">\r\n    <h1 class=\"display-4\">Reservation Sucessful!</h1>\r\n</div>\r\n<div style=\"display:inline;width:100%;\">\r\n    <center>\r\n");
#nullable restore
#line 11 "C:\Users\LHRBO\source\repos\Sundown\Sundown\Views\Booking\ConfirmReservation.cshtml"
         using (Html.BeginForm("Reservation", "Booking"))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <button id=\"btn_back\" style=\"width:200px;\" class=\"btn btn-outline-secondary\" type=\"submit\">Back to homepage</button>\r\n");
#nullable restore
#line 14 "C:\Users\LHRBO\source\repos\Sundown\Sundown\Views\Booking\ConfirmReservation.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </center>\r\n</div>\r\n");
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
