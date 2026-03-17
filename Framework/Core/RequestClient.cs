using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace UniversityWeatherApp.Framework.Core;

public class HttpNotFoundException : Exception;

public class RequestClient
{
    private readonly HttpClient _client = new();

    public async Task<HttpStatusCode> CheckConnection(string url)
    {
        HttpResponseMessage response = await _client.GetAsync(url);

        return response.StatusCode;
    }

    public async Task<T> GetAsync<T>(string url)
    {
        HttpResponseMessage response = await _client.GetAsync(url);

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            throw new HttpNotFoundException();
        }
        else if (response.StatusCode != HttpStatusCode.OK)
        {
            Console.WriteLine(response.StatusCode);
        }

        var jsonText = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<T>(jsonText);

        return result!;
    }
}