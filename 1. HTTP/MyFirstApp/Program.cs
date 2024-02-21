var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
  context.Response.Headers["Content-Type"] = "text/html";
  if (context.Request.Headers.ContainsKey("User-Agent"))
  {
    string? userAgent = context.Request.Headers["User-Agent"];
    await context.Response.WriteAsync($"<h1>{userAgent}</h1>");
  }

});

app.Run();