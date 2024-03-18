using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Helpers;

namespace Services
{
  public class StocksService : IStocksService
  {
    private readonly List<BuyOrder> _buyOrders;
    private readonly List<SellOrder> _sellOrders;

    public StocksService()
    {
      _buyOrders = new List<BuyOrder>();
      _sellOrders = new List<SellOrder>();
    }
    public Task<BuyOrderResponse> CreateBuyOrder(BuyOrderRequest? request)
    {
      if (request == null) throw new ArgumentNullException(nameof(request));
      if (request.StockSymbol == null) throw new ArgumentException(nameof(request.StockSymbol));

      ValidationHelper.ModelValidation(request);

      BuyOrder buyOrderToAdd = request.ToBuyOrder();
      buyOrderToAdd.ID = Guid.NewGuid();
      _buyOrders.Add(buyOrderToAdd);

      return Task.FromResult(buyOrderToAdd.ToBuyOrderResponse());
    }

    public Task<SellOrderResponse> CreateSellOrder(SellOrderRequest? request)
    {
      if (request == null) throw new ArgumentNullException(nameof(request));
      if (request.StockSymbol == null) throw new ArgumentException(nameof(request.StockSymbol));

      ValidationHelper.ModelValidation(request);

      SellOrder sellOrderToAdd = request.ToSellOrder();
      sellOrderToAdd.ID = Guid.NewGuid();
      _sellOrders.Add(sellOrderToAdd);

      return Task.FromResult(sellOrderToAdd.ToSellOrderResponse());
    }

    public Task<List<BuyOrderResponse>> GetBuyOrders()
    {
      return Task.FromResult(_buyOrders.Select(order => order.ToBuyOrderResponse()).ToList());
    }

    public Task<List<SellOrderResponse>> GetSellOrders()
    {
      return Task.FromResult(_sellOrders.Select(order => order.ToSellOrderResponse()).ToList());
    }
  }
}

