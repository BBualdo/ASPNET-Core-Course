using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
  public class StoreController : Controller
  {
    // This is new URL that will be passed to Response Headers when trying to Request /books
    [Route("store/books/{id}")]
    public IActionResult Books()
    {
      int id = Convert.ToInt32(Request.RouteValues["id"]);

      return Content($"<h1>Book Store</h1> <p>{id}</p>", "text/html");
    }
  }
}
