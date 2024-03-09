using Models;

namespace ServiceContracts
{
  public interface IWeatherService
  {
    List<CityWeather> GetWeather();
  }
}
