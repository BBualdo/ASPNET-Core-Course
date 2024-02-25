using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
  public class HomeController
  {
    [Route("/")] // Attribute Routing
    [Route("home")]
    public string Index()
    {
      return "Hello from Home Page";
    }


    [Route("about")]
    public string About()
    {
      return "Hello from About Page";
    }

    [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]
    public string Contact()
    {
      return "Hello from Contact Page";
    }
  }
}
