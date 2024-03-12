using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace SocialMediaLinksExercise.Controllers
{
  public class HomeController : Controller
  {
    private readonly SocialMediaLinksOptions _options;
    public HomeController(IOptions<SocialMediaLinksOptions> options)
    {
      _options = options.Value;
    }

    [Route("/")]
    public IActionResult Index()
    {
      ViewBag.Options = _options;
      return View();
    }
  }
}
