using MiddlewareExample.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<CustomMiddleware>();
var app = builder.Build();

// middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
  await context.Response.WriteAsync("Middleware 1 - Start\n");
  await next(context);
  await context.Response.WriteAsync("Middleware 1 - Stop\n");
});

// middleware 2
//app.UseMiddleware<CustomMiddleware>();
app.UseCustomMiddleware();

// middleware 3
app.UseGreetingCustomMiddleware();

// middleware 4 (terminating middleware)
app.Run(async (HttpContext context) =>
{
  await context.Response.WriteAsync("Middleware 3 - Start\n");
  await context.Response.WriteAsync("Middleware 3 - Stop\n");
});

app.Run();