using Avalonia.Svg;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using UniversityWeatherApp.Framework.Mvvm;
using UniversityWeatherApp.Framework.Utils;
using UniversityWeatherApp.Models.WeatherService;
using UniversityWeatherApp.Services;

namespace UniversityWeatherApp.ViewModels.Components.Dashboard;

public partial class CurrentWeatherOverviewViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _temperature = "loading...";

    [ObservableProperty]
    private string _city = "loading...";

    [ObservableProperty]
    private string _date = "loading...";

    [ObservableProperty]
    private SvgImage _weatherIcon = ResourceUtils.GetSvgImage("WeatherIcon/50d.svg");

    public CurrentWeatherOverviewViewModel(IServiceProvider serviceProvider)
    {
        var weatherService = serviceProvider.GetRequiredService<WeatherService>();

        weatherService.OnDataUpdate += UpdateData;
    }

    private void UpdateData(WeatherResponse response)
    {
        CurrentWeatherModel data = response.CurrentWeather;

        Temperature = $"{data.Main.Temp}°";
        City = data.Name;
        Date = $"{data.Dt}";
        WeatherIcon = ResourceUtils.GetSvgImage(
            "WeatherIcon/" + data.Weather[0].Icon + ".svg");
    }
}