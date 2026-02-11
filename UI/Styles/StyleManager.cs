using System.IO;
using System.Linq;
using System.Reflection;
using Gtk;

namespace UniversityWeatherApp.UI.Styles;

public static class StyleManager
{
    public static void Load()
    {
        // 
        var assembly = Assembly.GetExecutingAssembly();
        // 
        CssProvider cssProvider = new();

        // 
        foreach (var name in assembly.GetManifestResourceNames()
            // 
            .Where(n => n.EndsWith(".gtk.css")))
        {
            // 
            using var stream = assembly.GetManifestResourceStream(name);
            using var reader = new StreamReader(stream);

            // 
            cssProvider.LoadFromData(reader.ReadToEnd());
        }

        // 
        StyleContext.AddProviderForScreen(
            Gdk.Screen.Default,
            cssProvider,
            StyleProviderPriority.Application
        );
    }
}