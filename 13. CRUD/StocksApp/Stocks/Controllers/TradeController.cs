using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ServiceContracts;
using Stocks.Models;
using System.Globalization;

namespace Stocks.Controllers
{
  public class TradeController : Controller
  {
    private TradingOptions _options;
    private IFinnhubService _finnhubService;
    private IStocksService _stocksService;
    public TradeController(IOptions<TradingOptions> options, IFinnhubService finnhubService, IStocksService stocksService)
    {
      _options = options.Value;
      _finnhubService = finnhubService;
      _stocksService = stocksService;
    }

    [Route("/trade")]
    public async Task<IActionResult> Index()
    {
      Dictionary<string, object>? companyDetailsDict = await _finnhubService.GetCompanyProfile(_options.Microsoft);
      Dictionary<string, object>? stockPriceDict = await _finnhubService.GetStockPriceQuote(_options.Microsoft);


      if (stockPriceDict == null || companyDetailsDict == null)
      {
        return BadRequest("Couldn't connect with 'Finnhub' Server.");
      }

      StockTrade stock = new StockTrade()
      {
        StockName = companyDetailsDict["name"].ToString(),
        StockSymbol = companyDetailsDict["ticker"].ToString(),
        Price = Convert.ToDouble(stockPriceDict["c"].ToString(), CultureInfo.InvariantCulture),
        Quantity = 1
      };
      return View(stock);
    }
  }
}
