var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// enable routing
app.UseRouting();

// creating endpoints
app.UseEndpoints(endpoints =>
{
  // add your endpoints
  endpoints.Map("home", async (context) =>
  {
    await context.Response.WriteAsync("Home page");
  });

  // Executes only for GET HTTP method
  endpoints.MapGet("about", async (context) =>
  {
    await context.Response.WriteAsync("About page");
  });

  // Executes only for POST HTTP method
  endpoints.MapPost("randompage", async context =>
  {
    await context.Response.WriteAsync("Random Page");
  });
});

app.Run(async context =>
{
  await context.Response.WriteAsync($"Request received at: {context.Request.Path}");
});

app.Run();
