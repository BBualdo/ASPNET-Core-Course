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
        Response.StatusCode = 401;
        return Content("User is not logged in");
      }

      bool isLoggedIn = Convert.ToBoolean(Request.Query["isloggedin"]);

      if (isLoggedIn)
      {
        if (!Request.Query.ContainsKey("bookid"))
        {
          Response.StatusCode = 400;
          return Content("Please provide valid book ID");
        }

        if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
        {
          Response.StatusCode = 400;
          return Content("Book ID can't be empty");
        }

        int bookId = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookID"]);

        if (bookId <= 0)
        {
          Response.StatusCode = 400;
          return Content("Book ID can't be less or equal to 0");
        }

        if (bookId > 1000)
        {
          Response.StatusCode = 400;
          return Content("Book ID can't be higher than 1000.");
        }

        return File("/sample.txt", "text/plain");
      }
      else
      {
        Response.StatusCode = 401;
        return Content("Unauthorized content.");
      }


    }
  }
}
