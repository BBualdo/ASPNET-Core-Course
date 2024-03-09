using Microsoft.AspNetCore.Mvc;

namespace WeatherAppWithDI.Controllers
{
  public class HomeController : Controller
  {
    [Route("/")]
    public IActionResult Index()
    {
      return View();
    }
  }
}
