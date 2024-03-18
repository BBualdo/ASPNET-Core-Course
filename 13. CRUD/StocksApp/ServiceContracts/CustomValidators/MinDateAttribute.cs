using System.ComponentModel.DataAnnotations;

namespace Stocks.CustomValidators
{
  public class MinDateAttribute : ValidationAttribute
  {
    private DateTime _date = DateTime.Parse("01, 01, 2000");
    private string DefaultErrorMessage = "Date can't be older than {0}.";
    public MinDateAttribute() { }
    public MinDateAttribute(DateTime date)
    {
      _date = date;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
      if (value == null)
      {
        return null;
      }

      DateTime date = (DateTime)value;

      if (date < DateTime.Parse("01, 01, 2000"))
      {
        return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, _date));
      }
      else
      {
        return ValidationResult.Success;
      }
    }
  }
}
