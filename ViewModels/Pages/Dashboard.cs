using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UniversityWeatherApp.Framework.UI.Mvvm;

namespace UniversityWeatherApp.ViewModels.Pages;

public partial class DashboardViewModel : ViewModelBase
{
    [ObservableProperty]
    private int _count = 0;

    [RelayCommand]
    private void Increment()
    {
        Count++;
    }
}