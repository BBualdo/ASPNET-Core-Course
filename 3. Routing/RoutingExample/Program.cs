var builder = WebApplication.CreateBuilder(args);
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

  endpoints.Map("employee/profile/{employeename}", async context =>
  {
    string? employeeName = Convert.ToString(context.Request.RouteValues["employeename"]);
    await context.Response.WriteAsync($"Accesing {employeeName} employee profile.");
  });

  endpoints.Map("products/details/{id=1}", async context =>
  {
    int? id = Convert.ToInt32(context.Request.RouteValues["id"]);
    await context.Response.WriteAsync($"Details about Product with ID: {id}");
  });
});
#pragma warning restore ASP0014 // Suggest using top level route registrations

app.Run(async context =>
{
  await context.Response.WriteAsync($"Request received at: {context.Request.Path}");
});

app.Run();
