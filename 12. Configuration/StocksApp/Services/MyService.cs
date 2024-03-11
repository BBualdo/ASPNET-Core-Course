namespace StocksApp.Services
{
  public class MyService
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public MyService(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task Method()
    {
      using (HttpClient client = _httpClientFactory.CreateClient())
      {
        HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
        {
          RequestUri = new Uri("https://finnhub.io/api/v1/quote?symbol=AAPL&token=cnngqm9r01qpkl7d088gcnngqm9r01qpkl7d0890"),
          Method = HttpMethod.Get,
        };

        HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage);

        Stream stream = httpResponseMessage.Content.ReadAsStream();
        StreamReader reader = new StreamReader(stream);
        string response = reader.ReadToEnd();
      }
    }
  }
}
