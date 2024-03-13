using ServiceContracts;
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

      Assert.True(response.CountryID != Guid.Empty);
    }
  }
}
