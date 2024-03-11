using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigExample.Controllers
{
  public class HomeController : Controller
  {
    private readonly WeatherAPIOptions _options;

    public HomeController(IOptions<WeatherAPIOptions> options)
    {
      _options = options.Value;
    }

    [Route("/")]
    public IActionResult Index()
    {
      ViewBag.ClientID = _options.ClientID;
      ViewBag.ClientSecret = _options.ClientSecret;
      return View();
    }
  }
}
