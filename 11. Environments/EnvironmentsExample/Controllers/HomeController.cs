using Microsoft.AspNetCore.Mvc;

namespace EnvironmentsExample.Controllers
{
  public class HomeController : Controller
  {
    private readonly IWebHostEnvironment _webHostEnvironment;

    public HomeController(IWebHostEnvironment webHostEnvironment)
    {
      _webHostEnvironment = webHostEnvironment;
    }

    [Route("/")]
    public IActionResult Index()
    {
      ViewBag.Env = _webHostEnvironment.EnvironmentName;
      return View();
    }
  }
}
