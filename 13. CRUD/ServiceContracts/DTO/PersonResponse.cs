using Entities;

namespace ServiceContracts.DTO
{
  public class PersonResponse
  {
    public Guid PersonID { get; set; }
    public string? PersonName { get; set; }
    public string? Email { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public Guid? CountryID { get; set; }
    public string? Country { get; set; }
    public string? Address { get; set; }
    public bool ReceivesNewsletter { get; set; }
    public double? Age { get; set; }

    public override bool Equals(object? obj)
    {
      PersonResponse? personToCompare = obj as PersonResponse;
      if (personToCompare == null)
      {
        return false;
      }

      return PersonID == personToCompare.PersonID;
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public override string ToString()
    {
      return $"PersonID: {PersonID}\nPersonName: {PersonName}\nEmail: {Email}\nDateOfBirth: {DateOfBirth?.ToString("dd-MMM-yyyy")}\nAge:{Age}\nGender: {Gender}\nCountryID:{CountryID}\nCountry:{Country}\nAddress:{Address}\nReceivesNewsletter:{ReceivesNewsletter}";
    }
  }

  public static class PersonExtensions
  {
    public static PersonResponse ToPersonResponse(this Person person)
    {
      return new PersonResponse()
      {
        PersonID = person.PersonID,
        PersonName = person.PersonName,
        Email = person.Email,
        DateOfBirth = person.DateOfBirth,
        Gender = person.Gender,
        CountryID = person.CountryID,
        Address = person.Address,
        ReceivesNewsletter = person.ReceivesNewsletter,
        Age = (person.DateOfBirth != null) ? Math.Floor((DateTime.Now - person.DateOfBirth.Value).TotalDays / 365.25) : null,
      };
    }
  }
}
