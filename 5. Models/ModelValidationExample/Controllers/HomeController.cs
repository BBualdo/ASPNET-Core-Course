using Microsoft.AspNetCore.Mvc;
using ModelValidationExample.Models;

namespace ModelValidationExample.Controllers
{
  public class HomeController : Controller
  {
    [Route("register")]
    // Postman: POST > Body > Raw (XML) =
    /* <Person>
         <Name>BBualdo</Name>
         <Email>bbualdo@example.com</Email>
         <Age>24</Age>
       </Person>
    */


    // [ModelBinder(typeof(PersonModelBinder))]
    public IActionResult Index(Person person, [FromHeader(Name = "User-Agent")] string UserAgent)
    {
      // ModelState contains properties like IsValid, Values or ErrorCount. We can use them for validation.

      if (!ModelState.IsValid)
      {
        //List<string> errorList = new List<string>();
        //foreach (var value in ModelState.Values)
        //{
        //  foreach (var error in value.Errors)
        //  {
        //    errorList.Add(error.ErrorMessage);
        //  }
        //}

        // same using LINQ

        string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
        return BadRequest(errors);
      }

      return Content($"{person}, User-Agent: {UserAgent}");
    }
  }
}
