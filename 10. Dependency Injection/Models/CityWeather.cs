namespace Models
{
  public class CityWeather
  {
    public string CityCode { get; set; }
    public string CityName { get; set; }
    public DateTime Date { get; set; }
    public int Temperature { get; set; }

    public CityWeather(string cityCode, string cityName, DateTime date, int temperature)
    {
      CityCode = cityCode;
      CityName = cityName;
      Date = date;
      Temperature = temperature;
    }
  }
}
