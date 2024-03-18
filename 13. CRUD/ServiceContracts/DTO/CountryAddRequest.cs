using Entities;

namespace ServiceContracts.DTO
{
  public class CountryAddRequest
  {
    public string? CountryName { get; set; }

    /// <summary>
    /// Method that converts currently adding Country into Country Model Object
    /// </summary>
    /// <returns>Country object with same name as CountryAddRequest</returns>
    public Country ToCountry()
    {
      return new Country { CountryName = CountryName };
    }
  }
}
