using Microsoft.AspNetCore.Mvc;
using TesteCadastro.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

using Microsoft.AspNetCore.Mvc.RazorPages;
namespace TesteCadastro.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly ILogger<DocumentsController> _logger;
        private IWebHostEnvironment Environment;


        public DocumentsController(IWebHostEnvironment _environment, ILogger<DocumentsController> logger)
        {
            Environment = _environment;
            _logger = logger;
        }


        public IActionResult Cadastro()
        {
            DocumentsRepository ur = new DocumentsRepository();
            List<Processo> list = ur.Listagem();
            Documents doc = new Documents();
            doc.processos = list;
            return View(doc);
        }

        [HttpPost]
        public IActionResult Cadastro(Documents document)
        {
            try
            {
                DocumentsRepository ur = new DocumentsRepository();
                ur.Cadastro(document);

                string wwwPath = this.Environment.WebRootPath;

                string path = Path.Combine(this.Environment.WebRootPath, "UploadedFiles", document.codigo.ToString());

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fileName = Path.GetFileName(document.postedFiles.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    document.postedFiles.CopyTo(stream);
                }

                TempData["alerta"] = "Cadastrado com sucesso";
                return RedirectToAction("Cadastro");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                TempData["alerta"] = "Falha no Cadastro, Código duplicado";
                return RedirectToAction("Cadastro");
            }

        }

        public IActionResult Lista(Documents document)
        {


            DocumentsRepository dr = new DocumentsRepository();
            List<Documents> Lista = dr.Lista();
            return View(Lista);



        }

        public FileResult DownloadFile(Documents document)
        {

            string path = Path.Combine(this.Environment.WebRootPath, "UploadedFiles", document.codigo.ToString());

            string[] file = Directory.GetFiles(path);


            byte[] bytes = System.IO.File.ReadAllBytes(file[0]);


            string ext = Path.GetExtension(file[0]);
            string myFilePath = @"C:\Arquivo." + ext;


            return File(bytes, "application/octet-stream", myFilePath);
        }
    }
}