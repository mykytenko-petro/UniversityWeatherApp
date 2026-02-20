using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Layout;
using Avalonia.Markup.Declarative;
using UniversityWeatherApp.Framework.UI.Extensions;
using UniversityWeatherApp.ViewModels.Components.Dashboard;

namespace UniversityWeatherApp.Views.Components.Dashboard;

public class CurrentWeatherOverviewView : Framework.Mvvm.ViewBase<StackPanel>
{
    public CurrentWeatherOverviewView()
    {
        DataContext = new CurrentWeatherOverviewViewModel();
    }

    protected override void LayoutStyles()
    {
        Root.Orientation(Orientation.Horizontal);
    }

    protected override void Layout()
    {
        Root.Children(
            new TextBlock()
                .Text(new Binding("Temperature")),

            new StackPanel()
                .Children(
                    new TextBlock()
                        .Text(new Binding("City")),

                    new TextBlock()
                        .Text(new Binding("Date"))
                ),

            new Image()
                .SvgSource(new Binding("WeatherIcon"))
                .Width(67)
                .Height(67)
        );
    }
}