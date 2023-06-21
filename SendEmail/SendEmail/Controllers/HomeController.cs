using Microsoft.AspNetCore.Mvc;
using SendEmail.Models;
using System.Diagnostics;

namespace SendEmail.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult GetMailAccess() {
            Dictionary<string, string> mail_access = new Dictionary<string, string>()
            {
                { "mail_driver", DotNetEnv.Env.GetString("MAIL_DRIVER")},
                { "mail_token", DotNetEnv.Env.GetString("MAIL_TOKEN") },
                { "mail_port", DotNetEnv.Env.GetString("MAIL_PORT")},
                { "mail_encryption", DotNetEnv.Env.GetString("MAIL_ENCRYPTION")},
                { "mail_token", DotNetEnv.Env.GetString("MAIL_TOKEN")},
                { "api_mail_from_address", DotNetEnv.Env.GetString("API_MAIL_FROM_ADDRESS")},
            };

            return Json(mail_access);
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}