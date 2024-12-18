using Microsoft.AspNetCore.Mvc;

namespace Gimnasio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EntrenadorHome()
        {
            return View();
        }

        public IActionResult ClienteHome()
        {
            return View();
        }
    }
}
