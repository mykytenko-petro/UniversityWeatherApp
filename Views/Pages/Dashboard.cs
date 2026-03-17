using Avalonia.Controls;
using Avalonia.Media;
using UniversityWeatherApp.Framework.UI;
using Avalonia.Markup.Declarative;
using UniversityWeatherApp.Framework.UI.Extensions;
using UniversityWeatherApp.Views.Styles.Pages;
using UniversityWeatherApp.Views.Components.Dashboard;
using UniversityWeatherApp.ViewModels.Pages;
using Avalonia.Data;

namespace UniversityWeatherApp.Views.Pages;

public class DashboardView : Page
{
    public DashboardView(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        DataContext = new DashboardViewModel(serviceProvider);

        OwnLayoutStyles();
    }

    private void OwnLayoutStyles()
    {
        RowDefinitions = [
            new RowDefinition(new GridLength(2, GridUnitType.Star)),
            new RowDefinition(new GridLength(70, GridUnitType.Star)),
            new RowDefinition(new GridLength(28, GridUnitType.Star))
        ];

        ColumnDefinitions = [
            new ColumnDefinition(new GridLength(8, GridUnitType.Star)),
            new ColumnDefinition(new GridLength(56, GridUnitType.Star)),
            new ColumnDefinition(new GridLength(36, GridUnitType.Star))
        ];

        var brush = new ImageBrush
        {
            Stretch = Stretch.UniformToFill
        };
        brush.Bind(ImageBrush.SourceProperty,
            new Binding("Background")
            {
                Source = DataContext
            }
        );

        Background = brush;
        
        Styles.Add(new DashboardStyles());
    }

    protected override void Layout()
    {
        // Logo
        Add(
            new Image()
                .SvgSource("Icon/Logo.svg")
                .Classes("TopLeft")
                .Classes("Logo")
                .SetGridRow(1)
                .SetGridColumn(1)
        );

        // current weather overview
        Add(
            new CurrentWeatherOverviewView(_serviceProvider!)
                .Classes("TopLeft")
                .SetGridRow(2)
                .SetGridColumn(1)
        );

        // Side panel
        Add(
            new SidePanelView(_serviceProvider!)
                .SetGridColumn(2)
                .SetGridRowSpan(3)
        );
    }
}
