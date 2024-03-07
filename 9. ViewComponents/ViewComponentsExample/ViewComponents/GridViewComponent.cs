using Microsoft.AspNetCore.Mvc;
using ViewComponentsExample.Models;

namespace ViewComponentsExample.ViewComponents
{
  // [ViewComponent]
  public class GridViewComponent : ViewComponent
  {
    public async Task<IViewComponentResult> InvokeAsync(CountryList list)
    {
      return View(list); // invoke partial view from /Views/Shared/Components/Grid/Default.cshtml
    }
  }
}


