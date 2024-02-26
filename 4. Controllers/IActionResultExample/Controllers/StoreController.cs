using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
  public class StoreController : Controller
  {
    // This is new URL that will be passed to Response Headers when trying to Request /books
    [Route("store/books")]
    public IActionResult Books()
    {
      // Return file that was in HomeController
      return File("/sample.txt", "text/plain");
    }
  }
}
