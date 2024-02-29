using ModelValidationExample.Custom_Validators;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationExample.Models
{
  public class Person
  {
    [Required(ErrorMessage = "{0} is required.")] // This is model validation attribute
    [Display(Name = "Person Name")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} characters long.")]
    [RegularExpression("^[A-Za-z .]*$", ErrorMessage = "{0} should contain only letters, space and dot.")]
    public string? Name { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string? Email { get; set; }

    [Phone(ErrorMessage = "Invalid phone number.")]
    //[ValidateNever]
    public string? Phone { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    [Display(Name = "Password confirmation")]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public string? ConfirmPassword { get; set; }

    [Range(0, 999.99, ErrorMessage = "{0} should be between ${1} and ${2}.")]
    public double? Price { get; set; }

    [MinimumYear(2000)]
    [MaximumYear(1965)]
    public DateTime? DateOfBirth { get; set; }

    public override string ToString()
    {
      return $"Person object:\n\n" +
        $"Name:\t{Name}\n" +
        $"Email:\t{Email}\n" +
        $"Phone:\t{Phone}\n" +
        $"Password:\t{Password}\n" +
        $"Confirm Password:\t{ConfirmPassword}\n" +
        $"Price:\t${Price}\n" +
        $"Date of Birth:\t{DateOfBirth}\n";
    }
  }
}
