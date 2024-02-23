var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
  // endpoint will be null here, because it is called before UseRouting()
  Endpoint? endpoint = context.GetEndpoint();
  if (endpoint != null)
  {
    await context.Response.WriteAsync($"Endpoint: {endpoint.DisplayName}\n");
  }
  await next();
});

// enable routing
app.UseRouting();

app.Use(async (context, next) =>
{
  Endpoint? endpoint = context.GetEndpoint();
  if (endpoint != null)
  {
    await context.Response.WriteAsync($"Endpoint: {endpoint.DisplayName}\n");
  }
  await next();
});

// creating endpoints (optional in top-level statement)
app.UseEndpoints(endpoints =>
{ });

// add your endpoints
app.Map("home", async (context) =>
  {
    await context.Response.WriteAsync("Home page");
  });

// Executes only for GET HTTP method
app.MapGet("about", async (context) =>
{
  await context.Response.WriteAsync("About page");
});

// Executes only for POST HTTP method
app.MapPost("randompage", async context =>
{
  await context.Response.WriteAsync("Random Page");
});


app.Run(async context =>
{
  await context.Response.WriteAsync($"Request received at: {context.Request.Path}");
});

app.Run();
