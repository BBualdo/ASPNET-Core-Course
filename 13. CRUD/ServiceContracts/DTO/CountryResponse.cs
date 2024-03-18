using Entities;

namespace ServiceContracts.DTO
{
  public class CountryResponse
  {
    public Guid CountryID { get; set; }
    public string? CountryName { get; set; }

    public override bool Equals(object? obj)
    {
      CountryResponse? countryToCompare = obj as CountryResponse;
      if (countryToCompare == null)
      {
        return false;
      }
      return CountryID == countryToCompare.CountryID;
    }

    public override int GetHashCode()
    {
      throw new NotImplementedException();
    }
  }

  public static class CountryExtensions
  {
    public static CountryResponse ToCountryResponse(this Country country)
    {
      return new CountryResponse()
      {
        CountryID = country.CountryID,
        CountryName = country.CountryName,
      };
    }
  }
}
