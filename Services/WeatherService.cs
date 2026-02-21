using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using UniversityWeatherApp.Models.WeatherService;

namespace UniversityWeatherApp.Services;

public enum ApiStatus
{
    Connected,
    InvalidKey,
    UnknownError
}

public sealed class WeatherService
{
    private readonly HttpClient client= new();

    private readonly string ApiUriRoot = "https://api.openweathermap.org/data/2.5";
    private string? ApiKey;

    public async Task<ApiStatus> Connect(string apiKey)
    {
        HttpResponseMessage response = await client.GetAsync(
            ApiUriRoot
            + "/weather"
            + "?lat=0&lon=0"
            + $"&appid={apiKey}"
        );

        if (response.StatusCode == HttpStatusCode.OK)
        {    
            ApiKey = apiKey;

            return ApiStatus.Connected;
        }
        else if (response.StatusCode == HttpStatusCode.Unauthorized)
            return ApiStatus.InvalidKey;
        else
        {
            Console.WriteLine(response.StatusCode);

            return ApiStatus.UnknownError;
        }
    }

    public async Task<TodaysWeatherModel> GetTodaysWeather(string city)
    {
        using HttpClient client = new();

        HttpResponseMessage response = await client.GetAsync(
            ApiUriRoot
            + "/forecast"
            + $"?q={city}"
            + $"&appid={ApiKey}"
            + "&units=metric"
        );

        var jsonText = await response.Content.ReadAsStringAsync();
        Console.WriteLine(jsonText);

        var result = JsonSerializer.Deserialize<TodaysWeatherModel>(jsonText);

        return result;
    }
}