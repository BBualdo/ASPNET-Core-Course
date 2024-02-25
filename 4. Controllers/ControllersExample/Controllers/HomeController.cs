using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
  [Controller] // You have to use this attribute
  public class HomeController // or Controller suffix in class name
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
