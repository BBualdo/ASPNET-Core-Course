using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
  context.Response.ContentType = "text/html";
  // need StreamReader, because Request.Body is type of Stream
  StreamReader reader = new StreamReader(context.Request.Body);
  // Reading Stream and making it single string
  string body = await reader.ReadToEndAsync();

  // converting string into Dictionary (Key=Value pairs)
  // using StringValues because Keys in Query String are not unique, so if there is e.x. ?...age=20&age=30 both values can be shown
  Dictionary<string, StringValues> parsedQueryString = QueryHelpers.ParseQuery(body);

  if (parsedQueryString.ContainsKey("firstName") && parsedQueryString.ContainsKey("age"))
  {
    // In case if there is more than one value for one key I use first Index
    string? firstName = parsedQueryString["firstName"][0];
    string? age = parsedQueryString["age"][0];
    await context.Response.WriteAsync($"<h1>{firstName} is {age} years old.</h1>");
  }
});

app.Run();