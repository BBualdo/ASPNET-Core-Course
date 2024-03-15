using Entities;
using ServiceContracts.Enums;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
  public class PersonAddRequest
  {
    [Required(ErrorMessage = "Person name can't be empty.")]
    public string? PersonName { get; set; }
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email adress.")]
    public string? Email { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public GenderOptions? Gender { get; set; }
    public Guid? CountryID { get; set; }
    public string? Address { get; set; }
    public bool ReceivesNewsletter { get; set; }

    public Person ToPerson()
    {
      return new Person()
      {
        PersonName = PersonName,
        Email = Email,
        DateOfBirth = DateOfBirth,
        Gender = Gender.ToString(),
        CountryID = CountryID,
        Address = Address,
        ReceivesNewsletter = ReceivesNewsletter
      };
    }
  }
}
