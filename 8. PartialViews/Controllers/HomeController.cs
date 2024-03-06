using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller {

    [Route("/")]
    public IActionResult Index() {
        ViewData["ListTitle"] = "Citites";
        ViewData["ListItems"] = new List<string>() {
            "Kraków",
            "Warszawa",
            "Gdańsk",
            "Wrocław",
            "Lublin"
        };
        return View();

    }
    [Route("about")]
    public IActionResult About() {
        ViewData["ListTitle"] = "Employees";
        ViewData["ListItems"] = new List<string>() {
            "Asia",
            "Sebastian",
            "Dominik",
            "Oliwia",
            "Tomek"
            };
        return View();
    }
}