var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
  // 1xx Informational: 
  //    101 - Switching Protocols
  // 2xx Success:
  //    200 - OK
  // 3xx Redirection:
  //    302 - Found
  //    304 - Not Modified
  // 4xx Client error:
  //    400 - Bad Request
  //    401 - Unauthorized
  //    404 - Not Found
  // 5xx Server error:
  //    500 Internal Server Error
  context.Response.StatusCode = 400;
  await context.Response.WriteAsync("Hello");
  await context.Response.WriteAsync("World");
});

app.Run();
