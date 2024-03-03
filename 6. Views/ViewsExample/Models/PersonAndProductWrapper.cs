namespace ViewsExample.Models
{
  public class PersonAndProductWrapper
  {
    public List<Person> PeopleData { get; set; }
    public List<Product> ProductsData { get; set; }

    public PersonAndProductWrapper(List<Person> people, List<Product> products)
    {
      PeopleData = people;
      ProductsData = products;
    }
  }
}
