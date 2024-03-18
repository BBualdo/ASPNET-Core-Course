using Microsoft.Extensions.Configuration;
using ServiceContracts;
using System.Text.Json;

namespace Services
{
  public class FinnhubService : IFinnhubService
  {
    private IHttpClientFactory _httpClientFactory;
    private IConfiguration _configuration;
    public FinnhubService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
      _httpClientFactory = httpClientFactory;
      _configuration = configuration;
    }

    private async Task<string> GetStreamFromUrl(string url)
    {
      using (HttpClient client = _httpClientFactory.CreateClient())
      {
        HttpRequestMessage req = new HttpRequestMessage()
        {
          RequestUri = new Uri(url),
          Method = HttpMethod.Get,
        };

        HttpResponseMessage res = await client.SendAsync(req);

        if (!res.IsSuccessStatusCode)
        {
          throw new InvalidOperationException("Couldn't get response from Finnhub server.");
        }

        Stream stream = res.Content.ReadAsStream();
        StreamReader reader = new StreamReader(stream);
        string response = reader.ReadToEnd();
        return response;
      }
    }

    public async Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol)
    {
      string response = await GetStreamFromUrl($"https://finnhub.io/api/v1/stock/profile2?symbol={stockSymbol}&token={_configuration["API_KEY"]}");
      Dictionary<string, object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(response);
      return responseDictionary;

    }


    public async Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
    {
      string response = await GetStreamFromUrl($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={_configuration["API_KEY"]}");
      Dictionary<string, object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(response);
      return responseDictionary;
    }
  }
}
