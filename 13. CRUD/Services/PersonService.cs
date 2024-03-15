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
      throw new NotImplementedException();
    }
  }
}
