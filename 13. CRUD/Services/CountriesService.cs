﻿using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
  public class CountriesService : ICountriesService
  {
    private readonly List<Country> _countries;

    public CountriesService()
    {
      _countries = new List<Country>();
    }

    public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
    {
      // Validation: Request can't be null
      if (countryAddRequest == null)
      {
        throw new ArgumentNullException(nameof(countryAddRequest));
      }
      // Validation: CountryName can't be null
      if (countryAddRequest.CountryName == null)
      {
        throw new ArgumentException(nameof(countryAddRequest.CountryName));
      }

      if (_countries.Where(country => country.CountryName == countryAddRequest.CountryName).Count() > 0)
      {
        throw new ArgumentException("Country already exists.");
      }
      // Converting request to Country Object
      Country country = countryAddRequest.ToCountry();

      // Adding CountryID
      country.CountryID = Guid.NewGuid();

      // Add country to "Database"
      _countries.Add(country);

      // Return CountryResponse
      return country.ToCountryResponse();
    }

    public List<CountryResponse> GetAllCountries()
    {
      return _countries.Select(country => country.ToCountryResponse()).ToList();
    }
    public CountryResponse? GetCountryById(Guid? id)
    {
      if (id == null)
      {
        return null;
      }

      Country? matchingCountry = _countries.FirstOrDefault(country => country.CountryID == id);

      if (matchingCountry == null)
      {
        return null;
      }

      return matchingCountry.ToCountryResponse();
    }
  }
}
