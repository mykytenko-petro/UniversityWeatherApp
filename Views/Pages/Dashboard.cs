using Avalonia.Controls;
using Avalonia.Media;
using UniversityWeatherApp.Framework.UI;
using UniversityWeatherApp.ViewModels.Pages;
using Avalonia.Layout;
using UniversityWeatherApp.Framework.Utils;
using Avalonia.Markup.Declarative;
using Avalonia.Data;
using Avalonia.Styling;
using Avalonia;
using UniversityWeatherApp.Framework.UI.Extensions;

namespace UniversityWeatherApp.Views.Pages;

public class DashboardView : Page
{
    public DashboardView() : base()
    {
        DataContext = new DashboardViewModel();
    }

    protected override void Setup()
    {
        ColumnDefinitions = [
            new ColumnDefinition(new GridLength(64, GridUnitType.Star)),
            new ColumnDefinition(new GridLength(36, GridUnitType.Star))
        ];
    }

    protected override void LayoutStyles()
    {
        Background = new ImageBrush
        {
            Source = ResourceUtils.GetAssetBitmap("Background/Snow.png"),
            Stretch = Stretch.UniformToFill
        };

        Styles.Add(
            new Style(x => x.OfType<TextBlock>())
            {
                Setters =
                {
                    new Setter(TextBlock.FontSizeProperty, 18.0)
                }
            }
        );

        Styles.Add(
            new Style(x => x.Class("SidePanel__ScrollViewer"))
            {
                Setters =
                {
                    new Setter(ScrollViewer.BorderBrushProperty,
                               new SolidColorBrush(Color.FromArgb(36, 255, 255, 255))),
                    new Setter(ScrollViewer.BorderThicknessProperty, new Thickness(5, 0, 0, 0)),
                }
            }
        );
    }

    protected override void Layout()
    {
        // Side panel
        Add(
            new Grid()
                .SetGridColumn(1)
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
