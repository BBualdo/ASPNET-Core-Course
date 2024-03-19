using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using Services.Helpers;

namespace Services
{
  public class PersonService : IPersonService
  {
    private readonly List<Person> _people;
    private readonly ICountriesService _countriesService;

    public PersonService(bool initialize = true)
    {
      _people = new List<Person>();
      _countriesService = new CountriesService(true);

      if (initialize)
      {
        _people.AddRange(new List<Person>()
        {
          new()
          {
            PersonID = Guid.Parse("D0EA7974-3528-45B1-BB26-B4470965BB74"),
            PersonName = "Sebastian",
            Email = "seba@gmail.com",
            Address = "29th Street 42-322",
            DateOfBirth = DateTime.Parse("2000-05-23"),
            Gender = GenderOptions.Male.ToString(),
            CountryID = Guid.Parse("701FB56A-EBA3-4789-959B-2343183B5520"),
            ReceivesNewsletter = true,
          },
          new()
          {
            PersonID = Guid.Parse("F8720A77-7865-46CB-A2DF-D547F0557FE7"),
            PersonName = "Asia",
            Email = "asia@gmail.com",
            Address = "29th Street 42-322",
            DateOfBirth = DateTime.Parse("1999-04-30"),
            Gender = GenderOptions.Female.ToString(),
            CountryID = Guid.Parse("701FB56A-EBA3-4789-959B-2343183B5520"),
            ReceivesNewsletter = true,
          },
          new()
          {
            PersonID = Guid.Parse("30C70311-9272-4427-AAE2-863DC32DF75F"),
            PersonName = "Apollo",
            Email = "delta@gmail.com",
            Address = "St.Antonio 23134",
            DateOfBirth = DateTime.Parse("1986-04-13"),
            Gender = GenderOptions.Male.ToString(),
            CountryID = Guid.Parse("563E7512-CC28-48E6-98DF-059F93CCF8F0"),
            ReceivesNewsletter = true,
          },
          new()
          {
            PersonID = Guid.Parse("135BF584-87DF-4559-B1CC-FE1956057B24"),
            PersonName = "John",
            Email = "johndoe@example.com",
            Address = "2nd Redneck Street 24, 42573",
            DateOfBirth = DateTime.Parse("1970-07-31"),
            Gender = GenderOptions.Male.ToString(),
            CountryID = Guid.Parse("B761FA29-9487-4103-A415-D916A4908668"),
            ReceivesNewsletter = false,
          },
          new()
          {
            PersonID = Guid.Parse("82B47DC2-5EE2-4AA3-BC36-D43DBE2A9B81"),
            PersonName = "Naruto",
            Email = "ilovesasuke@dattebayo.jp",
            Address = "Konoha",
            DateOfBirth = DateTime.Parse("1990-10-10"),
            Gender = GenderOptions.Male.ToString(),
            CountryID = Guid.Parse("149D25BB-2067-4D82-BCAA-E4C57EFE6311"),
            ReceivesNewsletter = true,
          },
          new()
          {
            PersonID = Guid.Parse("050FEAE3-B5DC-4B3D-B37F-5BB9A99A590C"),
            PersonName = "Luis Antonio de Lamosa Ramirez",
            Email = "wontrepeatthat@gmail.com",
            Address = "Rio De Janeiro 23, 52511",
            DateOfBirth = DateTime.Parse("2005-12-03"),
            Gender = GenderOptions.Other.ToString(),
            CountryID = Guid.Parse("05FB4E5B-0CAE-42CD-801F-1E0263A0571A"),
            ReceivesNewsletter = false,
          }
        });
      }
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

    public List<PersonResponse> GetSortedPeople(List<PersonResponse> allPeople, string sortBy, SortOrderOptions sortOrder)
    {
      {

        if (string.IsNullOrEmpty(sortBy))
        {
          return allPeople;
        }

        List<PersonResponse> sortedPeople = (sortBy, sortOrder) switch
        {
          (nameof(Person.PersonName), SortOrderOptions.Ascending) =>
          allPeople.OrderBy(person => person.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),
          (nameof(Person.PersonName), SortOrderOptions.Descending) =>
          allPeople.OrderByDescending(person => person.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

          (nameof(Person.Email), SortOrderOptions.Ascending) =>
          allPeople.OrderBy(person => person.Email, StringComparer.OrdinalIgnoreCase).ToList(),
          (nameof(Person.Email), SortOrderOptions.Descending) =>
          allPeople.OrderByDescending(person => person.Email, StringComparer.OrdinalIgnoreCase).ToList(),

          (nameof(Person.CountryID), SortOrderOptions.Ascending) =>
          allPeople.OrderBy(person => person.Country, StringComparer.OrdinalIgnoreCase).ToList(),
          (nameof(Person.CountryID), SortOrderOptions.Descending) =>
          allPeople.OrderByDescending(person => person.Country, StringComparer.OrdinalIgnoreCase).ToList(),

          (nameof(Person.Gender), SortOrderOptions.Ascending) =>
          allPeople.OrderBy(person => person.Gender, StringComparer.OrdinalIgnoreCase).ToList(),
          (nameof(Person.Gender), SortOrderOptions.Descending) =>
          allPeople.OrderByDescending(person => person.Gender, StringComparer.OrdinalIgnoreCase).ToList(),

          (nameof(Person.DateOfBirth), SortOrderOptions.Ascending) =>
          allPeople.OrderBy(person => person.DateOfBirth).ToList(),
          (nameof(Person.DateOfBirth), SortOrderOptions.Descending) =>
          allPeople.OrderByDescending(person => person.DateOfBirth).ToList(),

          (nameof(Person.Address), SortOrderOptions.Ascending) =>
          allPeople.OrderBy(person => person.Address, StringComparer.OrdinalIgnoreCase).ToList(),
          (nameof(Person.Address), SortOrderOptions.Descending) =>
          allPeople.OrderByDescending(person => person.Address, StringComparer.OrdinalIgnoreCase).ToList(),

          (nameof(PersonResponse.Age), SortOrderOptions.Ascending) =>
          allPeople.OrderBy(person => person.Age).ToList(),
          (nameof(PersonResponse.Age), SortOrderOptions.Descending) =>
          allPeople.OrderByDescending(person => person.Age).ToList(),

          (nameof(PersonResponse.ReceivesNewsletter), SortOrderOptions.Ascending) =>
          allPeople.OrderBy(person => person.ReceivesNewsletter).ToList(),
          (nameof(PersonResponse.ReceivesNewsletter), SortOrderOptions.Descending) =>
          allPeople.OrderByDescending(person => person.ReceivesNewsletter).ToList(),

          _ => allPeople
        };

        return sortedPeople;
      }
    }

    public PersonResponse UpdatePerson(PersonUpdateRequest? personUpdateRequest)
    {
      if (personUpdateRequest == null)
      {
        throw new ArgumentNullException(nameof(personUpdateRequest));
      }

      ValidationHelper.ModelValidation(personUpdateRequest);

      Person? foundPerson = _people.FirstOrDefault(person => person.PersonID == personUpdateRequest.PersonID);

      if (foundPerson == null)
      {
        throw new ArgumentException("Person not found");
      }

      Person convertedPersonRequest = personUpdateRequest.ToPerson();

      foundPerson = convertedPersonRequest;

      return foundPerson.ToPersonResponse();
    }

    public bool DeletePerson(Guid? personID)
    {
      if (personID == null)
      {
        throw new ArgumentNullException(nameof(personID));
      }

      Person? personToDelete = _people.FirstOrDefault(person => person.PersonID == personID);

      if (personToDelete == null)
      {
        return false;
      }

      _people.Remove(personToDelete);

      return true;
    }
  }
}
