using Microsoft.AspNetCore.Mvc;
using WeatherAppExercise.Models;

namespace WeatherAppExercise.Controllers
{
  public class HomeController : Controller
  {
    [Route("/")]
    public IActionResult Index()
    {
      List<City> cities = new List<City> {
      new City("WWA", "Warszawa", DateTime.Now, 20),
      new City("GDA", "Gdańsk", DateTime.Now, 40),
      new City("KRK", "Krakówek", DateTime.Now, 12),
      };

      return View(cities);
    }

    [Route("details/{id}")]
    public IActionResult Details(string? id)
    {
      if (id == null)
      {
        return Content("The id must be correct value.");
      }

      List<City> cities = new List<City> {
      new City("WWA", "Warszawa", DateTime.Now, 20),
      new City("GDA", "Gdańsk", DateTime.Now, 40),
      new City("KRK", "Krakówek", DateTime.Now, 12),
      };

      City? matchingCity = cities.Where(city => city.UniqueCode == id).FirstOrDefault();

      return View(matchingCity);
    }
  }
}
