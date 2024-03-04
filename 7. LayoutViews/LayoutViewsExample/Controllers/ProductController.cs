using Microsoft.AspNetCore.Mvc;

namespace LayoutViewsExample.Controllers
{
  public class ProductController : Controller
  {
    [Route("products")]
    public IActionResult Index()
    {
      return View();
    }
    [Route("search")]
    public IActionResult Search()
    {
      return View();
    }
    [Route("order")]
    public IActionResult Order()
    {
      return View();
    }
  }
}
