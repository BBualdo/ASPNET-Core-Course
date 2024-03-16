using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using Services;
using Xunit.Abstractions;

namespace CRUDTests
{
  public class PersonServiceTest
  {
    private readonly IPersonService _personService;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly ICountriesService _countriesService;

    public PersonServiceTest(ITestOutputHelper testOutputHelper)
    {
      _personService = new PersonService();
      _testOutputHelper = testOutputHelper;
      _countriesService = new CountriesService();
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
      CountryAddRequest countryAddRequest = new CountryAddRequest()
      {
        CountryName = "Poland"
      };
      CountryResponse country = _countriesService.AddCountry(countryAddRequest);

      List<PersonAddRequest> peopleToAddList = new List<PersonAddRequest>()
      {
        new()
        {
          PersonName = "Sebastian",
          DateOfBirth = new DateTime(2000, 5, 23),
          Gender = GenderOptions.Male,
          ReceivesNewsletter = true,
          Email = "example1@gmail.com",
          CountryID = country.CountryID,
          Address = "Example Address",
        },
        new()
        {
          PersonName = "Asia",
          DateOfBirth = new DateTime(1999, 4, 30),
          Gender = GenderOptions.Female,
          ReceivesNewsletter = false,
          Email = "example2@gmail.com",
          CountryID = country.CountryID,
          Address = "Example Address",
        }
      };

      List<PersonResponse> initialPeopleList = new List<PersonResponse>();
      foreach (PersonAddRequest personToAdd in peopleToAddList)
      {
        PersonResponse addedPerson = _personService.AddPerson(personToAdd);
        initialPeopleList.Add(addedPerson);
      }

      // Printing
      _testOutputHelper.WriteLine("Expected");
      foreach (PersonResponse expectedPerson in initialPeopleList)
      {
        _testOutputHelper.WriteLine(expectedPerson.ToString());
      }

      // Act
      List<PersonResponse> actualPeopleList = _personService.GetAllPeople();

      // Printing
      _testOutputHelper.WriteLine("Actual");
      foreach (PersonResponse actualPerson in actualPeopleList)
      {
        _testOutputHelper.WriteLine(actualPerson.ToString());
      }

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

    #region GetFilteredPeopleTests
    [Fact]
    public void GetFilteredPeople_EmptySearchString()
    {
      // Arrange 
      List<PersonAddRequest> peopleToAdd = new List<PersonAddRequest>() {
        new()
        {
          PersonName = "Sebastian",
          Email = "example@example.com"
        },
        new()
        {
          PersonName = "Asia",
          Email = "example123@example.com"
        }
      };

      foreach (PersonAddRequest personToAdd in peopleToAdd)
      {
        _personService.AddPerson(personToAdd);
      }

      List<PersonResponse> actualPeopleList = _personService.GetAllPeople();

      // Act
      List<PersonResponse> filteredPeopleList = _personService.GetFilteredPeople(nameof(Person.PersonName), "");


      // Assert
      foreach (PersonResponse person in actualPeopleList)
      {
        Assert.Contains(person, filteredPeopleList);
      }
    }

    [Fact]
    public void GetFilteredPeople_ValidParameters()
    {
      // Arrange 
      string searchString = "as";
      List<PersonAddRequest> peopleToAdd = new List<PersonAddRequest>() {
        new()
        {
          PersonName = "Sebastian",
          Email = "example@example.com"
        },
        new()
        {
          PersonName = "Asia",
          Email = "example123@example.com"
        },
        new()
        {
          PersonName = "Bartek",
          Email = "example321@gmail.com"
        }
      };

      foreach (PersonAddRequest personToAdd in peopleToAdd)
      {
        _personService.AddPerson(personToAdd);
      }

      List<PersonResponse> actualPeopleList = _personService.GetAllPeople();

      // Act
      List<PersonResponse> filteredPeopleList = _personService.GetFilteredPeople(nameof(Person.PersonName), searchString);


      // Assert
      foreach (PersonResponse person in actualPeopleList)
      {
        if (person.PersonName != null)
        {
          if (person.PersonName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
          {
            Assert.Contains(person, filteredPeopleList);
          }
        }

      }
    }


    #endregion
  }
}
