using Microsoft.AspNetCore.Mvc;

namespace EstacionamentoDotnet6.Controllers
{
    public class PessoaController : Controller
    {
        public IActionResult Pessoa()
        {
            return View();
        }
    }
}