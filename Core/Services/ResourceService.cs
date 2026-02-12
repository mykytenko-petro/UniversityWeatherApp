using System.IO;
using System.Linq;
using System.Reflection;
using Gdk;

namespace UniversityWeatherApp.Core.Services;

public class ResourceService
{
    private readonly Assembly _assembly;

    public ResourceService()
    {
        _assembly = Assembly.GetExecutingAssembly();
    }

    public string GetCssText()
    {
        string fullCss = "";

        // Loop through all resource names ending with ".gtk.css"
        // LINQ makes this easier than manually checking each name
        foreach (var name in _assembly.GetManifestResourceNames()
            .Where(n => n.EndsWith(".gtk.css")))
        {
            // Open the resource stream (returns null if the resource doesn't exist)
            using var stream = _assembly.GetManifestResourceStream(name);

            // Read the stream content
            using var reader = new StreamReader(stream);

            // "using" ensures the stream closes automatically at the end of this scope

            // Return the full CSS text of this file
            fullCss += reader.ReadToEnd();
        }

        return fullCss;
    }

    // 
    public Pixbuf GetImagePixbuf(string path)
    {
        using var stream = _assembly.GetManifestResourceStream(path);

        return new Pixbuf(stream);
    }
}