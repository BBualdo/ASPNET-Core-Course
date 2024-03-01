using Microsoft.AspNetCore.Mvc;
using ModelBindingExample.Models;

namespace ModelBindingExample.Controllers
{
  // POST Request x-www-form-urlencoded and form-data has highest priority
  [Route("books/{bookid?}/{isloggedin?}")]
  public class HomeController : Controller
  {
    public IActionResult Index(int? bookid, bool? isloggedin, Book book)
    {
      // Check if isLoggedIn is true
      if (isloggedin == false)
      {
        return Unauthorized("User is not logged in");
      }

      if (isloggedin == true)
      {
        if (bookid.HasValue == false)
        {
          return BadRequest("Please provide valid book ID");
        }


        if (bookid <= 0)
        {
          return BadRequest("Book ID can't be less or equal to 0");
        }

        if (bookid > 1000)
        {
          return NotFound("Book ID can't be higher than 1000.");
        }

        return Content($"{book}", "text/plain");
      }
      else
      {
        return Unauthorized("Unauthorized content.");
      }


    }
  }
}
