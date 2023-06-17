using Microsoft.AspNetCore.Mvc;

namespace mvc_api.Controllers
{
    public class ActionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[Route("api/[controller]")]
        //[ApiController]
        //public class ArticleController : ControllerBase
        //{
        //    private readonly BlogContext _context;

        //    public ArticleController(Blo)
        //}
    }
}
