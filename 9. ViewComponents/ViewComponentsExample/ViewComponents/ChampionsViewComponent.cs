using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using ViewComponentsExample.Models;

namespace ViewComponentsExample.ViewComponents;

public class ChampionsViewComponent : ViewComponent
{
  public async Task<IViewComponentResult> InvokeAsync(ChampionList list)
  {
    return View(list);
  }
}
