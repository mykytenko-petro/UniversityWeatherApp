using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Markup.Declarative;
using Avalonia.Media;
using Avalonia.Styling;
using UniversityWeatherApp.Framework.UI.Extensions;
using UniversityWeatherApp.ViewModels.Components.Dashboard;

namespace UniversityWeatherApp.Views.Components.Dashboard;

public class TodaysWeatherPropertiesView 
    : Framework.Mvvm.ViewBase<StackPanel>
{
    public TodaysWeatherPropertiesView(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        DataContext = new TodaysWeatherPropertiesViewModel(_serviceProvider!);
    }

    protected override void LayoutStyles()
    {
        Root.Spacing(10);
        Root.Margin(0, 20);

        Styles.Add(
            new Style(x => x.Class("Description"))
                .Add(TextBlock.OpacityProperty, 1)
                .Add(TextBlock.FontSizeProperty, 20)
        );

        Styles.Add(
            new Style(x => x.Class("DescriptionCard").OfType<TextBlock>())
                .Add(TextBlock.OpacityProperty, 0.7)

        );

        Styles.Add(
            new Style(x => x.Class("DescriptionCard").OfType<Image>())
                .Add(Image.WidthProperty, 30)
                .Add(Image.HeightProperty, 30)
        );
    }

    protected override void Layout()
    {
        Root.Children(
            new TextBlock()
                .Classes("Description")

                .Text(new Binding("Description")),

            GetDescriptionCard(
                "Temp max",
                "TempMax",
                "ForecastIcon/MaxTemp.svg"
            ),

            GetDescriptionCard(
                "Temp min",
                "TempMin",
                "ForecastIcon/MinTemp.svg"
            ),

            GetDescriptionCard(
                "Humidity",
                "Humidity",
                "ForecastIcon/Humadity.svg"
            ),

            GetDescriptionCard(
                "Cloudy",
                "Cloudy",
                "ForecastIcon/Cloudy.svg"
            ),

            GetDescriptionCard(
                "Wind",
                "Wind",
                "ForecastIcon/Wind.svg"
            )
        );
    }

    private Grid GetDescriptionCard(
        string name,
        string bindingName,
        string svgSource
    )
    {
        return new Grid()
        {
            ColumnDefinitions =
            {
                new ColumnDefinition(new GridLength(5, GridUnitType.Star)),
                new ColumnDefinition(new GridLength(2, GridUnitType.Star)),
                new ColumnDefinition(new GridLength(1, GridUnitType.Star))
            }
        }        
        .Children(
            new TextBlock()
                .SetGridColumn(0)

                .Text(name),

            new TextBlock()
                .TextAlignment(TextAlignment.End)
                .SetGridColumn(1)

                .Text(new Binding(bindingName)),

            new Image()
                .SetGridColumn(2)

                .SvgSource(svgSource)
        );
    }
}