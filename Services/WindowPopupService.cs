using UniversityWeatherApp.Views.WindowPopups;

namespace UniversityWeatherApp.Services;

public sealed class WindowPopupService
{
    public void CreateErrorPopup(string error)
    {
        new ErrorWindowPopupView(error).Show();
    }
}