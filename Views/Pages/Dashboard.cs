using Avalonia.Controls;
using Avalonia.Media;
using UniversityWeatherApp.Framework.UI;
using UniversityWeatherApp.ViewModels.Pages;
using Avalonia.Layout;
using UniversityWeatherApp.Framework.Utils;
using Avalonia;

namespace UniversityWeatherApp.Views.Pages;

public class DashboardView : Page
{
    public DashboardView() : base()
    {
        DataContext = new DashboardViewModel();
    }

    protected override void Layout()
    {
        Background = new ImageBrush
        {
            Source = ResourceUtils.GetAssetBitmap("Background/Snow.png"),
            Stretch = Stretch.UniformToFill
        };

        var sidePanel = new StackPanel
        {
            Background = Brushes.White,
            Opacity = 0.3,
            Effect = new BlurEffect
            {
                Radius = 19
            },
            Children =
            {
                new Label { Content = $"Button ", Margin = new Thickness(5) }
            }
        };

        // for (int i = 1; i <= 20; i++)
        // {
        //     sidePanel.Children.Add();
        // }

        var sidePanelScrollViewer = new ScrollViewer
        {
            Width = 526,

            HorizontalAlignment = HorizontalAlignment.Right,
            VerticalAlignment = VerticalAlignment.Stretch,

            BorderBrush = new SolidColorBrush(Colors.White, 0.5),
            BorderThickness = new Thickness(5, 0, 0, 0),

            Content = sidePanel
        };
        Children.Add(sidePanelScrollViewer);
    }
}
