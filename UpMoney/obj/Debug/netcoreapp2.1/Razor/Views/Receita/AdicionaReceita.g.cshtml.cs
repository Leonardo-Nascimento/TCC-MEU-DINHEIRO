#pragma checksum "D:\TCC-MEU-DINHEIRO\UpMoney\Views\Receita\AdicionaReceita.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6bdc1af2c6b169905acb157c0639acf30bc98a76"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Receita_AdicionaReceita), @"mvc.1.0.view", @"/Views/Receita/AdicionaReceita.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Receita/AdicionaReceita.cshtml", typeof(AspNetCore.Views_Receita_AdicionaReceita))]
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
#line 1 "D:\TCC-MEU-DINHEIRO\UpMoney\Views\_ViewImports.cshtml"
using UpMoney;

#line default
#line hidden
#line 2 "D:\TCC-MEU-DINHEIRO\UpMoney\Views\_ViewImports.cshtml"
using UpMoney.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bdc1af2c6b169905acb157c0639acf30bc98a76", @"/Views/Receita/AdicionaReceita.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d6f6b0cc7329c22f7df196ea1979f0b99f355647", @"/Views/_ViewImports.cshtml")]
    public class Views_Receita_AdicionaReceita : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("responsive-img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/modalSucesso.ico"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\TCC-MEU-DINHEIRO\UpMoney\Views\Receita\AdicionaReceita.cshtml"
  
    ViewData["Title"] = "AdicionaReceita";
    Layout = "~/Views/Shared/Layout2.cshtml";

#line default
#line hidden
            BeginContext(100, 220, true);
            WriteLiteral("\r\n<a class=\"waves-effect waves-light btn modal-trigger hide\" href=\"#modalOK\" id=\"btnModalSucesso\">Modal</a>\r\n\r\n<!-- Modal Sucesso Structure -->\r\n<div id=\"modalOK\" class=\"modal\">\r\n    <div class=\"modal-content\">\r\n        ");
            EndContext();
            BeginContext(320, 57, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "62af58bd6c1946bf8c5f1128a04323c2", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(377, 784, true);
            WriteLiteral(@"
        <h5 style=""font-family: 'Merienda One', cursive; font-size: 20px;"">Cadastrado com Sucesso!</h5>        
    </div>

    <div class=""modal-footer"">
      <a href=""#!"" class=""modal-close waves-effect waves-green btn-flat hide"" id=""btnFechar"" >Agree</a>
    </div>    
</div>


<script> 
window.onload = function(){

    document.addEventListener('DOMContentLoaded', function() {
    var elems = document.querySelectorAll('.modalOK');
    var instances = M.Modal.init(elems, {
    
  });
  });
    
    document.getElementById(""btnModalSucesso"").click();
    setTimeout(funcaoFechar, 1500);

};

function funcaoFechar() {
   document.getElementById(""btnFechar"").click();
   window.location.href=""../Home/MenuPrincipal"";
  
}
  

</script>



");
            EndContext();
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
