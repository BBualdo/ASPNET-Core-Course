using Entities;

namespace ServiceContracts.DTO
{
  public class BuyOrderResponse
  {
    public Guid ID { get; set; }
    public string? StockSymbol { get; set; }
    public string? StockName { get; set; }
    public DateTime DateAndTimeOfOrder { get; set; }
    public uint Quantity { get; set; }
    public double Price { get; set; }

    public override bool Equals(object? obj)
    {
      if (obj == null)
        return false;
      BuyOrderResponse? buyOrderToCompare = obj as BuyOrderResponse;
      if (buyOrderToCompare == null)
        return false;

      return buyOrderToCompare.ID == ID;
    }

    public override int GetHashCode()
    {
      throw new NotImplementedException();
    }
  }

  public static class BuyOrderExtensions
  {
    public static BuyOrderResponse ToBuyOrderResponse(this BuyOrder buyOrder)
    {
      return new BuyOrderResponse { ID = buyOrder.ID, StockSymbol = buyOrder.StockSymbol, StockName = buyOrder.StockName, DateAndTimeOfOrder = buyOrder.DateAndTimeOfOrder, Quantity = buyOrder.Quantity, Price = buyOrder.Price };
    }
  }
}