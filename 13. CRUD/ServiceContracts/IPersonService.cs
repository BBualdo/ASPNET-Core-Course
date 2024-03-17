using ServiceContracts.DTO;
using ServiceContracts.Enums;

namespace ServiceContracts
{
  public interface IPersonService
  {
    PersonResponse AddPerson(PersonAddRequest? personAddRequest);
    List<PersonResponse> GetAllPeople();
    PersonResponse? GetPersonById(Guid? personID);
    List<PersonResponse> GetFilteredPeople(string searchBy, string? searchString);
    List<PersonResponse> GetSortedPeople(List<PersonResponse> allPeople, string sortBy, SortOrderOptions sortOrder);

    PersonResponse UpdatePerson(PersonUpdateRequest? personUpdateRequest);
  }
}
