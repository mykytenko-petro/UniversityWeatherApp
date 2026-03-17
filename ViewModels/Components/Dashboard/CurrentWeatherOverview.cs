using System.Globalization;
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

        Temperature = FormatUtils.FormatTemperature(data.Main.Temp);
        City = data.Name;
        Date = FormatTime(data.Dt, data.Timezone);
        WeatherIcon = ResourceUtils.GetSvgImage(
            "WeatherIcon/" + data.Weather[0].Icon + ".svg");
    }

    private string FormatTime(long time, int timezone)
    {
        return DateTimeOffset.FromUnixTimeSeconds(time + timezone)
            .ToString("HH:mm - dddd, d MMM ‘yy", CultureInfo.InvariantCulture);
    }
}