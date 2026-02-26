using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Layout;
using Avalonia.Markup.Declarative;
using Avalonia.Styling;
using UniversityWeatherApp.Framework.UI.Extensions;
using UniversityWeatherApp.ViewModels.Components.Dashboard;

namespace UniversityWeatherApp.Views.Components.Dashboard;

public class CurrentWeatherOverviewView : Framework.Mvvm.ViewBase<StackPanel>
{
    public CurrentWeatherOverviewView(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        DataContext = new CurrentWeatherOverviewViewModel(_serviceProvider!);
    }

    protected override void LayoutStyles()
    {
        Root.Orientation(Orientation.Horizontal);
        Root.Spacing(10);

        Styles.Add(
            new Style(x => x.Class("Temperature"))
                .Add(TextBlock.FontSizeProperty, 100)
        );

        Styles.Add(
            new Style(x => x.Class("Container"))
                .Add(StackPanel.VerticalAlignmentProperty, VerticalAlignment.Center)
        );

        Styles.Add(
            new Style(x => x.Class("City"))
                .Add(TextBlock.FontSizeProperty, 40)
        );
    }

    protected override void Layout()
    {
        Root.Children(
            new TextBlock()
                .Classes("Temperature")
                .Text(new Binding("Temperature")),

            new StackPanel()
                .Classes("Container")
                .Children(
                    new TextBlock()
                        .Classes("City")
                        .Text(new Binding("City")),

                    new TextBlock()
                        .Classes("Date")
                        .Text(new Binding("Date"))
                ),

            new Image()
                .SvgSource(new Binding("WeatherIcon"))
                .Width(67)
                .Height(67)
        );
    }
}