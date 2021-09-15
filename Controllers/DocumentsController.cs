using Microsoft.AspNetCore.Mvc;
using TesteCadastro.Models;

namespace TesteCadastro.Controllers
{
    public class DocumentsController : Controller
    {
        public IActionResult Cadastro()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Documents documents)
        {
            DocumentsRepository ur = new DocumentsRepository();
            ur.Cadastro(documents);
            return View();
        }

    }
}