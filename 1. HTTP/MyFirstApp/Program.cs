var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
  HttpResponse response = context.Response;
  HttpRequest request = context.Request;

  if (request.Method == "GET" && request.Path == "/")
  {
    int firstNumber = 0;
    int secondNumber = 0;
    string? operation = null;
    long? result = null;

    // 'firstNumber' check and assignment
    if (request.Query.ContainsKey("firstNumber"))
    {
      string? firstNumberQuery = request.Query["firstNumber"][0];

      if (!String.IsNullOrEmpty(firstNumberQuery))
      {
        firstNumber = int.Parse(firstNumberQuery);
      }
      else
      {
        if (response.StatusCode == 200)
        {
          response.StatusCode = 400;
          await response.WriteAsync("Invalid input for 'firstNumber'");
        }
      }
    }
    else
    {
      if (response.StatusCode == 200)
      {
        response.StatusCode = 400;
        await response.WriteAsync("Invalid input for 'firstNumber'");
      }
    }

    // 'secondNumber' check and assignment

    if (request.Query.ContainsKey("secondNumber"))
    {
      string? secondNumberQuery = request.Query["secondNumber"][0];

      if (!String.IsNullOrEmpty(secondNumberQuery))
      {
        secondNumber = int.Parse(secondNumberQuery);
      }
      else
      {
        if (response.StatusCode == 200)
        {
          response.StatusCode = 400;
          await response.WriteAsync("Invalid input for 'secondNumber'");
        }
      }
    }
    else
    {
      if (response.StatusCode == 200)
      {
        response.StatusCode = 400;
        await response.WriteAsync("Invalid input for 'secondNumber'");
      }
    }

    // operation
    if (request.Query.ContainsKey("operation"))
    {
      operation = request.Query["operation"][0]?.ToString();

      if (!String.IsNullOrEmpty(operation))
      {
        switch (operation)
        {
          case "add": result = firstNumber + secondNumber; break;
          case "subtract": result = firstNumber - secondNumber; break;
          case "multiply": result = firstNumber * secondNumber; break;
          case "divide": result = secondNumber != 0 ? firstNumber / secondNumber : 0; break;
          case "modulo": result = secondNumber != 0 ? firstNumber % secondNumber : 0; break;
        }
      }
      else
      {
        if (response.StatusCode == 200)
        {
          response.StatusCode = 400;
          await response.WriteAsync("Invalid input for 'operation'");
        }
      }

      await response.WriteAsync($"Result is: {result}");
    }
    else
    {
      if (response.StatusCode == 200)
      {
        response.StatusCode = 400;
        await response.WriteAsync("Invalid input for 'operation'");
      }
    }
  }
});

app.Run();