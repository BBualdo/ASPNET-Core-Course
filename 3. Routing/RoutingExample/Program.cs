using RoutingExample.CustomContstraints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(options =>
{
  options.ConstraintMap.Add("months", typeof(MonthCustomConstraint));
});

var app = builder.Build();

// enable routing
app.UseRouting();

#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints =>
{
  // add your endpoints (must use when not in MinimalAPI)
  endpoints.Map("files/{filename}.{extension}", async context =>
  {
    string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
    string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
    await context.Response.WriteAsync($"Accessing file: {fileName}.{extension}");
  });

  endpoints.Map("employee/profile/{employeename:length(4, 8):alpha?}", async context =>
  {
    if (context.Request.RouteValues.ContainsKey("employeename"))
    {
      string? employeeName = Convert.ToString(context.Request.RouteValues["employeename"]);
      await context.Response.WriteAsync($"Accesing {employeeName} employee profile.");
    }
    else
    {
      await context.Response.WriteAsync("Please enter employee name.");
    }

  });

  endpoints.Map("products/details/{id:int:range(1, 100)?}", async context =>
  {
    if (context.Request.RouteValues.ContainsKey("id"))
    {
      int? id = Convert.ToInt32(context.Request.RouteValues["id"]);
      await context.Response.WriteAsync($"Details about Product with ID: {id}");
    }
    else
    {
      await context.Response.WriteAsync("No valid Product ID was provided.");
    }
  });

  endpoints.Map("daily-report/{datetime:datetime}", async context =>
  {
    DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["datetime"]);
    await context.Response.WriteAsync($"Daily report for date: {reportDate.ToShortDateString()}");
  });

  endpoints.Map("cities/{cityid:guid}", async context =>
  {
    Guid id = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"])!);
    await context.Response.WriteAsync($"Displaying city with coresponding ID: {id}");
  });

  endpoints.Map("user/{username:length(4,8)}", async context =>
  {
    string? username = (string?)context.Request.RouteValues["username"];
    await context.Response.WriteAsync($"Username is {username}");
  });

  endpoints.Map("sales-report/{year:int:min(1900)}/{month:months}", async context =>
  {
    string? year = (string?)context.Request.RouteValues["year"];
    string? month = (string?)context.Request.RouteValues["month"];

    // instead of constraint you can just make validation in code:
    if (month == "jan" || month == "apr" || month == "jul" || month == "oct")
    {
      await context.Response.WriteAsync($"Sales report for {month}/{year}:");
    }
    else
    {
      await context.Response.WriteAsync($"{month} is unavailable for Sales report.");
    }
  });

  // More specificity because of literal values in path
  endpoints.Map("sales-report/2024/jan", async context =>
  {
    await context.Response.WriteAsync("Sales report exclusively for JAN 2024");
  });
});
#pragma warning restore ASP0014 // Suggest using top level route registrations

app.Run(async context =>
{
  await context.Response.WriteAsync($"No route match at: {context.Request.Path}");
});

app.Run();
