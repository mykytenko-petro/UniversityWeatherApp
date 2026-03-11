using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Markup.Declarative;
using Avalonia.Media;
using Avalonia.Styling;
using UniversityWeatherApp.Framework.UI.Extensions;
using UniversityWeatherApp.Framework.Utils;

namespace UniversityWeatherApp.Views.Components.Dashboard;

public class SidePanelView(IServiceProvider serviceProvider)
    : Framework.Mvvm.ViewBase<Grid>(serviceProvider)
{
    protected override void LayoutStyles()
    {
        Styles.Add(
            new Style(x => x.Class("Border"))
                .Add(ScrollViewer.BorderBrushProperty,
                     new SolidColorBrush(Color.FromArgb(36, 255, 255, 255)))
                .Add(ScrollViewer.BorderThicknessProperty, new Thickness(3, 0, 0, 0))
        );

        Styles.Add(
            new Style(x => x.Class("Line"))
                .Add(Border.HeightProperty, 15)
                .Add(Border.BorderBrushProperty, Brushes.White)
                .Add(Border.BorderThicknessProperty, new Thickness(0, 1, 0, 0))
        );

        Styles.Add(
            new Style(x => x.Class("ScrollViewer"))
                .Add(ScrollViewer.PaddingProperty, new Thickness(25, 40))
        );
        
        Styles.Add(
            new Style(x => x.Class("ScrollViewer").OfType<StackPanel>())
                .Add(StackPanel.SpacingProperty, 8.0)
                .Add(StackPanel.OrientationProperty, Orientation.Vertical)
        );
    }

    protected override void Layout()
    {
        Root.Children(
            new Border()
                .Classes("Border")

                .Background(
                    new ImageBrush(
                        ResourceUtils.GetAssetBitmap("Texture/BlurredBackground.png"))
                        .Stretch(Stretch.Fill)
                        .Opacity(0.4)
                ),

            new ScrollViewer()
                .Classes("ScrollViewer")

                .Content(
                    new StackPanel()                    
                        .Children(
                            new CityNameInputView(_serviceProvider!),

                            new Border().Classes("Line"),

                            new TextBlock()
                                .Text("Weather Details..."),

                            new TodaysWeatherPropertiesView(_serviceProvider!),
                            
                            new Border().Classes("Line"),

                            new TextBlock()
                                .Text("Today’s Weather Forecast...")
                        )
                )
        );
    }
}