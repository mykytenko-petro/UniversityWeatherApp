using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using UniversityWeatherApp.Framework.Mvvm;
using UniversityWeatherApp.Services;

namespace UniversityWeatherApp.ViewModels.Components.Dashboard;

public partial class CityNameInputViewModel(IServiceProvider serviceProvider) : ViewModelBase
{
    private readonly WeatherService _weatherService =
        serviceProvider.GetRequiredService<WeatherService>();

    [ObservableProperty]
    private string _city = "";

    public async Task RequestWeather()
    {
        if (City == "")
            return;
            
        await _weatherService.GetWeather(City);

        City = "";
    }
}