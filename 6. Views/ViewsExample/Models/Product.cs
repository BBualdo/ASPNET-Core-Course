namespace ViewsExample.Models
{
  public class Product
  {
    public string Name { get; set; }
    public string Description { get; set; }

    public Product(string name, string description)
    {
      Name = name;
      Description = description;
    }
  }
}
