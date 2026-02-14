using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using UniversityWeatherApp.Framework.UI;
using UniversityWeatherApp.ViewModels.Pages;

namespace UniversityWeatherApp.Views.Pages;

public class DashboardView : Page
{
    public DashboardView() : base()
    {
        DataContext = new DashboardViewModel();
    }

    protected override void Layout()
    {
        
        
        Content = new StackPanel()
        {
            Background = new ImageBrush
            {
                Source = new Bitmap(
                    AssetLoader.Open(new Uri("avares://UniversityWeatherApp/Assets/Background/Snow.png"))
                ),
                Stretch = Stretch.UniformToFill
            },
            Children =
            {
                
            }
        };
    }
}
