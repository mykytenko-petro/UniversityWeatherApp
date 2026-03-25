using System.IO;
using System.Threading.Tasks;
using UniversityWeatherApp.Models;

namespace UniversityWeatherApp.Services;

public sealed class ApiKeyService(
    NavigationService navigationService,
    WeatherService weatherService,
    StorageService storageService,
    DebugService debugService
)
{
    private readonly NavigationService _navigationService = navigationService;
    private readonly WeatherService _weatherService = weatherService;
    private readonly StorageService _storageService = storageService;
    private readonly DebugService _debugService = debugService;

    private string? _apiKey;

    public async Task Setup()
    {
        if (_debugService.Debug)
        {
            _apiKey = _debugService.EvnVariables!["OPEN_WEATHER_MAP_API_KEY"];
        }
        else
        {
            try
            {    
                var settingsModel = _storageService.ReadData<SettingsModel>("settings.json");

                _apiKey = settingsModel.ApiKey!;
            }
            catch (FileNotFoundException)
            {
                _navigationService.ChangePage("Settings");
                
                return;
            }
        }

        var isValid = await _weatherService.Connect(_apiKey);

        if (isValid == System.Net.HttpStatusCode.OK)
        {
            var settingsModel = _storageService.ReadData<SettingsModel>("settings.json");

            await _weatherService.GetWeather(settingsModel.LastPickedCity);
            _navigationService.ChangePage("Dashboard");
        }
        else
        {
            _navigationService.ChangePage("Settings");
        }
    }
}