using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("sayHello")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
