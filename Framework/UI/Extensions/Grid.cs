using Avalonia.Controls;

namespace UniversityWeatherApp.Framework.UI.Extensions;

public static partial class UIExtensions
{
    public static Panel SetGridRow(this Panel control, int value)
    {
        Grid.SetRow(control, value);

        return control;
    }

    public static Panel SetGridColumn(this Panel control, int value)
    {
        Grid.SetColumn(control, value);

        return control;
    }
}