using Microsoft.AspNetCore.Mvc;
using ViewComponentsExample.Models;

namespace ViewComponentsExample;

// [ViewComponent]
public class GridViewComponent : ViewComponent
{
  public async Task<IViewComponentResult> InvokeAsync()
  {
    List<Country> countries = new List<Country>() {
      new Country("Poland", "Warszawa"),
      new Country("Greece", "Athenas"),
      new Country("Germany", "Berlin"),
      new Country("France", "Paris"),
      new Country("Spain", "Madrid")
    };
    ViewBag.List = countries;

    return View(); // invoke partial view from /Views/Shared/Components/Grid/Default.cshtml
  }
}
