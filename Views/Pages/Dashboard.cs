using Avalonia.Controls;
using Avalonia.Media;
using UniversityWeatherApp.Framework.UI;
using UniversityWeatherApp.ViewModels.Pages;
using UniversityWeatherApp.Framework.Utils;
using Avalonia.Markup.Declarative;
using UniversityWeatherApp.Framework.UI.Extensions;
using UniversityWeatherApp.Views.Styles.Pages;

namespace UniversityWeatherApp.Views.Pages;

public class DashboardView : Page
{
    public DashboardView() : base()
    {
        DataContext = new DashboardViewModel();
    }

    protected override void Setup()
    {
        RowDefinitions = [
            new RowDefinition(new GridLength(2, GridUnitType.Star)),
            new RowDefinition(new GridLength(80, GridUnitType.Star)),
            new RowDefinition(new GridLength(18, GridUnitType.Star))
        ];

        ColumnDefinitions = [
            new ColumnDefinition(new GridLength(8, GridUnitType.Star)),
            new ColumnDefinition(new GridLength(56, GridUnitType.Star)),
            new ColumnDefinition(new GridLength(36, GridUnitType.Star))
        ];
    }

    protected override void LayoutStyles()
    {
        Background = new ImageBrush
        {
            Source = ResourceUtils.GetAssetBitmap("Background/Snow.png"),
            Stretch = Stretch.UniformToFill
        };
        
        Styles.Add(new DashboardStyles());
    }

    protected override void Layout()
    {
        // Logo
        Add(
            new Panel()
                .Classes("Logo")
                .SetGridRow(1)
                .SetGridColumn(1)
                
                .Background(
                    new ImageBrush(
                        ResourceUtils.GetAssetBitmap("Icon/Logo.png"))
                        .Stretch(Stretch.Fill)
                    )
        );

        // Side panel
        Add(
            new Grid()
                .SetGridColumn(2)
                .SetGridRowSpan(3)
                
                .Children(
                    new Border()
                        .Background(
                            new ImageBrush(
                                ResourceUtils.GetAssetBitmap("Texture/BlurredBackground.png"))
                                .Stretch(Stretch.Fill)
                                .Opacity(0.4)
                        ),

                    new ScrollViewer()
                        .Classes("SidePanel__ScrollViewer")

                        .Content(
                            new StackPanel()
                                .Classes("SidePanel__ScrollViewer__Inner")
                            
                                .Children(
                                    new Border().Classes("Line"),

                                    new TextBlock()
                                        .Text("Weather Details..."),
                                    
                                    new Border().Classes("Line"),

                                    new TextBlock()
                                        .Text("Today’s Weather Forecast...")
                                )
                            )
                )
        );
    }
}
