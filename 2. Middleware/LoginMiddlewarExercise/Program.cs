using LoginMiddlewareExercise.Middleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.UseLoginMiddleware();

app.Run(async (HttpContext context) =>
{
  await context.Response.WriteAsync("No response");
});

app.Run();
