using Microsoft.AspNetCore.Mvc;

namespace ModelBindingExample.Controllers
{
  // Let's assume, the URL has changed from books to store/books
  [Route("books")]
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

        //return new RedirectToActionResult("Books", "Store", new { }); // 302 - Found
        //or
        //return RedirectToAction("Books", "Store", new { id = bookId });

        //or if permament

        //return new RedirectToActionResult("Books", "Store", new { }, true); // 301 - Moved Permanent
        //or
        //return RedirectToActionPermanent("Books", "Store", new { id = bookId });

        // The difference is in case of 301 the browsers and search engines will remember that URL has changed and replace it for example in client's bookmarks


        // ------------------------ InvalidOperationException: The supplied URL is not local. A URL with an absolute path is considered local if it does not have a host/authority part. URLs using virtual paths ('~/') are also local. --------------------------
        //return new LocalRedirectResult($"store/books/{bookId}");
        //or
        //return LocalRedirect($"store/books/{bookId}");

        //or if permanent

        //return new LocalRedirectResult($"store/books/{bookId}", true);
        //or
        //return LocalRedirectPermanent($"store/books/{bookId}");

        // local redirect lets only for redirection in range of the same app, when by redirecting to action you can redirect to another application or website, like Facebook, YouTube, etc. 

        // -------------------------------------------------------------------------------------------------------------

        //return Redirect($"store/books/{bookId}");
        //or 
        return RedirectPermanent($"store/books/{bookId}");
      }
      else
      {
        return Unauthorized("Unauthorized content.");
      }


    }
  }
}
