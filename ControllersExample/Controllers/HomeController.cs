using Microsoft.AspNetCore.Mvc;
using ControllersExample.Models;

namespace ControllersExample.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        [Route("/")]
        public ContentResult Index()
        {
            //return Content("Hello from Index", "text/plain");
            //return new ContentResult() {
            //    Content="Hello from Index", 
            //    ContentType="text/plain"
            //};
            return Content("<h1>Welcome</h1>", "text/html");
        }

        [Route("About")]
        public string About()
        {
            return "Hello from About";
        }

        [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]
        public string Contact()
        {
            return "Hello from Contact";
        }

        [Route("person")]
        public JsonResult Person() 
        { 
            Person person = new Person() { 
                Id=Guid.NewGuid(),
                FirstName = "James",
                LastName = "Smith",
                Age = 25
            };

            return new JsonResult(person);
        }

        [Route("file-download")]
        public VirtualFileResult FileDownload()
        {
            return new VirtualFileResult("/sample.pdf", "application/pdf");
        }

        [Route("file-download2")]
        public PhysicalFileResult FileDownload2()
        {
            return new PhysicalFileResult(@"C:\Users\dbdf0\source\repos\C_sh_l\ControllersExample\wwwroot\Sample.pdf", "application/pdf");
        }

        [Route("file-download3")]
        public IActionResult FileDownload3() 
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\dbdf0\source\repos\C_sh_l\ControllersExample\wwwroot\Sample.pdf");
            return new FileContentResult(bytes, "application/pdf");
        }

    }
}
