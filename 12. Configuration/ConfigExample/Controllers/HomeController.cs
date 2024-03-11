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

    [Route("config")]
    public IActionResult Index()
    {
      ViewBag.Config = _configuration.GetValue<string>("MyKey");
      return View();
    }
  }
}
