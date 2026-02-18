using Avalonia.Controls;
using Avalonia.Media;
using UniversityWeatherApp.Framework.UI;
using UniversityWeatherApp.ViewModels.Pages;
using Avalonia.Layout;
using UniversityWeatherApp.Framework.Utils;
using Avalonia.Markup.Declarative;
using Avalonia.Styling;
using Avalonia;
using UniversityWeatherApp.Framework.UI.Extensions;

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
            new RowDefinition(new GridLength(5, GridUnitType.Star)),
            new RowDefinition(new GridLength(80, GridUnitType.Star)),
            new RowDefinition(new GridLength(15, GridUnitType.Star))
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
        
        Styles.Add(
            new Style(x => x.OfType<TextBlock>())
                .Add(TextBlock.FontSizeProperty, 18)
                .Add(TextBlock.FontWeightProperty, FontWeight.Regular)
        );

        Styles.Add(
            new Style(x => x.Class("Line"))
                .Add(ScrollViewer.BorderBrushProperty, Brushes.White)
                .Add(ScrollViewer.BorderThicknessProperty, new Thickness(0, 0, 0, 1))
        );

        Styles.Add(
            new Style(x => x.Class("Logo"))
                .Add(Panel.WidthProperty, 80)
                .Add(Panel.HeightProperty, 80)
                .Add(Panel.HorizontalAlignmentProperty, HorizontalAlignment.Left)
                .Add(Panel.VerticalAlignmentProperty, VerticalAlignment.Top)
        );

        Styles.Add(
            new Style(x => x.Class("SidePanel__ScrollViewer"))
                .Add(ScrollViewer.BorderBrushProperty,
                     new SolidColorBrush(Color.FromArgb(36, 255, 255, 255)))
                .Add(ScrollViewer.BorderThicknessProperty, new Thickness(5, 0, 0, 0))
                .Add(ScrollViewer.PaddingProperty, new Thickness(25, 40))
        );

        Styles.Add(
            new Style(x => x.Class("SidePanel__ScrollViewer__Inner"))
                .Add(StackPanel.SpacingProperty, 8.0)
                .Add(StackPanel.OrientationProperty, Orientation.Vertical)
        );
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
