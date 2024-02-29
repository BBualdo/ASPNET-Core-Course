using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelValidationExample.Custom_Validators
{
  public class DateRangeAttribute : ValidationAttribute
  {
    public string OtherProperty { get; set; }

    public DateRangeAttribute(string otherProperty)
    {
      OtherProperty = otherProperty;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
      if (value != null)
      {
        DateTime toDate = (DateTime)value;

        // C# Reflection

        // In this way we get access to specific property passed as argument to DateRange() attribute
        PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherProperty);

        if (otherProperty != null)
        {
          // Here we get property (FromDate) value based on that prop value of the object instance created via model binding
          DateTime fromDate = Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance));
          if (fromDate > toDate)
          {
            return new ValidationResult(ErrorMessage, new string[] { OtherProperty, validationContext.MemberName });
          }
          else
          {
            return ValidationResult.Success;
          }
        }
        return null;
      }
      return null;
    }
  }
}
