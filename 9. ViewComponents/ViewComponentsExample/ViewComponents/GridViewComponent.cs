using Microsoft.AspNetCore.Mvc;
using ViewComponentsExample.Models;

namespace ViewComponentsExample;

// [ViewComponent]
public class GridViewComponent : ViewComponent
{
  public async Task<IViewComponentResult> InvokeAsync(List<Country> countries)
  {
    return View(countries); // invoke partial view from /Views/Shared/Components/Grid/Default.cshtml
  }
}
