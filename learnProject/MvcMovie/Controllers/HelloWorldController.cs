using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System;
using Microsoft.Extensions.Configuration;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        private readonly IConfiguration Configuration;
        public HelloWorldController(IConfiguration configuration){
            this.Configuration = configuration;
        }
         public ContentResult OnGet()
        {
            var mylaptop = Configuration["laptop"];

            return Content($"Mylaptop value: {mylaptop} \n");
        }

        public IConfiguration Configuration1 => Configuration;

        // GET: /HelloWorld/
        public IActionResult Index()
        {
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine(path);
            return View();
            // return "This is my default action...";
        }

        // 
        // GET: /HelloWorld/Welcome/ 
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;
            // return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
            return View();
        }

        public string Welcome2(string name, int id = 1){
            return HtmlEncoder.Default.Encode($"Hello {name}, Id: {id}");
        }
    }
}