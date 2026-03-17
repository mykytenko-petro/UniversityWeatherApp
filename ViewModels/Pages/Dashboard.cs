using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using UniversityWeatherApp.Framework.Mvvm;
using UniversityWeatherApp.Framework.Utils;
using UniversityWeatherApp.Models.WeatherService;
using UniversityWeatherApp.Services;

namespace UniversityWeatherApp.ViewModels.Pages;

public partial class DashboardViewModel : ViewModelBase
{
    [ObservableProperty]
    private Bitmap _background = ResourceUtils.GetAssetBitmap("Background/Clear.png");

    public DashboardViewModel(IServiceProvider serviceProvider)
    {
        var weatherService = serviceProvider.GetRequiredService<WeatherService>();

        weatherService.OnDataUpdate += UpdateData;
    }

    private void UpdateData(WeatherResponse response)
    {
        var data = response.TodaysWeather;
     
        Console.WriteLine(data.List[0].Weather[0].Main);

        string nameOfImage = data.List[0].Weather[0].Main switch
        {
            "Clear" => "Clear",
            "Clouds" => "Cloudy",
            "Rain" => "Rain",
            "Drizzle" => "Rain",
            "Thunderstorm" => "Thunderstorm",
            "Snow" => "Snow",
            "Atmosphere" => "Mist",
            _ => "Clear"
        };


        Background = ResourceUtils.GetAssetBitmap(
            "Background/" + nameOfImage + ".png");
    }
}