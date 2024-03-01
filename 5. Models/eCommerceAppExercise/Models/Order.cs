using eCommerceAppExercise.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace eCommerceAppExercise.Models
{
  public class Order
  {
    [Range(1, int.MaxValue, ErrorMessage = "{0} should be valid number.")]
    public int OrderNo { get; set; } = new Random().Next(0, 99999);

    [Required(ErrorMessage = "{0} is required.")]
    [Display(Name = "Date of order")]
    public DateTime OrderDate { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "{0} is required.")]
    [Display(Name = "Invoice price")]
    [Range(1, double.MaxValue, ErrorMessage = "{0} should be valid number.")]
    [InvoicePriceValidator]
    public double InvoicePrice { get; set; }

    [Required(ErrorMessage = "{0} are required.")]
    [MinLength(1, ErrorMessage = "There must be at least 1 product in your order.")]
    public List<Product> Products { get; set; }
  }
}
