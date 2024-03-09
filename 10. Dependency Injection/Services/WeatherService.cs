using Models;
using ServiceContracts;

namespace Services
{
  public class WeatherService : IWeatherService
  {
    private readonly List<CityWeather> _cityWeathers;
    public WeatherService()
    {
      _cityWeathers = new List<CityWeather>()
        {
          new CityWeather("NY", "New York", DateTime.Now, 21),
          new CityWeather("LDN", "London", DateTime.Now, 14),
          new CityWeather("WWA", "Warszawa", DateTime.Now, 35),
          new CityWeather("ATH", "Athenas", DateTime.Now, 42)
        };
    }

    public List<CityWeather> GetWeather()
    {
      return _cityWeathers;
    }
  }
}
