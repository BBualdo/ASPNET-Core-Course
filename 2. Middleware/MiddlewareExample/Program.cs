var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
  await context.Response.WriteAsync("Hello\n");
  await next(context);
});

// middleware 2
app.Use(async (HttpContext context, RequestDelegate next) =>
{
  await context.Response.WriteAsync("Hello again!\n");
  await next(context);
});

// middleware 3 (terminating middleware)
app.Run(async (HttpContext context) =>
{
  await context.Response.WriteAsync("Hello one more time!\n");
});

app.Run();