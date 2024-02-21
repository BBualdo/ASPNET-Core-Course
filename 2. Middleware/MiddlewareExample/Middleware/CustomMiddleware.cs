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
}
