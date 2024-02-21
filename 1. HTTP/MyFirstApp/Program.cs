var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
  context.Response.Headers["Content-Type"] = "text/html";
  if (context.Request.Method == "GET")
  {
    string? id = context.Request.Query["id"];
    await context.Response.WriteAsync($"<h1>{id}</h1>");

    string? name = context.Request.Query["name"];
    await context.Response.WriteAsync($"<h2>{name}</h2>");

    // localhost:5000?id=1337&name=Sebastian
  }
});

app.Run();