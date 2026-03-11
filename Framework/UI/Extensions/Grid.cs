using Avalonia.Controls;

namespace UniversityWeatherApp.Framework.UI.Extensions;

public static partial class UIExtensions
{
    public static T SetGridRow<T>(this T control, int value)
        where T : Control
    {
        Grid.SetRow(control, value);
        return control;
    }

    public static T SetGridColumn<T>(this T control, int value)
        where T : Control
    {
        Grid.SetColumn(control, value);
        return control;
    }

    public static T SetGridRowSpan<T>(this T control, int value)
        where T : Control
    {
        Grid.SetRowSpan(control, value);
        return control;
    }

    public static T SetGridColumnSpan<T>(this T control, int value)
        where T : Control
    {
        Grid.SetColumnSpan(control, value);
        return control;
    }
}