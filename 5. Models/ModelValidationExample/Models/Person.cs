using System.ComponentModel.DataAnnotations;

namespace ModelValidationExample.Models
{
  public class Person
  {
    [Required] // This is model validation attribute
    public string Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
    public double? Price { get; set; }


    public override string ToString()
    {
      return $"Person object:\n\n" +
        $"Name:\t{Name}\n" +
        $"Email:\t{Email}\n" +
        $"Phone:\t{Phone}\n" +
        $"Password:\t{Password}\n" +
        $"Confirm Password:\t{ConfirmPassword}\n" +
        $"Price:\t{Price}\n";
    }
  }
}
