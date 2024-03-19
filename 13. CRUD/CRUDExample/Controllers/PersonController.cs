using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;

namespace CRUDExample.Controllers
{
  public class PersonController : Controller
  {
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
      _personService = personService;
    }

    [Route("/people/index")]
    [Route("/")]
    public IActionResult Index(string searchBy, string searchString)
    {
      ViewBag.SearchFields = new Dictionary<string, string>()
      {
        { nameof(PersonResponse.PersonName), "Person Name" },
        { nameof(PersonResponse.Email), "Email" },
        { nameof(PersonResponse.DateOfBirth), "Date of Birth" },
        { nameof(PersonResponse.Gender), "Gender" },
        { nameof(PersonResponse.CountryID), "Country" },
        { nameof(PersonResponse.Address), "Address" }
      };

      // Preventing fields from reseting
      ViewBag.SearchBy = searchBy;
      ViewBag.SearchString = searchString;

      List<PersonResponse> peopleList = _personService.GetFilteredPeople(searchBy, searchString);
      return View(peopleList);
    }
  }
}
