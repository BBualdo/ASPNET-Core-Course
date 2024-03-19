using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
  public class CountriesService : ICountriesService
  {
    private readonly List<Country> _countries;

    public CountriesService(bool initialize = true)
    {
      _countries = new List<Country>();
      if (initialize)
      {
        _countries.AddRange(new List<Country>()
        {
          new()
          {
            CountryID = Guid.Parse("701FB56A-EBA3-4789-959B-2343183B5520"),
            CountryName = "Poland",
          },
          new()
          {
            CountryID = Guid.Parse("563E7512-CC28-48E6-98DF-059F93CCF8F0"),
            CountryName = "Greece",
          },
          new()
          {
            CountryID = Guid.Parse("B761FA29-9487-4103-A415-D916A4908668"),
            CountryName = "USA",
          },
          new()
          {
            CountryID = Guid.Parse("149D25BB-2067-4D82-BCAA-E4C57EFE6311"),
            CountryName = "Japan",
          },
          new()
          {
            CountryID = Guid.Parse("05FB4E5B-0CAE-42CD-801F-1E0263A0571A"),
            CountryName = "Brasil",
          }
        });
      }
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
