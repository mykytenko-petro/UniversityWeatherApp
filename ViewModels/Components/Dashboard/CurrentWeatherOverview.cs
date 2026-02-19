using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using UniversityWeatherApp.Framework.Mvvm;
using UniversityWeatherApp.Framework.Utils;

namespace UniversityWeatherApp.ViewModels.Components.Dashboard;

public partial class CurrentWeatherOverviewViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _temperature = $"{2232}°";

    [ObservableProperty]
    private string _city = "New York";

    [ObservableProperty]
    private string _date = "8:13 - Tue, 11 Sep '01";

    [ObservableProperty]
    private Bitmap _weatherIcon = ResourceUtils.GetAssetBitmap("WeatherIcon/11d.png");
}