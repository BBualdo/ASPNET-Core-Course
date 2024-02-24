var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// defining countries

Dictionary<int, string> countries = new Dictionary<int, string>()
{
  { 1, "United States" },
  { 2, "Canada" },
  { 3, "United Kingdom" },
  { 4, "India" },
  { 5, "Japan" },
};

app.UseRouting();

#pragma warning disable ASP0014
app.UseEndpoints(endpoints =>
{
  endpoints.Map("/countries", async context =>
  {
    // loop through all countries in dictionary
    foreach (KeyValuePair<int, string> country in countries)
    {
      await context.Response.WriteAsync($"{country.Key}. {country.Value}\n");
    }
  });

  endpoints.Map("/countries/{id:int}", async context =>
  {
    // first converting route value to string, then parsing to int
    int id = Int32.Parse((string)context.Request.RouteValues["id"]!);

    // I dont know why I dont get response if this condition is met
    if (id > 100)
    {
      context.Response.StatusCode = 400;
      await context.Response.WriteAsync("The CountryID should be between 1 and 100");
    }

    // tries get value from countries dictionary, if success - display country
    if (countries.TryGetValue(id, out string? country))
    {
      await context.Response.WriteAsync($"{id}. {country}");
    }
    else
    {
      context.Response.StatusCode = 404;
      await context.Response.WriteAsync("Country not found.");
    }
  });
});
#pragma warning restore ASP0014

app.Run(async context =>
{
  await context.Response.WriteAsync($"No response at path: {context.Request.Path}");
});

app.Run();
