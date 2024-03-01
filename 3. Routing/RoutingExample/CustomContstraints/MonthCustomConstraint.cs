using System.Text.RegularExpressions;

namespace RoutingExample.CustomContstraints
{
  public class MonthCustomConstraint : IRouteConstraint
  {
    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
      // checking if value exists
      if (!values.ContainsKey(routeKey))
      {
        return false; // not a match
      }

      Regex regex = new Regex("^(jan|apr|jul|oct)$");
      string? monthValue = (string?)values[routeKey];
      if (regex.IsMatch(monthValue))
      {
        return true; // it's a match
      }
      return false; // not a match
    }
  }
}
