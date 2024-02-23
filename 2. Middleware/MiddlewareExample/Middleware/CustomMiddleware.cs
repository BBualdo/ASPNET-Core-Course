namespace MiddlewareExample.Middleware
{
  public class CustomMiddleware : IMiddleware
  {
    async public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
      await context.Response.WriteAsync("Custom middleware has been started!\n");
      await next(context);
      await context.Response.WriteAsync("Custom middleware has been ended!\n");
    }
  }

  public static class CustomMiddlewareExtension
  {
    public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app)
    {
      return app.UseMiddleware<CustomMiddleware>();
    }
  }
}
