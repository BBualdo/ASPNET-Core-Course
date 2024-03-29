﻿using ServiceContracts;

namespace Services
{
  public class CitiesService : ICitiesService, IDisposable
  {
    private List<string> _citites;
    private Guid _id;
    public Guid ServiceInstanceID
    {
      get
      {
        return _id;
      }
    }

    public CitiesService()
    {
      // DB open connection
      _id = Guid.NewGuid();
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

    public void Dispose()
    {
      // DB close connection
    }
  }
}
