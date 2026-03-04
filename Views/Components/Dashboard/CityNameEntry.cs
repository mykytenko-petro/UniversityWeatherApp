using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Markup.Declarative;
using Avalonia.Media;
using UniversityWeatherApp.ViewModels.Components.Dashboard;

namespace UniversityWeatherApp.Views.Components.Dashboard;

public class CityNameEntryView
    : Framework.Mvvm.ViewBase<StackPanel>
{
    public CityNameEntryView(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        DataContext = new CityNameEntryViewModel(_serviceProvider!);
    }

    protected override void LayoutStyles()
    {
        // Styles.Add(
        //     new Style<TextBox>()
                
        // );
    }

    protected override void Layout()
    {
        Root.Children(
            // new TextBlock()
            //     .Text("2232"),

            // 
            // new TextBox()
            //     .Width(200)
            //     .Height(50)
            //     .Background(Brushes.White)
            //     .Text("2232")
            //     .Watermark("Search Location...")
        );
    }
}