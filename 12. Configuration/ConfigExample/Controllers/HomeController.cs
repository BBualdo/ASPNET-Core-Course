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
      IConfiguration weatherAPISection = _configuration.GetSection("WeatherAPI");

      // GET: Loads config values into a new Options object
      WeatherAPIOptions? options = weatherAPISection.Get<WeatherAPIOptions>();

      // BIND: Load config values into an existing Option object
      //WeatherAPIOptions options = new WeatherAPIOptions();
      //weatherAPISection.Bind(options);

      ViewBag.ClientID = options?.ClientID;
      ViewBag.ClientSecret = options?.ClientSecret;
      return View();
    }
  }
}
