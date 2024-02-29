using System.ComponentModel.DataAnnotations;

namespace ModelValidationExample.Custom_Validators
{
  public class MinimumYearAttribute : ValidationAttribute
  {
    private int _minimumYear = 2000;
    public string DefaultErrorMessage = "Minimum year allowed is {0}.";

    public MinimumYearAttribute() { }

    public MinimumYearAttribute(int minimumYear)
    {
      _minimumYear = minimumYear;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
      if (value != null)
      {
        DateTime date = (DateTime)value;
        if (date.Year > _minimumYear)
        {
          return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, _minimumYear));
        }
        else
        {
          return ValidationResult.Success;
        }
      }

      return null;
    }
  }
}
