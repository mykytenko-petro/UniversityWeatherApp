using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace UniversityWeatherApp.Framework.Utils;

public static class ResourceUtils
{
    public static Bitmap GetAssetBitmap(string uri)
    {
        return new Bitmap(
            AssetLoader.Open(new Uri($"avares://UniversityWeatherApp/Assets/{uri}"))
        );
    }
}