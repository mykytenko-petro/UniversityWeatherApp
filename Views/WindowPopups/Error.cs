using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Declarative;
using Avalonia.Media;
using Avalonia.Styling;
using UniversityWeatherApp.Framework.UI.Extensions;

namespace UniversityWeatherApp.Views.WindowPopups;

public class ErrorWindowPopupView : Window
{
    private readonly string error; 

    public ErrorWindowPopupView(string error) : base()
    {
        this.error = error;

        LayoutStyles();
        Layout();
    }

    private void LayoutStyles()
    {
        Title = "Error";

        Width = 300;
        Height = 100;
        Background = Brushes.Black;

        Styles.Add(
            new Style(x => x.OfType<TextBlock>())
                .Add(TextBlock.FontSizeProperty, 20)
                .Add(TextBlock.ForegroundProperty, Brushes.White)
                .Add(TextBlock.HorizontalAlignmentProperty,
                    Avalonia.Layout.HorizontalAlignment.Center)
        );
    }

    private void Layout()
    {
        Content = new StackPanel()
            .Children(
                new TextBlock()
                    .Text(error)
            );
    }
}