using Avalonia.Controls;
using Avalonia.Markup.Declarative;
using Avalonia.Styling;
using Microsoft.Extensions.DependencyInjection;
using UniversityWeatherApp.Framework.UI.Extensions;
using UniversityWeatherApp.Framework.Utils;
using UniversityWeatherApp.Models.WeatherService;
using UniversityWeatherApp.Services;

namespace UniversityWeatherApp.Views.Components.Dashboard;

public class WeatherForecastListView :
    Framework.Mvvm.ViewBase<StackPanel>
{
    public WeatherForecastListView(IServiceProvider serviceProvider) : base()
    {
        var weatherService = serviceProvider.GetRequiredService<WeatherService>();

        weatherService.OnDataUpdate += UpdateData;
    }

    protected override void LayoutStyles()
    {
        Root.Margin(0, 20);
        Root.Spacing(20);

        Styles.Add(
            new Style(x => x.OfType<Image>())
                .Add(Image.WidthProperty, 45)
                .Add(Image.HeightProperty, 45)
        );
    }
    
    protected override void Layout() { }

    private void UpdateData(WeatherResponse weatherResponse)
    {
        var todaysWeatherModel = weatherResponse.TodaysWeather;

        Root.Children.Clear();

        for (int i = 0; i < 24; i++)
        {
            var data = todaysWeatherModel.List[i];

            Root.Children.Add(
                new Grid()
                {
                    ColumnDefinitions = [
                        new ColumnDefinition(1, GridUnitType.Star),
                        new ColumnDefinition(4, GridUnitType.Star),
                        new ColumnDefinition(1, GridUnitType.Star)
                    ]
                }
                    .Children(
                        new Image()
                            .SetGridColumn(0)

                            .SvgSource(
                                "WeatherIcon/" + data.Weather[0].Icon + ".svg"
                            ),

                        new StackPanel()
                            .SetGridColumn(1)

                            .Children(
                                new TextBlock()
                                    .Text(FormatTime(data.Dt, todaysWeatherModel.City.Timezone)),

                                new TextBlock()
                                    .Text(data.Weather[0].Main)
                            ),
                        
                        new TextBlock()
                            .SetGridColumn(2)
                            .FontSize(20)

                            .Text(FormatUtils.FormatTemperature(data.Main.Temp))
                    )
            );
        }
    }

    private string FormatTime(long time, int timezone)
    {
        return DateTimeOffset.FromUnixTimeSeconds(time + timezone).ToString("HH:mm");
    }
}