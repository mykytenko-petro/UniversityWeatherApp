using Avalonia.Controls;
using Avalonia.Markup.Declarative;
using Avalonia.Media;
using Avalonia.Styling;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace UniversityWeatherApp.Views.ApplicationStyles;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public class AppStyles : Styles
{
    public AppStyles() : base()
    {
        Add(
            new Style<TextBlock>()
            {
                Setters =
                {
                    new Setter(TextBlock.ForegroundProperty, Brushes.White)
                }
            }
        );
    }
}