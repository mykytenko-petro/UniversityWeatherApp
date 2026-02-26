using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using UniversityWeatherApp.Models.WeatherService;

namespace UniversityWeatherApp.Services;

public sealed class WeatherService
{
    private readonly HttpClient client= new();

    private readonly string ApiUriRoot = "https://api.openweathermap.org/data/2.5";
    private string? ApiKey;

    public event Action<WeatherResponse>? OnDataUpdate;

    public async Task<HttpStatusCode> Connect(string apiKey)
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
        }
        else
        {
            Console.WriteLine(response.StatusCode);
        }

        return response.StatusCode;
    }

    public async Task GetWeather(string city)
    {
        CurrentWeatherModel currentWeather = await GetCurrentWeather(city);
        TodaysWeatherModel todaysWeather = await GetTodaysWeather(city);

        OnDataUpdate?.Invoke(
            new WeatherResponse
            {
                CurrentWeather = currentWeather,
                TodaysWeather = todaysWeather
            }
        );
    }

    private async Task<CurrentWeatherModel> GetCurrentWeather(string city)
    {
        HttpResponseMessage response = await client.GetAsync(
            ApiUriRoot
            + "/weather"
            + $"?q={city}"
            + $"&appid={ApiKey}"
            + "&units=metric"
        );

        var jsonText = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<CurrentWeatherModel>(jsonText);

        return result!;
    }

    private async Task<TodaysWeatherModel> GetTodaysWeather(string city)
    {
        HttpResponseMessage response = await client.GetAsync(
            ApiUriRoot
            + "/forecast"
            + $"?q={city}"
            + $"&appid={ApiKey}"
            + "&units=metric"
        );

        var jsonText = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<TodaysWeatherModel>(jsonText);

        return result!;
    }
}