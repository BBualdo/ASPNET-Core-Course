using ControllersExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{

  public class HomeController : Controller
  {
    [Route("/")] // Attribute Routing
    [Route("home")]
    public ContentResult Index()
    {
      // return new ContentResult()
      // {
      //   Content = "<h1>Hello from Index Page</h1>",
      //   ContentType = "text/html"
      // };

      return Content("<h1>Hello from Index Page</h1>", "text/html"); // available when inherits from Controller
    }


    [Route("person")]
    public JsonResult Person()
    {
      Person person = new Person(Guid.NewGuid(), "Asia", "Opozda", 25);
      // return new JsonResult(person);
      return Json(person);
    }

    [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]
    public string Contact()
    {
      return "Hello from Contact Page";
    }
  }
}
