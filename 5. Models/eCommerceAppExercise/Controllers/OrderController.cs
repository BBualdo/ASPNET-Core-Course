using eCommerceAppExercise.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceAppExercise.Controllers
{
  public class OrderController : Controller
  {
    [HttpPost]
    [Route("order")]
    public IActionResult Order(Order order)
    {
      if (!ModelState.IsValid)
      {
        string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors.Select(err => err.ErrorMessage)));
        return BadRequest(errors);
      }
      else
        return Content($"New Order Number: {order.OrderNo}");
    }
  }
}
