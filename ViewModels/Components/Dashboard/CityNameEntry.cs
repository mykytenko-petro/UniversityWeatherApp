using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using UniversityWeatherApp.Framework.Mvvm;
using UniversityWeatherApp.Services;

namespace UniversityWeatherApp.ViewModels.Components.Dashboard;

public partial class CityNameEntryViewModel(IServiceProvider serviceProvider) : ViewModelBase
{
    private readonly WeatherService _weatherService =
        serviceProvider.GetRequiredService<WeatherService>();

    [ObservableProperty]
    private string _city = "2232";

    [RelayCommand]
    private async Task RequestWeather()
    {
        await _weatherService.GetWeather(City);
    }
}