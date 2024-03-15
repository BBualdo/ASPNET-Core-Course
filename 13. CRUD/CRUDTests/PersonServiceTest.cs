using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
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

    #region AddPersonTests
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
        Address = "Example 23, 32-426 Atlantis",
        Email = "example1@gmail.com"
      };

      // Act
      PersonResponse addedPerson = _personService.AddPerson(personToAdd);
      List<PersonResponse> peopleList = _personService.GetAllPeople();

      // Assert
      Assert.True(addedPerson.PersonID != Guid.Empty);
      Assert.Contains(addedPerson, peopleList);
    }
    #endregion

    #region GetAllPeopleTests
    [Fact]
    public void GetAllPeople_EmptyList()
    {
      // Arrange
      List<PersonResponse> peopleList = new List<PersonResponse>();
      // Act
      _personService.GetAllPeople();
      // Assert
      Assert.Empty(peopleList);
    }

    [Fact]
    public void GetAllPeople_ContainingPeople()
    {
      // Arrange
      List<PersonAddRequest> peopleToAddList = new List<PersonAddRequest>()
      {
        new()
        {
          PersonName = "Sebastian",
          DateOfBirth = new DateTime(2000, 5, 23),
          Gender = GenderOptions.Male,
          ReceivesNewsletter = true,
          Email = "example1@gmail.com"
        },
        new()
        {
          PersonName = "Asia",
          DateOfBirth = new DateTime(1999, 4, 30),
          Gender = GenderOptions.Female,
          ReceivesNewsletter = false,
          Email = "example2@gmail.com"
        }
      };

      List<PersonResponse> initialPeopleList = new List<PersonResponse>();

      // Act
      foreach (PersonAddRequest personToAdd in peopleToAddList)
      {
        PersonResponse addedPerson = _personService.AddPerson(personToAdd);
        initialPeopleList.Add(addedPerson);
      }

      List<PersonResponse> actualPeopleList = _personService.GetAllPeople();

      foreach (PersonResponse expectedPerson in initialPeopleList)
      {
        // Assert
        Assert.Contains(expectedPerson, actualPeopleList);
      }
    }

    #endregion

    #region GetPersonByIdTests
    [Fact]
    public void GetPersonById_NullID()
    {
      // Arrange
      Guid? id = null;
      // Act
      PersonResponse? wantedPerson = _personService.GetPersonById(id);
      // Assert
      Assert.Null(wantedPerson);
    }

    [Fact]
    public void GetPersonById_ValidPersonID()
    {
      // Arrange
      PersonAddRequest personToAdd = new()
      {
        PersonName = "Sebastian",
        DateOfBirth = new DateTime(2000, 5, 23),
        Email = "example@example.com",
      };

      List<PersonResponse> initialPeopleList = new List<PersonResponse>();

      PersonResponse addedPerson = _personService.AddPerson(personToAdd);
      initialPeopleList.Add(addedPerson);
      // Act
      PersonResponse? wantedPerson = _personService.GetPersonById(addedPerson.PersonID);
      // Assert
      Assert.Contains(wantedPerson, initialPeopleList);
    }
    #endregion
  }
}
