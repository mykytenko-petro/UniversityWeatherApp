using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Layout;
using Avalonia.Markup.Declarative;
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
        Width = 350;
        Height = 300;

        Styles.Add(
            new Style(x => x.Class("Description"))
                .Add(TextBlock.OpacityProperty, 1)
                .Add(TextBlock.FontSizeProperty, 20)
        );

        Styles.Add(
            new Style(x => x.Class("DescriptionCard"))
                .Add(StackPanel.OrientationProperty, Orientation.Horizontal)
                .Add(StackPanel.WidthProperty, 350)
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

            new StackPanel()
                .Classes("DescriptionCard")

                .Children(
                    new TextBlock()
                        .Text("Temp max"),

                    new TextBlock()
                        .Text(new Binding("TempMax")),

                    new Image()
                        .SvgSource("ForecastIcon/MaxTemp.svg")
                ),

            new StackPanel()
                .Classes("DescriptionCard")

                .Children(
                    new TextBlock()
                        .Text("Temp min"),

                    new TextBlock()
                        .Text(new Binding("TempMin")),

                    new Image()
                        .SvgSource("ForecastIcon/MinTemp.svg")
                ),

            new StackPanel()
                .Classes("DescriptionCard")

                .Children(
                    new TextBlock()
                        .Text("Humidity"),

                    new TextBlock()
                        .Text(new Binding("Humidity")),

                    new Image()
                        .SvgSource("ForecastIcon/Humadity.svg")
                ),

            new StackPanel()
                .Classes("DescriptionCard")

                .Children(
                    new TextBlock()
                        .Text("Cloudy"),

                    new TextBlock()
                        .Text(new Binding("Cloudy")),

                    new Image()
                        .SvgSource("ForecastIcon/Cloudy.svg")
                ),
            
            new StackPanel()
                .Classes("DescriptionCard")

                .Children(
                    new TextBlock()
                        .Text("Wind"),

                    new TextBlock()
                        .Text(new Binding("Wind")),

                    new Image()
                        .SvgSource("ForecastIcon/Wind.svg")
                )
        );
    }
}