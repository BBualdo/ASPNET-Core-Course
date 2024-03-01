using Microsoft.Extensions.Primitives;

namespace LoginMiddlewareExercise.Middleware
{
  public class LoginMiddleware
  {
    private readonly RequestDelegate _next;

    public LoginMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    async public Task Invoke(HttpContext context)
    {
      if (context.Request.Path == "/" && context.Request.Method == "POST")
      {
        StreamReader reader = new StreamReader(context.Request.Body);
        string bodyString = await reader.ReadToEndAsync();
        Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(bodyString);

        if (queryDict.ContainsKey("email") && queryDict.ContainsKey("password"))
        {
          string email = null;
          string password = null;

          if (!string.IsNullOrEmpty(queryDict["email"][0]))
          {
            email = Convert.ToString(queryDict["email"][0]);
          }
          else
          {
            if (context.Response.StatusCode == 200)
            {
              context.Response.StatusCode = 400;
            }
            await context.Response.WriteAsync("Invalid input for 'email'");
          }

          if (!string.IsNullOrEmpty(queryDict["password"][0]))
          {
            password = Convert.ToString(queryDict["password"][0]);
          }
          else
          {
            if (context.Response.StatusCode == 200)
            {
              context.Response.StatusCode = 400;
            }
            await context.Response.WriteAsync("Invalid input for 'password'");
          }

          if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
          {
            string validEmail = "admin@example.com";
            string validPassword = "admin1234";
            bool isValidLogin;

            if (email == validEmail && password == validPassword)
            {
              isValidLogin = true;
            }
            else
            {
              isValidLogin = false;
            }

            if (isValidLogin)
            {
              context.Response.StatusCode = 200;
              await context.Response.WriteAsync("Successful login");
            }
            else
            {
              if (context.Response.StatusCode == 200)
              {
                context.Response.StatusCode = 400;
              }
              await context.Response.WriteAsync("Invalid login");
            }
          }
        }
        else
        {
          if (context.Response.StatusCode == 200)
          {
            context.Response.StatusCode = 400;
          }
          await context.Response.WriteAsync("Invalid inputs");
        }
      }
      else
      {
        await _next(context);
      }
    }

  }

  public static class LoginMiddlewareExtension
  {
    public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder app)
    {
      return app.UseMiddleware<LoginMiddleware>();
    }
  }
}
