using ServiceContracts.DTO;

namespace ServiceContracts
{
  public interface IPersonService
  {
    PersonResponse AddPerson(PersonAddRequest? personAddRequest);
    List<PersonResponse> GetAllPeople();
    PersonResponse? GetPersonById(Guid? personID);
  }
}
