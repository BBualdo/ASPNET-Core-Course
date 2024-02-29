using System.ComponentModel.DataAnnotations;

namespace ModelValidationExample.Custom_Validators
{
  public class MaximumYearAttribute : ValidationAttribute
  {
    private int _maximumYear = 1965;
    public string DefaultErrorMessage = "I'm sorry, but you are too old to use our application. You are vulnerable to scammers and investing in fake cryptocurrencies. :(";

    public MaximumYearAttribute() { }

    public MaximumYearAttribute(int maximumYear)
    {
      _maximumYear = maximumYear;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
      if (value != null)
      {
        DateTime date = (DateTime)value;
        if (date.Year <= _maximumYear)
        {
          return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, _maximumYear));
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
