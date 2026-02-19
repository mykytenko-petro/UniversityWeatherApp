using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Markup.Declarative;
using Avalonia.Media;
using Avalonia.Styling;
using UniversityWeatherApp.Framework.UI.Extensions;
using UniversityWeatherApp.Framework.Utils;

namespace UniversityWeatherApp.Views.Components.Dashboard;

public class SidePanelView : Framework.Mvvm.ViewBase<Grid>
{
    protected override void LayoutStyles()
    {
        Styles.Add(
            new Style(x => x.Class("Line"))
                .Add(ScrollViewer.BorderBrushProperty, Brushes.White)
                .Add(ScrollViewer.BorderThicknessProperty, new Thickness(0, 0, 0, 1))
        );

        Styles.Add(
            new Style(x => x.Class("SidePanel__ScrollViewer"))
                .Add(ScrollViewer.BorderBrushProperty,
                     new SolidColorBrush(Color.FromArgb(36, 255, 255, 255)))
                .Add(ScrollViewer.BorderThicknessProperty, new Thickness(5, 0, 0, 0))
                .Add(ScrollViewer.PaddingProperty, new Thickness(25, 40))
        );
        
        Styles.Add(
            new Style(x => x.Class("SidePanel__ScrollViewer__Inner"))
                .Add(StackPanel.SpacingProperty, 8.0)
                .Add(StackPanel.OrientationProperty, Orientation.Vertical)
        );
    }

    protected override void Layout()
    {
        Root.Children(
        new Border()
            .Background(
                new ImageBrush(
                    ResourceUtils.GetAssetBitmap("Texture/BlurredBackground.png"))
                    .Stretch(Stretch.Fill)
                    .Opacity(0.4)
            ),

        new ScrollViewer()
            .Classes("SidePanel__ScrollViewer")

            .Content(
                new StackPanel()
                    .Classes("SidePanel__ScrollViewer__Inner")
                
                    .Children(
                        new Border().Classes("Line"),

                        new TextBlock()
                            .Text("Weather Details..."),
                        
                        new Border().Classes("Line"),

                        new TextBlock()
                            .Text("Today’s Weather Forecast...")
                    )
                )
        );
    }
}