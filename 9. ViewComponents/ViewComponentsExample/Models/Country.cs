namespace ViewComponentsExample.Models
{
  public class Country
  {
    public string Name { get; set; }
    public string CapitalCity { get; set; }

    public Country(string name, string capital)
    {
      Name = name;
      CapitalCity = capital;
    }
  }
}


