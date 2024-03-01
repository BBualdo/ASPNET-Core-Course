using Microsoft.AspNetCore.Mvc;

namespace eCommerceAppExercise.Controllers
{
  public class HomeController : Controller
  {
    [Route("/")]
    public IActionResult Index()
    {
      return Content("Welcome in the eCommerce Web App.");
    }
  }
}
