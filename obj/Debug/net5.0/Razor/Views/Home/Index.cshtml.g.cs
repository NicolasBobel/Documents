#pragma checksum "C:\Users\nicol\Documents\testeCadastro\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f9ea013e99387c67ca45d91bf709e64f49bc600e"
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
#line 1 "C:\Users\nicol\Documents\testeCadastro\Views\Home\Index.cshtml"
using TesteCadastro.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9ea013e99387c67ca45d91bf709e64f49bc600e", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c66e443ba81bfd444e2b1c1ae94c4deedf2b8d44", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Documents>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<section class=""Cards"">
    <div class=""Cadastro"">
        <div class=""card p-2  "" style=""width: 18rem;"">
            <img src=""img/documentos.png"" class=""imagem"">
            <a class=""card-block stretched-link text-decoration-none"" href=""/Documents/Cadastro"">
                <h4 class=""card-title text-center"">Cadastrar Documentos</h4>
            </a>
        </div>
    </div>

    <div class=""Lista"">
        <div class=""card p-2  "" style=""width: 18rem;"">
            <img src=""img/documentos.png"">
            <a class=""card-block stretched-link text-decoration-none"" href=""/Documents/Lista"">
                <h4 class=""card-title text-center"">Listagem de Documentos</h4>
            </a>
        </div>
    </div>

</section>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Documents> Html { get; private set; }
    }
}
#pragma warning restore 1591
