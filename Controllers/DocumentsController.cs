using Microsoft.AspNetCore.Mvc;
using RegisterDocuments.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RegisterDocuments.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly ILogger<DocumentsController> logger;
        private IWebHostEnvironment environment;


        public DocumentsController(IWebHostEnvironment environment, ILogger<DocumentsController> logger)
        {
            this.environment = environment;
            this.logger = logger;
        }


        public IActionResult Register()
        {
            var documentsRepository = new DocumentsRepository();
            List<Process> processList = documentsRepository.ProcessList();

            //var categorias = documentsReponsitory.ListarCategoriaPorIdProcesso("");

            Documents doc = new Documents();
            doc.processList = processList;

            return View(doc);
        }

        [HttpPost]
        public IActionResult Register(Documents document)
        {
            try
            {
                DocumentsRepository ur = new DocumentsRepository();
                ur.InsertDocument(document);

                string wwwPath = this.environment.WebRootPath;

                string path = Path.Combine(this.environment.WebRootPath, "UploadedFiles", document.code.ToString());

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fileName = Path.GetFileName(document.postedFiles.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    document.postedFiles.CopyTo(stream);
                }

                TempData["alert"] = "Cadastrado com sucesso";
                return RedirectToAction("Register");
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                TempData["alert"] = "Falha no Cadastro, Código duplicado";
                return RedirectToAction("Register");
            }

        }

        public IActionResult List(Documents document)
        {
            DocumentsRepository documentRepository = new DocumentsRepository();
            List<Documents> documents = documentRepository.ListOrderByTitle();

            return View(documents);
        }

        public FileResult DownloadFile(Documents document)
        {

            string path = Path.Combine(this.environment.WebRootPath, "UploadedFiles", document.code.ToString());

            string[] file = Directory.GetFiles(path);

            byte[] bytes = System.IO.File.ReadAllBytes(file[0]);

            string ext = Path.GetExtension(file[0]);
            string myFilePath = @"C:\Arquivo." + ext;

            return File(bytes, "application/octet-stream", myFilePath);
        }
    }
}