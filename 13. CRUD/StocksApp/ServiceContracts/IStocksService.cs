using ServiceContracts.DTO;

namespace ServiceContracts
{
  public interface IStocksService
  {
    /// <summary>
    /// Inserts a new buy order into the database table called 'BuyOrders'.
    /// </summary>
    /// <param name="request">Buy order to add into 'BuyOrders'.</param>
    /// <returns>'BuyOrder' object.</returns>
    Task<BuyOrderResponse> CreateBuyOrder(BuyOrderRequest? request);
    /// <summary>
    /// Inserts a new sell order into the database table called 'SellOrders'.
    /// </summary>
    /// <param name="request">Sell order to add into 'SellOrders'.</param>
    /// <returns>'SellOrder' object.</returns>
    Task<SellOrderResponse> CreateSellOrder(SellOrderRequest? request);
    /// <summary>
    /// Returns the existing list of buy orders retrieved from database table called 'BuyOrders'.
    /// </summary>
    /// <returns></returns>
    Task<List<BuyOrderResponse>> GetBuyOrders();
    /// <summary>
    /// Returns the existing list of sell orders retrieved from database table called 'SellOrders'.
    /// </summary>
    /// <returns></returns>
    Task<List<SellOrderResponse>> GetSellOrders();
  }
}
