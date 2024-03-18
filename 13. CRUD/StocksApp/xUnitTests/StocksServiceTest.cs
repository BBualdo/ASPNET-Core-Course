using ServiceContracts;
using ServiceContracts.DTO;
using Services;

namespace xUnitTests
{
  public class StocksServiceTest
  {
    private readonly IStocksService _stocksService;

    public StocksServiceTest()
    {
      _stocksService = new StocksService();
    }

    #region CreateBuyOrder
    [Fact]
    public async void CreateBuyOrder_NullReq()
    {
      // Arrange
      BuyOrderRequest? request = null;

      // Assert
      await Assert.ThrowsAsync<ArgumentNullException>(async () =>
      {
        // Act
        await _stocksService.CreateBuyOrder(request);
      });
    }

    [Fact]
    public async void CreateBuyOrder_Quantity0()
    {
      // Arrange
      BuyOrderRequest? request = new BuyOrderRequest()
      {
        Quantity = 0
      };

      // Assert
      await Assert.ThrowsAsync<ArgumentException>(async () =>
       {
         // Act
         await _stocksService.CreateBuyOrder(request);
       });
    }

    [Fact]
    public async void CreateBuyOrder_Quantity10001()
    {
      // Arrange
      BuyOrderRequest? request = new BuyOrderRequest()
      {
        Quantity = 10001
      };

      // Assert
      await Assert.ThrowsAsync<ArgumentException>(async () =>
      {
        // Act
        await _stocksService.CreateBuyOrder(request);
      });
    }

    [Fact]
    public async void CreateBuyOrder_Price0()
    {
      // Arrange
      BuyOrderRequest? request = new BuyOrderRequest()
      {
        Price = 0
      };

      // Assert
      await Assert.ThrowsAsync<ArgumentException>(async () =>
      {
        // Act
        await _stocksService.CreateBuyOrder(request);
      });
    }

    [Fact]
    public async void CreateBuyOrder_Price10001()
    {
      // Arrange
      BuyOrderRequest? request = new BuyOrderRequest()
      {
        Price = 10001
      };

      // Assert
      await Assert.ThrowsAsync<ArgumentException>(async () =>
      {
        // Act
        await _stocksService.CreateBuyOrder(request);
      });
    }

    [Fact]
    public async void CreateBuyOrder_NullSymbol()
    {
      // Arrange
      BuyOrderRequest? request = new BuyOrderRequest()
      {
        StockSymbol = null
      };

      // Assert
      await Assert.ThrowsAsync<ArgumentException>(async () =>
      {
        // Act
        await _stocksService.CreateBuyOrder(request);
      });
    }

    [Fact]
    public async void CreateBuyOrder_InvalidDate()
    {
      // Arrange
      BuyOrderRequest? request = new BuyOrderRequest()
      {
        DateAndTimeOfOrder = new DateTime(1999, 12, 31)
      };

      // Assert
      await Assert.ThrowsAsync<ArgumentException>(async () =>
      {
        // Act
        await _stocksService.CreateBuyOrder(request);
      });
    }

    [Fact]
    public async void CreateBuyOrder_Valid()
    {
      // Arrange
      BuyOrderRequest request = new BuyOrderRequest()
      {
        StockSymbol = "MSFT",
        StockName = "Microsoft",
        DateAndTimeOfOrder = DateTime.Now,
        Price = 2452,
        Quantity = 10
      };

      // Act
      BuyOrderResponse response = await _stocksService.CreateBuyOrder(request);

      // Assert
      Assert.True(response.ID != Guid.Empty);
    }
    #endregion

    #region CreateSellOrder
    [Fact]
    public async void CreateSellOrder_NullReq()
    {
      // Arrange
      SellOrderRequest? request = null;

      // Assert
      await Assert.ThrowsAsync<ArgumentNullException>(async () =>
      {
        // Act
        await _stocksService.CreateSellOrder(request);
      });
    }

    [Fact]
    public async void CreateSellOrder_Quantity0()
    {
      // Arrange
      SellOrderRequest? request = new SellOrderRequest()
      {
        Quantity = 0
      };

      // Assert
      await Assert.ThrowsAsync<ArgumentException>(async () =>
      {
        // Act
        await _stocksService.CreateSellOrder(request);
      });
    }

    [Fact]
    public async void CreateSellOrder_Quantity10001()
    {
      // Arrange
      SellOrderRequest? request = new SellOrderRequest()
      {
        Quantity = 10001
      };

      // Assert
      await Assert.ThrowsAsync<ArgumentException>(async () =>
      {
        // Act
        await _stocksService.CreateSellOrder(request);
      });
    }

