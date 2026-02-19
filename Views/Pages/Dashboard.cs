using Avalonia.Controls;
using Avalonia.Media;
using UniversityWeatherApp.Framework.UI;
using UniversityWeatherApp.Framework.Utils;
using Avalonia.Markup.Declarative;
using UniversityWeatherApp.Framework.UI.Extensions;
using UniversityWeatherApp.Views.Styles.Pages;
using UniversityWeatherApp.Views.Components.Dashboard;

namespace UniversityWeatherApp.Views.Pages;

public class DashboardView : Page
{
    protected override void LayoutStyles()
    {
        RowDefinitions = [
            new RowDefinition(new GridLength(2, GridUnitType.Star)),
            new RowDefinition(new GridLength(80, GridUnitType.Star)),
            new RowDefinition(new GridLength(18, GridUnitType.Star))
        ];

        ColumnDefinitions = [
            new ColumnDefinition(new GridLength(8, GridUnitType.Star)),
            new ColumnDefinition(new GridLength(56, GridUnitType.Star)),
            new ColumnDefinition(new GridLength(36, GridUnitType.Star))
        ];

        Background = new ImageBrush
        {
            Source = ResourceUtils.GetAssetBitmap("Background/Snow.png"),
            Stretch = Stretch.UniformToFill
        };
        
        Styles.Add(new DashboardStyles());
    }

    protected override void Layout()
    {
        // Logo
        Add(
            new Panel()
            {
                Background = new ImageBrush(
                    ResourceUtils.GetAssetBitmap("Icon/Logo.png"))
                    .Stretch(Stretch.Fill)
            }
                .Classes("TopLeft")
                .Classes("Logo")
                .SetGridRow(1)
                .SetGridColumn(1)
        );

        // current weather overview
        Add(
            new CurrentWeatherOverviewView()
                .Classes("TopLeft")
                .SetGridRow(2)
                .SetGridColumn(1)
        );

        // Side panel
        Add(
            new SidePanelView()
                .SetGridColumn(2)
                .SetGridRowSpan(3)
        );
    }
}
