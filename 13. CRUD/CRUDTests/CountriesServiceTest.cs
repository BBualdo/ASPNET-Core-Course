﻿using ServiceContracts;

namespace CRUDTests
{
  public class CountriesServiceTest
  {
    private readonly ICountriesService _countriesService;
    public CountriesServiceTest(ICountriesService countriesService)
    {
      _countriesService = countriesService;
    }
  }
}
