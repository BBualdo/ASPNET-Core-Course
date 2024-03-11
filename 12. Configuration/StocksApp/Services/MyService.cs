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
          RequestUri = new Uri("url"),
          Method = HttpMethod.Get,
        };

        HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage);
      }
    }
  }
}
