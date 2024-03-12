using StocksApp.ServiceContracts;
using System.Text.Json;

namespace StocksApp.Services
{
  public class FinnhubService : IFinnhubService
  {
    private readonly IHttpClientFactory _httpClientFactory;
    private IConfiguration _configuration;

    public FinnhubService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
      _httpClientFactory = httpClientFactory;
      _configuration = configuration;
    }

    public async Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
    {
      using (HttpClient client = _httpClientFactory.CreateClient())
      {
        HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
        {
          RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={_configuration["API_KEY"]}"),
          Method = HttpMethod.Get,
        };

        HttpResponseMessage responseMessage = await client.SendAsync(httpRequestMessage);
        if (!responseMessage.IsSuccessStatusCode)
        {
          throw new InvalidOperationException("Cannot get response from Finnhub server.");
        }
        Stream stream = responseMessage.Content.ReadAsStream();
        StreamReader reader = new StreamReader(stream);
        string response = reader.ReadToEnd();

        Dictionary<string, object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>?>(response);

        return responseDictionary;
      }
    }

    public async Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol)
    {
      using (HttpClient client = _httpClientFactory.CreateClient())
      {
        HttpRequestMessage requestMessage = new HttpRequestMessage()
        {
          RequestUri = new Uri($"https://finnhub.io/api/v1/stock/profile2?symbol={stockSymbol}&token={_configuration["API_KEY"]}"),
          Method = HttpMethod.Get,
        };

        HttpResponseMessage responseMessage = await client.SendAsync(requestMessage);
        if (!responseMessage.IsSuccessStatusCode)
        {
          throw new InvalidOperationException("Cannot get response from Finnhub server.");
        }
        Stream stream = responseMessage.Content.ReadAsStream();
        StreamReader reader = new StreamReader(stream);
        string response = reader.ReadToEnd();

        Dictionary<string, object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>?>(response);

        return responseDictionary;
      }
    }
  }



}
