using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
  public class HomeController
  {
    [Route("sayhello")] // Attribute Routing
    public string Method1()
    {
      return "Hello from HomeController.Method1";
    }
  }
}
