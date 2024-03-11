using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StocksApp.Models;
using StocksApp.ServiceContracts;
using System.Globalization;

namespace StocksApp.Controllers
{
  public class HomeController : Controller
  {
    private readonly IFinnhubService _finnhubService;
    private readonly StockOptions _stockOptions;
    public HomeController(IFinnhubService finnhubService, IOptions<StockOptions> stockOptions)
    {
      _finnhubService = finnhubService;
      _stockOptions = stockOptions.Value;
    }
    [Route("/")]
    public async Task<IActionResult> Index()
    {
      if (_stockOptions.Microsoft == null)
      {
        _stockOptions.Microsoft = "MSFT";
      }

      if (_stockOptions.Apple == null)
      {
        _stockOptions.Apple = "AAPL";
      }

      Dictionary<string, object>? stockPriceDictionary = await _finnhubService.GetStocksPrice(_stockOptions.Microsoft);

      if (stockPriceDictionary == null)
      {
        throw new InvalidOperationException("Cannot get response from Finnhub server.");
      }

      Stock microsoftStock = new Stock()
      {
        Symbol = _stockOptions.Microsoft,
        Name = "Microsoft",
        CurrentPrice = Convert.ToDouble(stockPriceDictionary["c"].ToString(), CultureInfo.InvariantCulture),
        HighestPrice = Convert.ToDouble(stockPriceDictionary["h"].ToString(), CultureInfo.InvariantCulture),
        LowestPrice = Convert.ToDouble(stockPriceDictionary["l"].ToString(), CultureInfo.InvariantCulture),
        OpenPrice = Convert.ToDouble(stockPriceDictionary["o"].ToString(), CultureInfo.InvariantCulture),
      };

      return View(microsoftStock);
    }
  }
}
