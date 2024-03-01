using Microsoft.AspNetCore.Mvc;

namespace ViewsExample.Controllers
{
  public class HomeController : Controller
  {
    [Route("home")]
    public IActionResult Index()
    {
      return View(); // searches for Views/Home/Index.cshtml
    }
  }
}
