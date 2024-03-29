﻿using ServiceContracts;
using ServiceContracts.DTO;
using Services;

namespace CRUDTests
{
  public class CountriesServiceTest
  {
    private readonly ICountriesService _countriesService;
    public CountriesServiceTest(/*DI Not supported by default*/)
    {
      _countriesService = new CountriesService();
    }

    #region AddCountryTests
    // When CountriesAddRequest is null, throw ArgumentNullException
    [Fact]
    public void AddCountry_NullCountry()
    {
      // 1. Arrange
      CountryAddRequest? countryAddRequest = null;

      // 3. Assert
      Assert.Throws<ArgumentNullException>(() =>
      {
        // 2. Act
        _countriesService.AddCountry(countryAddRequest);
      });

    }

    // When CountryName is null, throw ArgumentException
    [Fact]
    public void AddCountry_NullName()
    {
      CountryAddRequest? countryAddRequest = new()
      {
        CountryName = null,
      };

      Assert.Throws<ArgumentException>(() =>
      {
        _countriesService.AddCountry(countryAddRequest);
      });
    }

    // When CountryName is duplicate, throw ArgumentException
    [Fact]
    public void AddCountry_DuplicateName()
    {
      CountryAddRequest? countryAddRequest1 = new() { CountryName = "Poland" };
      CountryAddRequest? countryAddRequest2 = new() { CountryName = "Poland" };

      Assert.Throws<ArgumentException>(() =>
      {
        _countriesService.AddCountry(countryAddRequest1);
        _countriesService.AddCountry(countryAddRequest2);
      });
    }

    // When CountryName is OK, it should insert the country to the existing countries list
    [Fact]
    public void AddCountry_CorrectCountryDetails()
    {
      CountryAddRequest? countryAddRequest = new() { CountryName = "Greece" };

      CountryResponse response = _countriesService.AddCountry(countryAddRequest);
      List<CountryResponse> countriesList = _countriesService.GetAllCountries();

      Assert.True(response.CountryID != Guid.Empty);
      Assert.Contains(response, countriesList);
    }

    #endregion

    #region GetAllCountriesTests

    // Default: Should return empty list by default (when not countries inside)

    [Fact]
    public void GetAllCountries_EmptyList()
    {
      List<CountryResponse> countries = _countriesService.GetAllCountries();

      Assert.Empty(countries);
    }

    // List is setup with few country instances
    [Fact]
    public void GetAllCountries_AddFewCountries()
    {
      List<CountryAddRequest> countriesToAdd = new List<CountryAddRequest>() {
      new()
      {
        CountryName = "USA",
      },
      new()
      {
        CountryName = "Poland"
      },
      new()
      {
        CountryName = "Japan"
      }
      };

      List<CountryResponse> initialCountriesList = new List<CountryResponse>();

      foreach (CountryAddRequest countryToAdd in countriesToAdd)
      {
        CountryResponse addedCountry = _countriesService.AddCountry(countryToAdd);
        initialCountriesList.Add(addedCountry);
      }

      List<CountryResponse> actualCountriesList = _countriesService.GetAllCountries();

      foreach (CountryResponse expectedCountry in initialCountriesList)
      {
        Assert.Contains(expectedCountry, actualCountriesList);
      }
    }

    #endregion

    #region GetCountryByIdTests

    // When Country ID is null
    [Fact]
    public void GetCountryById_NullID()
    {
      // Arrange
      Guid? id = null;

      // Act
      CountryResponse? countryResponse = _countriesService.GetCountryById(id);

      // Assert
      Assert.Null(countryResponse);
    }

    // When country ID is not null
    [Fact]
    public void GetCountryById_ValidCountryID()
    {
      // Arrange
      CountryAddRequest? countryToAdd = new CountryAddRequest() { CountryName = "Spain" };
      CountryResponse addedCountry = _countriesService.AddCountry(countryToAdd);
      // Act
      CountryResponse? wantedCountry = _countriesService.GetCountryById(addedCountry.CountryID);

      // Assert
      Assert.Equal(wantedCountry, addedCountry);
    }
    #endregion
  }
}
