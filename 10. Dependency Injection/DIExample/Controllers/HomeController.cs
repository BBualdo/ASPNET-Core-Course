using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace DIExample.Controllers
{
  public class HomeController : Controller
  {
    private readonly ICitiesService _citiesService1;
    private readonly ICitiesService _citiesService2;
    private readonly ICitiesService _citiesService3;

    public HomeController(ICitiesService citiesService1, ICitiesService citiesService2, ICitiesService citiesService3)
    {
      // Creating 3 instances of Services Object
      _citiesService1 = citiesService1;
      _citiesService2 = citiesService2;
      _citiesService3 = citiesService3;
    }


    [Route("/")]
    public IActionResult Index()
    {
      List<string> cities = _citiesService1.GetCities();
      ViewBag.id_1 = _citiesService1.ServiceInstanceID;
      ViewBag.id_2 = _citiesService2.ServiceInstanceID;
      ViewBag.id_3 = _citiesService3.ServiceInstanceID;
      return View(cities);
    }
  }
}
