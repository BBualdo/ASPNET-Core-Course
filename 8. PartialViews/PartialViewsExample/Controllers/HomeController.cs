using Microsoft.AspNetCore.Mvc;
using PartialViewsExample.Models;

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

    [Route("programming-languages")]
    public IActionResult ProgrammingLanguages() {
        ListModel listModel = new ListModel() {
            ListTitle = "Programming Languages",
            ListItems = new List<string>() {
                "JavaScript",
                "Python",
                "C#",
                "Go"
        }};
        
        return PartialView("_ListPartialView", listModel);
    }
}