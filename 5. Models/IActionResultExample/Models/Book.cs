using Microsoft.AspNetCore.Mvc;

namespace ModelBindingExample.Models
{
  public class Book
  {
    [FromQuery]
    public int Bookid { get; set; }
    [FromQuery]
    public string? Author { get; set; }

    public override string ToString()
    {
      return $"Book id: {Bookid}, Author: {Author}";
    }
  }
}
