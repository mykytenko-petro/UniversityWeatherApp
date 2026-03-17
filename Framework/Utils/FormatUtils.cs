namespace UniversityWeatherApp.Framework.Utils;

public static class FormatUtils
{
    public static string FormatTemperature(double temp)
    {
        return Math.Round(temp, MidpointRounding.AwayFromZero).ToString() + "°";
    }
}