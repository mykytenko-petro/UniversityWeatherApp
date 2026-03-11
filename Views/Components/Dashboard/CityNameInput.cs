using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Layout;
using Avalonia.Markup.Declarative;
using Avalonia.Media;
using Avalonia.Styling;
using UniversityWeatherApp.Framework.UI.Extensions;
using UniversityWeatherApp.ViewModels.Components.Dashboard;

namespace UniversityWeatherApp.Views.Components.Dashboard;

public class CityNameInputView
    : Framework.Mvvm.ViewBase<StackPanel>
{
    private readonly CityNameInputViewModel vm;

    public CityNameInputView(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        vm = new CityNameInputViewModel(_serviceProvider!);
        DataContext = vm;
    }

    protected override void LayoutStyles()
    {
        Root.Orientation(Orientation.Horizontal);

        Styles.Add(
            new Style(x => x.OfType<TextBox>())
                .Add(TextBox.BackgroundProperty, Brushes.Transparent)
                .Add(TextBox.BorderThicknessProperty, new Thickness(0))
        );
    }

    protected override void Layout()
    {
        Root.Children(            
            new TextBox()
                .Width(420)
                .Text(new Binding("City"))
                .Watermark("Search Location..."),

            new Button()
                .Background(Brushes.Transparent)

                .OnClick(async args => { await vm.RequestWeather(); })
                .Content(
                    new Image()
                        .SvgSource("Icon/Search.svg")
                        .Width(20)
                        .Height(20)
                )
        );
    }
}