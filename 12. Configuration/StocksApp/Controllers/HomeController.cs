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

      Dictionary<string, object>? stockPriceDictionary = await _finnhubService.GetStockPriceQuote(_stockOptions.Microsoft);
      Dictionary<string, object>? companyProfileDictionary = await _finnhubService.GetCompanyProfile(_stockOptions.Microsoft);

      if (stockPriceDictionary == null || companyProfileDictionary == null)
      {
        throw new InvalidOperationException("Cannot get response from Finnhub server.");
      }

      Stock stock = new Stock()
      {
        LogoURL = companyProfileDictionary["logo"].ToString(),
        Symbol = companyProfileDictionary["ticker"].ToString(),
        Name = companyProfileDictionary["name"].ToString(),
        CurrentPrice = Convert.ToDouble(stockPriceDictionary["c"].ToString(), CultureInfo.InvariantCulture),
        HighestPrice = Convert.ToDouble(stockPriceDictionary["h"].ToString(), CultureInfo.InvariantCulture),
        LowestPrice = Convert.ToDouble(stockPriceDictionary["l"].ToString(), CultureInfo.InvariantCulture),
        OpenPrice = Convert.ToDouble(stockPriceDictionary["o"].ToString(), CultureInfo.InvariantCulture),
      };

      return View(stock);
    }
  }
}
