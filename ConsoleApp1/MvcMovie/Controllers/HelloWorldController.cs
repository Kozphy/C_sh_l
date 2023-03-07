using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
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
        public string Welcome(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        }

        public string Welcome2(string name, int id = 1){
            return HtmlEncoder.Default.Encode($"Hello {name}, Id: {id}");
        }
    }
}