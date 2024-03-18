using Entities;

namespace ServiceContracts.DTO
{
  public class SellOrderResponse
  {
    public Guid ID { get; set; }
    public string? StockSymbol { get; set; }
    public string? StockName { get; set; }
    public DateTime DateAndTimeOfOrder { get; set; }
    public uint Quantity { get; set; }
    public double Price { get; set; }

    public override bool Equals(object? obj)
    {
      if (obj == null) return false;
      SellOrderResponse? sellOrderToCompare = obj as SellOrderResponse;
      if (sellOrderToCompare == null) return false;

      return sellOrderToCompare.ID == ID;
    }

    public override int GetHashCode()
    {
      throw new NotImplementedException();
    }
  }

  public static class SellOrderExtensions
  {
    public static SellOrderResponse ToSellOrderResponse(this SellOrder sellOrder)
    {
      return new SellOrderResponse() { ID = sellOrder.ID, StockName = sellOrder.StockSymbol, StockSymbol = sellOrder.StockSymbol, Price = sellOrder.Price, DateAndTimeOfOrder = sellOrder.DateAndTimeOfOrder, Quantity = sellOrder.Quantity };
    }
  }
}
