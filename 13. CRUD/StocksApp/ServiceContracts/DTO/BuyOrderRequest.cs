using Entities;
using Stocks.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
  public class BuyOrderRequest
  {
    [Required]
    public string? StockSymbol { get; set; }
    [Required]
    public string? StockName { get; set; }
    [MinDate]
    public DateTime DateAndTimeOfOrder { get; set; }
    [Range(1, 10000)]
    public uint Quantity { get; set; }
    [Range(1, 10000)]
    public double Price { get; set; }

    public BuyOrder ToBuyOrder()
    {
      return new BuyOrder()
      {
        StockSymbol = StockSymbol,
        StockName = StockName,
        DateAndTimeOfOrder = DateAndTimeOfOrder,
        Price = Price,
        Quantity = Quantity,
      };
    }
  }
}
