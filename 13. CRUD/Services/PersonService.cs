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
  }
}
