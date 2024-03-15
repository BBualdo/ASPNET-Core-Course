using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
  public class PersonService : IPersonService
  {
    private readonly List<Person> _people;

    public PersonService()
    {
      _people = new List<Person>();
    }
    public PersonResponse AddPerson(PersonAddRequest? personAddRequest)
    {
      if (personAddRequest == null)
      {
        throw new ArgumentNullException(nameof(personAddRequest));
      }

      if (personAddRequest.PersonName == null)
      {
        throw new ArgumentException(nameof(personAddRequest.PersonName));
      }

      Person personToAdd = personAddRequest.ToPerson();
      personToAdd.PersonID = Guid.NewGuid();
      _people.Add(personToAdd);

      return personToAdd.ToPersonResponse();
    }

    public List<PersonResponse> GetAllPeople()
    {
      return _people.Select(person => person.ToPersonResponse()).ToList();
    }
  }
}
