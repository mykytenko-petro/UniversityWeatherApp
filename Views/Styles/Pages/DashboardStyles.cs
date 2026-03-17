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

    protected override void Widgets()
    {
        Add(
            new Style(x => x.Class("Logo"))
                .Add(Panel.WidthProperty, 80)
                .Add(Panel.HeightProperty, 80)
        );
    }
}