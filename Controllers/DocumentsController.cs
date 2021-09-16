using Microsoft.AspNetCore.Mvc;
using TesteCadastro.Models;
using System.Collections.Generic;
namespace TesteCadastro.Controllers
{
    public class DocumentsController : Controller
    {
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
            DocumentsRepository ur = new DocumentsRepository();
            ur.Cadastro(documents);
            return RedirectToAction("Cadastro");
        }

        //public IActionResult Litagem()
        //{

        //   return View();


        //}

    }
}