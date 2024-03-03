namespace WeatherAppExercise.Models
{
  public class City
  {
    public string UniqueCode { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public int TemperatureCelcius { get; set; }

    public City(string uniqueCode, string name, DateTime date, int temperatureCelcius)
    {
      UniqueCode = uniqueCode;
      Name = name;
      Date = date;
      TemperatureCelcius = temperatureCelcius;
    }
  }
}
