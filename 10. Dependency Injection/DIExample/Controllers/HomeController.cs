using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace DIExample.Controllers
{
  public class HomeController : Controller
  {
    private readonly ICitiesService _citiesService1;
    private readonly ICitiesService _citiesService2;
    private readonly ICitiesService _citiesService3;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public HomeController(ICitiesService citiesService1, ICitiesService citiesService2, ICitiesService citiesService3, IServiceScopeFactory serviceScopeFactory)
    {
      // Creating 3 instances of Services Object
      _citiesService1 = citiesService1;
      _citiesService2 = citiesService2;
      _citiesService3 = citiesService3;
      _serviceScopeFactory = serviceScopeFactory;
    }


    [Route("/")]
    public IActionResult Index()
    {
      List<string> cities = _citiesService1.GetCities();
      ViewBag.id_1 = _citiesService1.ServiceInstanceID;
      ViewBag.id_2 = _citiesService2.ServiceInstanceID;
      ViewBag.id_3 = _citiesService3.ServiceInstanceID;

      using (IServiceScope scope = _serviceScopeFactory.CreateScope())
      {
        // Injecting Service
        ICitiesService citiesService = scope.ServiceProvider.GetRequiredService<ICitiesService>();
        // DB work
        ViewBag.ID_from_child_scope = citiesService.ServiceInstanceID;
      } // end of child scope, CitiesService.Dispose() executes automatically and it disposes of scope and everything inside

      return View(cities);
    }
  }
}
