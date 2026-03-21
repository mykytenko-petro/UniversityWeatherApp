using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Markup.Declarative;
using Avalonia.Media;
using Avalonia.Styling;
using UniversityWeatherApp.Framework.UI;
using UniversityWeatherApp.Framework.UI.Extensions;
using UniversityWeatherApp.ViewModels.Pages;

namespace UniversityWeatherApp.Views.Pages;

public class SettingsView : Page
{
    private readonly SettingsViewModel vm;

    public SettingsView(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        vm = new SettingsViewModel(serviceProvider);
        DataContext = vm;
    }

    protected override void LayoutStyles()
    {
        Styles.Add(
            new Style(x => x.Class("SearchBar"))
                .Add(Grid.WidthProperty, 400)
                .Add(Grid.HeightProperty, 50)
        );
    }

    protected override void Layout()
    {
        Add(
            new Grid()
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition(9, GridUnitType.Star),
                    new ColumnDefinition(1, GridUnitType.Star)
                }
            }
                .Classes("SearchBar")

                .Children(
                    new TextBox()
                        .SetGridColumn(0)
                        .Text(new Binding("ApiKey"))
                        .Watermark("set api key please"),

                    new Button()
                        .SetGridColumn(1)
                        .Background(Brushes.Transparent)

                        .OnClick(async args => { await vm.SetApiKey(); })
                        .Content(
                            new Image()
                                .SvgSource("Icon/SetValue.svg")
                                .Width(20)
                                .Height(20)
                        )
                )
        );
    }
}