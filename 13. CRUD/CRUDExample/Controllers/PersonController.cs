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
    public IActionResult Index()
    {
      List<PersonResponse> peopleList = _personService.GetAllPeople();
      return View(peopleList);
    }
  }
}
