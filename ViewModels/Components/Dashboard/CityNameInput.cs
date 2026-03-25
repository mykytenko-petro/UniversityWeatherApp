using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using UniversityWeatherApp.Framework.Mvvm;
using UniversityWeatherApp.Models;
using UniversityWeatherApp.Services;

namespace UniversityWeatherApp.ViewModels.Components.Dashboard;

public partial class CityNameInputViewModel(IServiceProvider serviceProvider) : ViewModelBase
{
    private readonly WeatherService _weatherService =
        serviceProvider.GetRequiredService<WeatherService>();

    private readonly StorageService _storageService =
        serviceProvider.GetRequiredService<StorageService>();

    [ObservableProperty]
    private string _city = "";

    public async Task RequestWeather()
    {
        if (City == "")
            return;
        
        _storageService.WriteData(
            "settings.json",
            new SettingsModel()
            {
                ApiKey = _weatherService.ApiKey!,
                LastPickedCity = City
            }
        );

        await _weatherService.GetWeather(City);

        City = "";
    }
}