using Microsoft.AspNetCore.Mvc;

namespace ViewComponentsExample;

// [ViewComponent]
public class GridViewComponent : ViewComponent
{
  public async Task<IViewComponentResult> InvokeAsync() {
    return View(); // invoke partial view from /Views/Shared/Components/Grid/Default.cshtml
  }
}
