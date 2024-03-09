using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace DIExample.Controllers
{
  public class HomeController : Controller
  {
    /* Constructor Injection (used more often)
    private readonly ICitiesService _citiesService;

    public HomeController(ICitiesService citiesService)
    {
      // parameter provided by IoC via Dependency Injection
      _citiesService = citiesService;
    } */


    [Route("/")]
    public IActionResult Index([FromServices] ICitiesService _citiesService)
    {
      List<string> cities = _citiesService.GetCities();
      return View(cities);
    }
  }
}
