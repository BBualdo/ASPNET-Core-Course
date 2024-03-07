using System.Collections;

namespace ViewComponentsExample.Models;

public class CountryList
{
  public string ListName { get; set; } = "Countries";
  public List<Country> ListItems { get; set; }

  public CountryList(List<Country> countries)
  {
    ListItems = countries;
  }
}
