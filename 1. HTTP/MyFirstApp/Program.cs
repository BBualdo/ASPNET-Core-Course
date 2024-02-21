var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
  context.Response.Headers["MyKey"] = "My Value";
  context.Response.Headers["Server"] = "My Server (Kestrel)";
  context.Response.Headers["Content-Type"] = "text/html";
  await context.Response.WriteAsync("<h1>Hello World!</h1>");
  await context.Response.WriteAsync("<h2>This is Content-Type of text/html.</h2>");
});

app.Run();
