var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
  string method = context.Request.Method;
  string path = context.Request.Path;
  context.Response.Headers["Content-Type"] = "text/html";
  await context.Response.WriteAsync($"<h1>{path}</h1>");
  await context.Response.WriteAsync($"<h3>{method}</h3>");
});

app.Run();