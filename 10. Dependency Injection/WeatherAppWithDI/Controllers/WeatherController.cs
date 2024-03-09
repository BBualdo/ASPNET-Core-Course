using Microsoft.AspNetCore.Mvc;
using Models;
using ServiceContracts;

namespace WeatherAppWithDI.Controllers
{
  public class WeatherController : Controller
  {
    private readonly IWeatherService _weatherService;
    public WeatherController(IWeatherService weatherService)
    {
      _weatherService = weatherService;
    }

    [Route("weather")]
    public IActionResult Weather()
    {
      List<CityWeather> cityWeatherList = _weatherService.GetWeather();
      return View(cityWeatherList);
    }

    [Route("weather/details/{id?}")]
    public IActionResult Details(string id)
    {
      CityWeather cityWeather = _weatherService.GetWeather().Where(city => city.CityCode == id).FirstOrDefault()!;
      return View(cityWeather);
    }
  }
}
