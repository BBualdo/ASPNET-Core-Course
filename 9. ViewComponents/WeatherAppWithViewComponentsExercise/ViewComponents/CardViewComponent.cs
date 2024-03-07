using Microsoft.AspNetCore.Mvc;
using WeatherAppExercise.Models;

namespace WeatherAppExercise.ViewComponents
{
  public class CardViewComponent : ViewComponent
  {

    public async Task<IViewComponentResult> InvokeAsync(City city)
    {
      return View(city);
    }
  }
}