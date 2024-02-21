var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
  if (context.Request.Method == "GET")
  {
    string firstNumber = context.Request.Query["firstNumber"];
    string secondNumber = context.Request.Query["secondNumber"];
    string operation = context.Request.Query["operation"];

    int? result = null;

    if (firstNumber == null)
    {
      await context.Response.WriteAsync("Invalid input for 'firstNumber'");
      return;
    }
    if (secondNumber == null)
    {
      await context.Response.WriteAsync("Invalid input for 'secondNumber'");
      return;
    }
    // Why using || operator makes Invalid input for 'operation' appearing and using && operator works fine??

    if (operation != "add" && operation != "subtract" && operation != "multiply" && operation != "divide" && operation != "modulo")
    {
      await context.Response.WriteAsync("Invalid input for 'operation'");
      return;
    }


    if (!int.TryParse(firstNumber, out int firstNum))
    {
      await context.Response.WriteAsync("Invalid input for 'firstNumber'");
      return;
    }
    else if (!int.TryParse(secondNumber, out int secondNum))
    {
      await context.Response.WriteAsync("Invalid input for 'secondNumber'");
      return;
    }
    else
    {
      switch (operation)
      {
        case "add":
          result = firstNum + secondNum;
          break;
        case "subtract":
          result = firstNum - secondNum;
          break;
        case "multiply":
          result = firstNum * secondNum;
          break;
        case "divide":
          result = firstNum / secondNum;
          break;
        case "modulo":
          result = firstNum % secondNum;
          break;
        default:
          await context.Response.WriteAsync("Unknown operation!");
          break;
      }

      await context.Response.WriteAsync($"Result is: {result}");
    }

  }
});

app.Run();