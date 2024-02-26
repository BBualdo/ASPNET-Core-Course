using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
  [Route("/books/")]
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      // Check if isLoggedIn is true
      if (!Request.Query.ContainsKey("isloggedin"))
      {
        //Response.StatusCode = 401;
        //return Content("User is not logged in");
        //or
        //return new UnauthorizedObjectResult("User is not logged in");
        //or
        //return new UnauthorizedResult();
        //or
        //return StatusCode(401);
        //(message)
        //or
        return Unauthorized("User is not logged in");
      }

      bool isLoggedIn = Convert.ToBoolean(Request.Query["isloggedin"]);

      if (isLoggedIn)
      {
        if (!Request.Query.ContainsKey("bookid"))
        {
          return BadRequest("Please provide valid book ID");
        }

        if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
        {
          return BadRequest("Book ID can't be empty");
        }

        int bookId = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookID"]);

        if (bookId <= 0)
        {
          return BadRequest("Book ID can't be less or equal to 0");
        }

        if (bookId > 1000)
        {
          return NotFound("Book ID can't be higher than 1000.");
        }

        return File("/sample.txt", "text/plain");
      }
      else
      {
        return Unauthorized("Unauthorized content.");
      }


    }
  }
}
