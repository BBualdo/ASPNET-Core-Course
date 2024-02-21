var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
  context.Response.Headers["Content-Type"] = "text/html";
  if (context.Request.Headers.ContainsKey("AuthorizationKey"))
  {
    string? authKey = context.Request.Headers["AuthorizationKey"];
    await context.Response.WriteAsync($"<h1>{authKey}</h1>");
  }

});

app.Run();