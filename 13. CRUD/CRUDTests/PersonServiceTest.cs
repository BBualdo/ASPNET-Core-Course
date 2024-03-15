using ServiceContracts;
using ServiceContracts.DTO;
using Services;

namespace CRUDTests
{
  public class PersonServiceTest
  {
    private readonly IPersonService _personService;

    public PersonServiceTest()
    {
      _personService = new PersonService();
    }

    [Fact]
    public void AddPerson_NullPerson()
    {
      // Arrange
      PersonAddRequest? personToAdd = null;

      // Assert
      Assert.Throws<ArgumentNullException>(() =>
      {
        // Act
        _personService.AddPerson(personToAdd);
      });
    }

    [Fact]
    public void AddPerson_NoNamePerson()
    {
      // Arrange
      PersonAddRequest personToAdd = new PersonAddRequest()
      {
        PersonName = null
      };

      // Assert
      Assert.Throws<ArgumentException>(() =>
      {
        // Act
        _personService.AddPerson(personToAdd);
      });
    }

    [Fact]
    public void AddPerson_CorrectPerson()
    {
      // Arrange
      PersonAddRequest personToAdd = new PersonAddRequest()
      {
        PersonName = "Sebastian",
        DateOfBirth = new DateTime(2000, 5, 23),
        ReceivesNewsletter = true,
        Address = "Example 23, 32-426 Atlantis"
      };

      // Act
      PersonResponse addedPerson = _personService.AddPerson(personToAdd);

      // Assert
      Assert.True(addedPerson.PersonID != Guid.Empty);
    }
  }
}
