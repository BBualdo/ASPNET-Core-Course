using System.ComponentModel.DataAnnotations;

namespace ModelValidationExample.Models
{
  public class Person
  {
    [Required(ErrorMessage = "{0} is required.")] // This is model validation attribute
    [Display(Name = "Person Name")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} characters long.")]
    public string Name { get; set; }
    [Required]
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }

    [Range(0, 999.99, ErrorMessage = "{0} should be between ${1} and ${2}.")]
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
