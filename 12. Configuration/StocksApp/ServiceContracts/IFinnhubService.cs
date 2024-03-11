namespace StocksApp.ServiceContracts
{
  public interface IFinnhubService
  {
    Task<Dictionary<string, object>?> GetStocksPrice(string stockId);
  }
}
