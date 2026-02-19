using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Styling;
using UniversityWeatherApp.Framework.UI;
using UniversityWeatherApp.Framework.UI.Extensions;

namespace UniversityWeatherApp.Views.Styles;

public class AppStyles : ViewStyles
{
    protected override void Controls()
    {
        Add(
            new Style(x => x.OfType<TextBlock>())
                .Add(TextBlock.ForegroundProperty, Brushes.White)
        );
    }

    protected override void Commons()
    {
        Add(
            new Style(x => x.Class("TopLeft"))
                .Add(Panel.HorizontalAlignmentProperty, HorizontalAlignment.Left)
                .Add(Panel.VerticalAlignmentProperty, VerticalAlignment.Top)
        );
    }
}