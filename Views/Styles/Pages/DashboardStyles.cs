using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Styling;
using UniversityWeatherApp.Framework.UI;
using UniversityWeatherApp.Framework.UI.Extensions;

namespace UniversityWeatherApp.Views.Styles.Pages;

public class DashboardStyles : ViewStyles
{
    protected override void Controls()
    {
        Add(
            new Style(x => x.OfType<TextBlock>())
                .Add(TextBlock.FontSizeProperty, 16)
                .Add(TextBlock.FontWeightProperty, FontWeight.Regular)
        );
    }

    protected override void Commons()
    {
        Add(
            new Style(x => x.Class("Line"))
                .Add(ScrollViewer.BorderBrushProperty, Brushes.White)
                .Add(ScrollViewer.BorderThicknessProperty, new Thickness(0, 0, 0, 1))
        );
    }

    protected override void Widgets()
    {
        Add(
            new Style(x => x.Class("Logo"))
                .Add(Panel.WidthProperty, 80)
                .Add(Panel.HeightProperty, 80)
                .Add(Panel.HorizontalAlignmentProperty, HorizontalAlignment.Left)
                .Add(Panel.VerticalAlignmentProperty, VerticalAlignment.Top)
        );

        Add(
            new Style(x => x.Class("SidePanel__ScrollViewer"))
                .Add(ScrollViewer.BorderBrushProperty,
                     new SolidColorBrush(Color.FromArgb(36, 255, 255, 255)))
                .Add(ScrollViewer.BorderThicknessProperty, new Thickness(5, 0, 0, 0))
                .Add(ScrollViewer.PaddingProperty, new Thickness(25, 40))
        );

        Add(
            new Style(x => x.Class("SidePanel__ScrollViewer__Inner"))
                .Add(StackPanel.SpacingProperty, 8.0)
                .Add(StackPanel.OrientationProperty, Orientation.Vertical)
        );
    }
}