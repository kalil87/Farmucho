using Microsoft.AspNetCore.Mvc;

namespace Farmucho.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
