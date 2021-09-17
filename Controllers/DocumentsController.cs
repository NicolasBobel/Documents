using Microsoft.AspNetCore.Mvc;
using TesteCadastro.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System;
namespace TesteCadastro.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly ILogger<DocumentsController> _logger;

        public DocumentsController(ILogger<DocumentsController> logger)
        {
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
        public IActionResult Cadastro(Documents documents)
        {

            try
            {
                DocumentsRepository ur = new DocumentsRepository();
                ur.Cadastro(documents);
                TempData["alerta"] = "Cadastrado com sucesso";
                return RedirectToAction("Cadastro");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return RedirectToAction("Cadastro");
            }

        }

        //public IActionResult Litagem()
        //{

        //   return View();


        //}

    }
}