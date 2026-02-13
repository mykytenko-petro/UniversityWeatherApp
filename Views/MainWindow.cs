using Avalonia.Controls;

namespace UniversityWeatherApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        var textBlock = new TextBlock
        {
            Text = "2232 from avalonia without xaml"
        };

        Content = textBlock;
    }
}