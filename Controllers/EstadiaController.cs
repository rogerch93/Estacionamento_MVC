using Microsoft.AspNetCore.Mvc;

namespace EstacionamentoDotnet6.Controllers
{
    public class EstadiaController : Controller
    {
         public IActionResult Estadia()
        {
            return View();
        }
    }
}