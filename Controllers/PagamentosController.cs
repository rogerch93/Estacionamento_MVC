using Microsoft.AspNetCore.Mvc;

namespace EstacionamentoDotnet6.Controllers
{
    public class PagamentosController : Controller
    {
        public IActionResult Pagamentos()
        {
            return View();
        }
    }
}