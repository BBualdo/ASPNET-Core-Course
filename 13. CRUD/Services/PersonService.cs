using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using Services.Helpers;

namespace Services
{
  public class PersonService : IPersonService
  {
    private readonly List<Person> _people;
    private readonly ICountriesService _countriesService;

    public PersonService()
    {
      _people = new List<Person>();
      _countriesService = new CountriesService();
    }

    private PersonResponse ConvertPersonToPersonResponse(Person person)
    {
      PersonResponse personResponse = person.ToPersonResponse();
      personResponse.Country = _countriesService.GetCountryById(personResponse.CountryID)?.CountryName;

      return personResponse;
    }

    public PersonResponse AddPerson(PersonAddRequest? personAddRequest)
    {
      if (personAddRequest == null)
      {
        throw new ArgumentNullException(nameof(personAddRequest));
      }

      // Model validation
      ValidationHelper.ModelValidation(personAddRequest);

      Person personToAdd = personAddRequest.ToPerson();
      personToAdd.PersonID = Guid.NewGuid();
      _people.Add(personToAdd);

      return ConvertPersonToPersonResponse(personToAdd);
    }

    public List<PersonResponse> GetAllPeople()
    {
      return _people.Select(person => person.ToPersonResponse()).ToList();
    }

    public PersonResponse? GetPersonById(Guid? personID)
    {
      if (personID == null)
      {
        return null;
      }

      Person? person = _people.FirstOrDefault(person => person.PersonID == personID);
      if (person == null)
      {
        return null;
      }
      return person.ToPersonResponse();
    }

    public List<PersonResponse> GetFilteredPeople(string searchBy, string? searchString)
    {
      List<PersonResponse> allPeople = GetAllPeople();
      List<PersonResponse> filteredPeople = allPeople;

      if (string.IsNullOrEmpty(searchString) || string.IsNullOrEmpty(searchBy))
      {
        return filteredPeople;
      }

      switch (searchBy)
      {
        case nameof(Person.PersonName):
          filteredPeople = allPeople.Where(person =>
          !string.IsNullOrEmpty(person.PersonName) ?
          person.PersonName.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true).ToList();
          break;
        case nameof(Person.Email):
          filteredPeople = allPeople.Where(person =>
          !string.IsNullOrEmpty(person.Email) ?
          person.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true).ToList();
          break;
        case nameof(Person.Address):
          filteredPeople = allPeople.Where(person =>
          !string.IsNullOrEmpty(person.Address) ?
          person.Address.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true).ToList();
          break;
        case nameof(Person.DateOfBirth):
          filteredPeople = allPeople.Where(person =>
          person.DateOfBirth != null ?
          person.DateOfBirth.Value.ToString("dd MMMM yyyy").Contains(searchString, StringComparison.OrdinalIgnoreCase) : true).ToList();
          break;
        case nameof(Person.CountryID):
          filteredPeople = allPeople.Where(person =>
          !string.IsNullOrEmpty(person.Country) ?
          person.Country.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true).ToList();
          break;
        case nameof(Person.Gender):
          filteredPeople = allPeople.Where(person =>
          !string.IsNullOrEmpty(person.Gender) ?
          person.Gender.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true).ToList();
          break;
        default: filteredPeople = allPeople; break;
      }

      return filteredPeople;
    }
  }
}
