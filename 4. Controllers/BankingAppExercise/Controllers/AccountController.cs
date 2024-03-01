using Microsoft.AspNetCore.Mvc;

namespace BankingAppExercise.Controllers
{
  public class AccountController : Controller
  {
    BankAccount account1 = new BankAccount(1001, "Example Name", 5000);

    [Route("account-details")]
    public IActionResult AccountDetails()
    {
      return Json(account1);
    }

    [Route("account-statement")]
    public IActionResult AccountStatement()
    {
      return File("/dummy-bank.pdf", "application/pdf");
    }

    [Route("get-current-balance/{id:int}")]

    public IActionResult CurrentBalance()
    {
      if (Request.RouteValues.ContainsKey("id"))
      {
        if (int.TryParse(Request.RouteValues["id"]!.ToString(), out int id))
        {
          if (id == account1.AccountNumber)
          {
            return Content($"Current Balance: {account1.CurrentBalance}");
          }
          else
          {
            return BadRequest($"Account Number should be {account1.AccountNumber}");
          }
        }
        else
        {
          return NotFound("Invalid Account Number. Account Number must be an integer");
        }
      }
      else
      {
        return NotFound("Account Number should be supplied");
      }


    }
  }
}
