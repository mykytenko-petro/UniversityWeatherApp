using System.Net;
using System.Threading.Tasks;
using UniversityWeatherApp.Framework.Core;
using UniversityWeatherApp.Models.WeatherService;

namespace UniversityWeatherApp.Services;

public sealed class WeatherService(WindowPopupService windowPopupService)
{
    private readonly WindowPopupService _windowPopupService = windowPopupService;

    private readonly RequestClient client = new();

    private readonly string ApiUriRoot = "https://api.openweathermap.org/data/2.5";
    public string? ApiKey;

    public event Action<WeatherResponse>? OnDataUpdate;

    public async Task<HttpStatusCode> Connect(string apiKey)
    {
        HttpStatusCode code = await client.CheckConnection(
            ApiUriRoot
            + "/weather"
            + "?lat=0&lon=0"
            + $"&appid={apiKey}"
        );

        if (code == HttpStatusCode.OK)
        {    
            ApiKey = apiKey;
        }
        else
        {
            Console.WriteLine(code);
        }

        return code;
    }

    public async Task GetWeather(string city)
    {
        try
        {
            CurrentWeatherModel currentWeather = await GetCurrentWeather(city);
            TodaysWeatherModel todaysWeather = await GetTodaysWeather(city);
        
            OnDataUpdate!.Invoke(
                new WeatherResponse
                {
                    CurrentWeather = currentWeather,
                    TodaysWeather = todaysWeather
                }
            );
        }
        catch (HttpNotFoundException)
        {
            _windowPopupService.CreateErrorPopup("there's no such a city");
        }

    }

    private async Task<CurrentWeatherModel> GetCurrentWeather(string city)
    {
        CurrentWeatherModel result = await client.GetAsync<CurrentWeatherModel>(
            ApiUriRoot
            + "/weather"
            + $"?q={city}"
            + $"&appid={ApiKey}"
            + "&units=metric"
        );

        return result;
    }

    private async Task<TodaysWeatherModel> GetTodaysWeather(string city)
    {
        TodaysWeatherModel result = await client.GetAsync<TodaysWeatherModel>(
            ApiUriRoot
            + "/forecast"
            + $"?q={city}"
            + $"&appid={ApiKey}"
            + "&units=metric"
        );

        return result;
    }
}