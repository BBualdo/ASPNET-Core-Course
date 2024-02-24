var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// enable routing
app.UseRouting();

#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints =>
{
  //// add your endpoints (must use when not in MinimalAPI)
  //endpoints.Map("files/{filename}.{extension}", async context =>
  //{
  //  string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
  //  string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
  //  await context.Response.WriteAsync($"Accessing file: {fileName}.{extension}");
  //});

  //endpoints.Map("employee/profile/{employeename?}", async context =>
  //{
  //  if (context.Request.RouteValues.ContainsKey("employeename"))
  //  {
  //    string? employeeName = Convert.ToString(context.Request.RouteValues["employeename"]);
  //    await context.Response.WriteAsync($"Accesing {employeeName} employee profile.");
  //  }
  //  else
  //  {
  //    await context.Response.WriteAsync("Please enter employee name.");
  //  }

  //});

  //endpoints.Map("products/details/{id?}", async context =>
  //{
  //  if (context.Request.RouteValues.ContainsKey("id"))
  //  {
  //    int? id = Convert.ToInt32(context.Request.RouteValues["id"]);
  //    await context.Response.WriteAsync($"Details about Product with ID: {id}");
  //  }
  //  else
  //  {
  //    await context.Response.WriteAsync("No valid Product ID was provided.");
  //  }
  //});

  endpoints.Map("daily-report/{datetime:datetime}", async context =>
  {
    DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["datetime"]);
    await context.Response.WriteAsync($"Daily report for date: {reportDate.ToShortDateString()}");
  });
});
#pragma warning restore ASP0014 // Suggest using top level route registrations

app.Run(async context =>
{
  await context.Response.WriteAsync($"Request received at: {context.Request.Path}");
});

app.Run();
