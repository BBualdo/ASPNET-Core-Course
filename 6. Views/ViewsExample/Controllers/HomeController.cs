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
      ViewBag.appTitle = "ASP.NET Core Web App | People";
      List<Person> people = new List<Person>
        {
          new Person("Sebastian", new DateTime(2000, 05, 23), Person.Gender.Male),
          new Person("Asia", new DateTime(1999, 04, 30), Person.Gender.Female),
          new Person("Dominik", DateTime.Now, Person.Gender.Male),
          new Person("Frania", new DateTime(1945, 09, 15), Person.Gender.Female),
        };
      // ViewData["people"] = people;
      //ViewBag.people = people;
      return View(people);
    }

    [Route("details/{name}")]
    public IActionResult Details(string? name)
    {
      ViewBag.appTitle = "ASP.NET Core Web App | Details";

      if (name == null)
      {
        return Content("Name can't be empty");
      }

      List<Person> people = new List<Person>
        {
          new Person("Sebastian", new DateTime(2000, 05, 23), Person.Gender.Male),
          new Person("Asia", new DateTime(1999, 04, 30), Person.Gender.Female),
          new Person("Dominik", DateTime.Now, Person.Gender.Male),
          new Person("Frania", new DateTime(1945, 09, 15), Person.Gender.Female),
        };

      Person? matchingPerson = people.Where(person => person.Name == name).FirstOrDefault();

      return View(matchingPerson);
    }

    [Route("wishlist")]
    public IActionResult WishList()
    {
      ViewBag.appTitle = "ASP.NET Core Web App | People and Products";

      List<Person> people = new List<Person>
        {
          new Person("Sebastian", new DateTime(2000, 05, 23), Person.Gender.Male),
          new Person("Asia", new DateTime(1999, 04, 30), Person.Gender.Female),
          new Person("Dominik", DateTime.Now, Person.Gender.Male),
          new Person("Frania", new DateTime(1945, 09, 15), Person.Gender.Female),
        };

      List<Product> wishList = new List<Product>
      {
        new Product("Car", "Red"),
        new Product("Headphones", "Black"),
        new Product("Holidays", "Dreamy")
      };

      PersonAndProductWrapper wrapper = new PersonAndProductWrapper(people, wishList);
      return View(wrapper);
    }
  }
}
