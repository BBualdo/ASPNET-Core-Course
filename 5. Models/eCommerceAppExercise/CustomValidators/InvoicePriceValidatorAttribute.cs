using eCommerceAppExercise.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace eCommerceAppExercise.CustomValidators
{
  public class InvoicePriceValidatorAttribute : ValidationAttribute
  {
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
      if (value != null)
      {
        PropertyInfo? productsProperty = validationContext.ObjectType.GetProperty(nameof(Order.Products));

        if (productsProperty != null)
        {
          List<Product> products = (List<Product>)productsProperty.GetValue(validationContext.ObjectInstance)!;

          double totalPrice = 0;

          foreach (Product product in products)
          {
            totalPrice += product.Price * product.Quantity;
          }

          if (totalPrice > 0)
          {
            double actualPrice = (double)value;

            if (actualPrice != totalPrice)
            {
              return new ValidationResult("The InvoicePrice is not equal to calculated price.");
            }
          }
          else
          {
            return new ValidationResult("Not found any products to calculate.");
          }

          return ValidationResult.Success;

        }
        return null;
      }
      return null;
    }
  }
}
