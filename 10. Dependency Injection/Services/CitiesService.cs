namespace Services
{
  public class CitiesService
  {
    private List<string> _citites;

    public CitiesService()
    {
      _citites = new List<string>() {
      "New York",
      "Tokyo",
      "Warsaw",
      "Toronto",
      "Valencia"
      };
    }

    public List<string> GetCities()
    {
      return _citites;
    }

  }
}
