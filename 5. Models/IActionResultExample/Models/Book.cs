namespace ModelBindingExample.Models
{
  public class Book
  {
    // [FromRoute]
    public int Bookid { get; set; }
    public string? Author { get; set; }

    public override string ToString()
    {
      return $"Book id: {Bookid}, Author: {Author}";
    }
  }
}
