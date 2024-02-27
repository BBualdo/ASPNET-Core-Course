using Microsoft.AspNetCore.Mvc;

namespace ModelBindingExample.Controllers
{
  // books/59/true?isloggedin=false&bookid=44 => Route Parameters have more priority than Query String so bookid = 59, isloggedin = true
  [Route("books/{bookid?}/{isloggedin?}")]
  public class HomeController : Controller
  {
    public IActionResult Index(int? bookid, bool? isloggedin) // Model Binding occurs between Request and Action, so values will be fetched automatically
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

        return Content($"Book ID: {bookid}", "text/plain");
      }
      else
      {
        return Unauthorized("Unauthorized content.");
      }


    }
  }
}
