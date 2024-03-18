using Entities;
using Stocks.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
  public class SellOrderRequest
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

    public SellOrder ToSellOrder()
    {
      return new SellOrder() { StockSymbol = StockSymbol, StockName = StockName, Price = Price, DateAndTimeOfOrder = DateAndTimeOfOrder, Quantity = Quantity };
    }
  }
}
