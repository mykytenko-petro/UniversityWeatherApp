using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace UniversityWeatherApp.Services;

public enum ApiStatus
{
    Connected,
    InvalidKey,
    UnknownError
}

public sealed class WeatherService
{
    private readonly string ApiUriRoot = "https://api.openweathermap.org/data/2.5/weather";

    private string? ApiKey;

    public async Task<ApiStatus> Connect(string apiKey)
    {
        using HttpClient client = new();

        HttpResponseMessage message = await client.GetAsync(
            ApiUriRoot
            + "?lat=0&lon=0"
            + $"&appid={apiKey}"
        );

        if (message.StatusCode == HttpStatusCode.OK)
        {    
            ApiKey = apiKey;

            return ApiStatus.Connected;
        }
        else if (message.StatusCode == HttpStatusCode.Unauthorized)
            return ApiStatus.InvalidKey;
        else
            return ApiStatus.UnknownError;
    }
}