using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
  context.Response.ContentType = "text/html";

  StreamReader reader = new StreamReader(context.Request.Body);

  string body = await reader.ReadToEndAsync();

  Dictionary<string, StringValues> parsedQueryString = QueryHelpers.ParseQuery(body);

  // POST firstName=Asia&firstName=Sebastian

  if (parsedQueryString.ContainsKey("firstName"))
  {
    foreach (string? firstName in parsedQueryString["firstName"])
    {
      await context.Response.WriteAsync($"<p>Hello, I'm {firstName}</p>");
    }
  }
});

app.Run();