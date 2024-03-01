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
        // Getting property
        PropertyInfo? productsProperty = validationContext.ObjectType.GetProperty(nameof(Order.Products));

        if (productsProperty != null)
        {
          // Setting products as value of property
          List<Product> products = (List<Product>)productsProperty.GetValue(validationContext.ObjectInstance)!;

          double totalPrice = 0;
          foreach (Product product in products)
          {
            // Calculating total price
            totalPrice += product.Price * product.Quantity;
          }

          // Actual Price from property which has Custom Attribute
          double actualPrice = (double)value!;

          if (totalPrice > 0)
          {
            if (actualPrice != totalPrice)
            {
              return new ValidationResult("Invoice Price should be equal to all product's price and quantities.");
            }

          }
          else
          {
            return new ValidationResult("No products has been found to calculate price.");
          }

          return ValidationResult.Success;
        }

        return null;
      }
      return null;
    }

  }
}
