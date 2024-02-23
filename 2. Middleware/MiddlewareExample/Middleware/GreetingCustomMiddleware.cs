namespace MiddlewareExample.Middleware
{
  // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
  public class GreetingCustomMiddleware
  {
    private readonly RequestDelegate _next;

    public GreetingCustomMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
      //before logic
      if (httpContext.Request.Query.ContainsKey("firstName") && httpContext.Request.Query.ContainsKey("lastName"))
      {
        string fullName = httpContext.Request.Query["firstName"] + " " + httpContext.Request.Query["lastName"];
        await httpContext.Response.WriteAsync("Hello " + fullName + "\n");
      }

      await _next(httpContext);
      //after logic
    }
  }

  // Extension method used to add the middleware to the HTTP request pipeline.
  public static class GreetingCustomMiddlewareExtensions
  {
    public static IApplicationBuilder UseGreetingCustomMiddleware(this IApplicationBuilder builder)
    {
      return builder.UseMiddleware<GreetingCustomMiddleware>();
    }
  }
}
