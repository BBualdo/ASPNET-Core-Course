using System.ComponentModel.DataAnnotations;

namespace eCommerceAppExercise.Models
{
  public class Product
  {
    [Required(ErrorMessage = "{0} is required.")]
    [Display(Name = "Product code")]
    [Range(1, int.MaxValue, ErrorMessage = "{0} should be valid number.")]
    public int ProductCode { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    [Range(1, double.MaxValue, ErrorMessage = "{0} should be valid number.")]
    public double Price { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "{0} should be valid number.")]
    public int Quantity { get; set; }
  }
}
