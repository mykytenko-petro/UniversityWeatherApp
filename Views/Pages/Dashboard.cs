using Avalonia.Controls;
using Avalonia.Media;
using UniversityWeatherApp.Framework.UI;
using UniversityWeatherApp.ViewModels.Pages;
using Avalonia.Layout;
using UniversityWeatherApp.Framework.Utils;
using Avalonia.Markup.Declarative;
using Avalonia.Data;

namespace UniversityWeatherApp.Views.Pages;

public class DashboardView : Page
{
    public DashboardView() : base()
    {
        DataContext = new DashboardViewModel();
    }

    protected override void Setup()
    {
        Background = new ImageBrush
        {
            Source = ResourceUtils.GetAssetBitmap("Background/Snow.png"),
            Stretch = Stretch.UniformToFill
        };
    }

    protected override void Layout()
    {
        // Side panel
        Children.Add(
            new Grid()
                .Width(526)
                .HorizontalAlignment(HorizontalAlignment.Right)
                .VerticalAlignment(VerticalAlignment.Stretch)

                .Children(
                    new Border()
                        .Background(
                            new ImageBrush(
                                ResourceUtils.GetAssetBitmap("Texture/BlurredBackground.png"))
                                .Stretch(Stretch.Fill)
                                .Opacity(0.4)
                        ),

                    new ScrollViewer().Content(
                        new StackPanel()
                            .Spacing(8)
                            .Orientation(Orientation.Vertical)
                            .Children(
                                new TextBlock()
                                    .Text(new Binding("Greet")),
                                new TextBlock()
                                    .Text("2232")
                            ))
                )
        );
    }
}
