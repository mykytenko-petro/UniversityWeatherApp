using Gdk;
using Gtk;
using UniversityWeatherApp.Core.Services;

namespace UniversityWeatherApp.Core.UI;

/// <summary>
/// 
/// </summary>
public class GImage : DrawingArea {
    private readonly Pixbuf originalPixbuf;

    public GImage(string filePath, ResourceService resourceService)  {
        originalPixbuf = resourceService
            .GetImagePixbuf(filePath);
    }

    protected override bool OnDrawn(Cairo.Context cr) {
        int targetW = Allocation.Width;
        int targetH = Allocation.Height;
            
        using Pixbuf scaled = originalPixbuf.ScaleSimple(targetW, targetH, InterpType.Bilinear);
        
        Gdk.CairoHelper.SetSourcePixbuf(cr, scaled, 0, 0);
        cr.Paint();
        
        return true;
    }
}