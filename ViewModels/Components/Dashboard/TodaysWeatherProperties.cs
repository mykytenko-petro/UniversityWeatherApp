using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using UniversityWeatherApp.Models.WeatherService;
using UniversityWeatherApp.Services;

namespace UniversityWeatherApp.ViewModels.Components.Dashboard;

public partial class TodaysWeatherPropertiesViewModel
    : Framework.Mvvm.ViewModelBase
{
    [ObservableProperty]
    private string _description = "loading...";

    [ObservableProperty]
    private string _tempMax = "loading...";

    [ObservableProperty]
    private string _tempMin = "loading...";

    [ObservableProperty]
    private string _humidity = "loading...";

    [ObservableProperty]
    private string _cloudy = "loading...";

    [ObservableProperty]
    private string _wind = "loading...";

    public TodaysWeatherPropertiesViewModel(IServiceProvider serviceProvider)
    {
        var weatherService = serviceProvider.GetRequiredService<WeatherService>();

        weatherService.OnDataUpdate += UpdateData;
    }

    private void UpdateData(WeatherResponse response)
    {
        CurrentWeatherModel currentWeatherModel = response.CurrentWeather;

        Description = currentWeatherModel.Weather[0].Description.ToUpper();
        
        TempMax = FormatTemperature(currentWeatherModel.Main.TempMax);
        TempMin = FormatTemperature(currentWeatherModel.Main.TempMin);

        Humidity = currentWeatherModel.Main.Humidity.ToString() + "%";
        Cloudy = currentWeatherModel.Clouds.All.ToString() + "%";
        Wind = currentWeatherModel.Wind.Speed.ToString() + "km/h";
    }

    private string FormatTemperature(double temp)
    {
        return Math.Round(temp, MidpointRounding.AwayFromZero).ToString() + "°";
    }
}