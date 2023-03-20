using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;

public class ProductsController : Controller
{
    public IActionResult Details(int id)
    {
        return ControllerContext.MyDisplayRouteInfo(id);
    }

}