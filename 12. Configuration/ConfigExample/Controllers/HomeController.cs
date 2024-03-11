using Microsoft.AspNetCore.Mvc;

namespace ConfigExample.Controllers
{
  public class HomeController : Controller
  {
    private readonly IConfiguration _configuration;

    public HomeController(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    [Route("/")]
    public IActionResult Index()
    {
      IConfiguration weatherAPI = _configuration.GetSection("WeatherAPI");
      ViewBag.ClientID = _configuration["WeatherAPI:ClientID"];
      // or
      ViewBag.ClientSecret = weatherAPI["ClientSecret"];
      return View();
    }
  }
}
