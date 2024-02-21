var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
  await context.Response.WriteAsync("Hello");
});


// This code doesn't run because Run method doesn't forward the request to next middleware
app.Run(async (HttpContext context) =>
{
  await context.Response.WriteAsync("Hello again!");
});

app.Run();
