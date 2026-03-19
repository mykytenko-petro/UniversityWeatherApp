using Avalonia.Controls;
using Avalonia.Markup.Declarative;
using UniversityWeatherApp.Framework.UI;

namespace UniversityWeatherApp.Views.Pages;

public class SettingsView : Page
{
    public SettingsView(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override void LayoutStyles()
    {
        
    }

    protected override void Layout()
    {
        Add(
            new TextBlock()
                .Text("2232")
        );
    }
}