    [Fact]
    public async void CreateSellOrder_Price0()
    {
      // Arrange
      SellOrderRequest? request = new SellOrderRequest()
      {
        Price = 0
      };

      // Assert
      await Assert.ThrowsAsync<ArgumentException>(async () =>
      {
        // Act
        await _stocksService.CreateSellOrder(request);
      });
    }

    [Fact]
    public async void CreateSellOrder_Price10001()
    {
      // Arrange
      SellOrderRequest? request = new SellOrderRequest()
      {
        Price = 10001
      };

      // Assert
      await Assert.ThrowsAsync<ArgumentException>(async () =>
      {
        // Act
        await _stocksService.CreateSellOrder(request);
      });
    }

    [Fact]
    public async void CreateSellOrder_NullSymbol()
    {
      // Arrange
      SellOrderRequest? request = new SellOrderRequest()
      {
        StockSymbol = null
      };

      // Assert
      await Assert.ThrowsAsync<ArgumentException>(async () =>
      {
        // Act
        await _stocksService.CreateSellOrder(request);
      });
    }

    [Fact]
    public async void CreateSellOrder_InvalidDate()
    {
      // Arrange
      SellOrderRequest? request = new SellOrderRequest()
      {
        DateAndTimeOfOrder = new DateTime(1999, 12, 31)
      };

      // Assert
      await Assert.ThrowsAsync<ArgumentException>(async () =>
      {
        // Act
        await _stocksService.CreateSellOrder(request);
      });
    }

    [Fact]
    public async void CreateSellOrder_Valid()
    {
      // Arrange
      SellOrderRequest request = new SellOrderRequest()
      {
        StockSymbol = "MSFT",
        StockName = "Microsoft",
        DateAndTimeOfOrder = DateTime.Now,
        Price = 2452,
        Quantity = 10
      };

      // Act
      SellOrderResponse response = await _stocksService.CreateSellOrder(request);

      // Assert
      Assert.True(response.ID != Guid.Empty);
    }
    #endregion

    #region GetBuyOrders
    [Fact]
    public async void GetBuyOrders_EmptyList()
    {
      // Act
      List<BuyOrderResponse> actualList = await _stocksService.GetBuyOrders();
      // Assert
      Assert.Empty(actualList);
    }

    [Fact]
    public async void GetBuyOrders_Contains()
    {
      // Arrange
      List<BuyOrderRequest> buyOrdersToAdd = new List<BuyOrderRequest> {
        new()
        {
          StockSymbol = "MSFT",
          StockName = "Microsoft",
          DateAndTimeOfOrder = DateTime.Now,
          Price = 2146,
          Quantity = 10
        },
        new()
        {
          StockSymbol = "AAPL",
          StockName = "Apple",
          DateAndTimeOfOrder = DateTime.Now,
          Price = 3256,
          Quantity = 2
        }
      };

      List<BuyOrderResponse> initialList = new List<BuyOrderResponse>();

      foreach (BuyOrderRequest buyOrderToAdd in buyOrdersToAdd)
      {
        BuyOrderResponse addedOrder = await _stocksService.CreateBuyOrder(buyOrderToAdd);
        initialList.Add(addedOrder);
      }

      // Act
      List<BuyOrderResponse> actualList = await _stocksService.GetBuyOrders();
      // Assert

      foreach (BuyOrderResponse expectedBuyOrder in actualList)
      {
        Assert.Contains(expectedBuyOrder, initialList);
      }
    }
    #endregion

    #region GetSellOrders
    [Fact]
    public async void GetSellOrders_EmptyList()
    {
      // Act
      List<SellOrderResponse> actualList = await _stocksService.GetSellOrders();
      // Assert
      Assert.Empty(actualList);
    }

    [Fact]
    public async void GetSellOrders_Contains()
    {
      // Arrange
      List<SellOrderRequest> sellOrdersToAdd = new List<SellOrderRequest> {
        new()
        {
          StockSymbol = "MSFT",
          StockName = "Microsoft",
          DateAndTimeOfOrder = DateTime.Now,
          Price = 2146,
          Quantity = 10
        },
        new()
        {
          StockSymbol = "AAPL",
          StockName = "Apple",
          DateAndTimeOfOrder = DateTime.Now,
          Price = 3256,
          Quantity = 2
        }
      };

      List<SellOrderResponse> initialList = new List<SellOrderResponse>();

      foreach (SellOrderRequest sellOrderToAdd in sellOrdersToAdd)
      {
        SellOrderResponse addedOrder = await _stocksService.CreateSellOrder(sellOrderToAdd);
        initialList.Add(addedOrder);
      }

      // Act
      List<SellOrderResponse> actualList = await _stocksService.GetSellOrders();
      // Assert

      foreach (SellOrderResponse expectedSellOrder in actualList)
      {
        Assert.Contains(expectedSellOrder, initialList);
      }
    }
    #endregion
  }
}