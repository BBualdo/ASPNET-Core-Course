using Microsoft.AspNetCore.Mvc;
using ViewsExample.Models;

namespace ViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["appTitle"] = "ASP.NET Core App";
            List<Person> people = new List<Person>
            {
                new Person("Sebastian", new DateTime(2000, 05, 23), Person.Gender.Male),
                new Person("Asia", new DateTime(1999, 04, 30), Person.Gender.Female),
                new Person("Dominik", new DateTime(2024, 03, 02), Person.Gender.Male)
            };
            ViewData["people"] = people;

            return View();
        }
    }
}
