using CommunityToolkit.Mvvm.ComponentModel;
using UniversityWeatherApp.Framework.Mvvm;

namespace UniversityWeatherApp.ViewModels.Pages;

public partial class DashboardViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _greet = "3323";
}