# University Weather App

A cross-platform weather application built with C# and Avalonia UI framework, designed as a laboratory work for the university subject "Algorithmization and Programming" at Dnipro University of Technology. This project demonstrates modern desktop application development practices and an all-code Avalonia UI approach.

## Credits

- Design adapted from Figma Community by Muhammad Aditya: https://www.figma.com/community/file/1300997022541611628

## Features

- **Current Weather Display**: Shows real-time weather conditions for any city
- **Weather Forecast**: Displays today's weather forecast with hourly data
- **Dynamic Backgrounds**: Automatically changes background images based on weather conditions (Clear, Cloudy, Rain, Thunderstorm, Snow, Mist)
- **API Key Management**: Secure storage and configuration of OpenWeatherMap API key
- **Cross-Platform**: Runs on Windows, macOS, and Linux using Avalonia
- **MVVM Architecture**: Clean separation of concerns with Model-View-ViewModel pattern
- **Dependency Injection**: Modern service-based architecture

## Technologies Used

- **C# .NET 10.0**
- **Avalonia UI 11.3.11** - Cross-platform UI framework
- **Avalonia.Markup.Declarative** - Community package used to enable code-first view construction without XAML
- **CommunityToolkit.Mvvm** - MVVM toolkit for observable properties and commands
- **Microsoft.Extensions.DependencyInjection** - Dependency injection container
- **OpenWeatherMap API** - Weather data provider
- **DotNetEnv** - Environment variable management

## Getting Started

### Prerequisites

- .NET 10.0 SDK
- OpenWeatherMap API key (free at [openweathermap.org](https://openweathermap.org/api))

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/mykytenko-petro/UniversityWeatherApp.git
   cd UniversityWeatherApp
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Build the project:
   ```bash
   dotnet build
   ```

### Running the Application

```bash
dotnet run
```

On first launch, you'll need to configure your OpenWeatherMap API key in the Settings page.

## Usage

1. **API Key Setup**: Enter your OpenWeatherMap API key in the Settings page
2. **Weather Lookup**: Enter a city name in the dashboard to view current weather and forecast
3. **Background Changes**: The app automatically updates the background based on weather conditions

## No-XAML Architecture (C#-Only UI)

This project is a deliberate no-XAML Avalonia experiment. All UI elements, layout, and bindings are created in C# code using Avalonia API and custom view helpers.

### How the weather forecast list implements no-XAML UI

- `Views/Components/Dashboard/WeatherForecastList.cs` inherits `Framework.Mvvm.ViewBase<StackPanel>` and builds the view in code.
- Styles and layout are configured in `LayoutStyles()` on the `Root` stack panel:
  - `Root.Margin(0, 20)`
  - `Root.Spacing(20)`
  - custom `Style` objects are added in code for child controls.
- The view responds to `WeatherService.OnDataUpdate` and updates UI in code inside `UpdateData(...)`.
- Rows, columns, and child elements are created with `new Grid()` and chained builders:
  - `.Children(...)`
  - `.SetGridColumn(...)`
  - `.SvgSource(...)`
- The code-first view pattern is enabled by the Avalonia.Markup.Declarative community package.
- All UI is created programmatically; there is no XAML markup used anywhere in this component.

### Example pattern for code-only view

```csharp
public class MyListView : Framework.Mvvm.ViewBase<StackPanel>
{
    public MyListView(IServiceProvider serviceProvider) : base()
    {
        var weatherService = serviceProvider.GetRequiredService<WeatherService>();
        weatherService.OnDataUpdate += UpdateData;
    }

    protected override void LayoutStyles()
    {
        Root.Margin(0, 20);
        Root.Spacing(20);
        Styles.Add(
            new Style(x => x.OfType<Image>())
                .Add(Image.WidthProperty, 45)
                .Add(Image.HeightProperty, 45)
        );
    }

    protected override void Layout() { }

    private void UpdateData(WeatherResponse weatherResponse)
    {
        Root.Children.Clear();
        Root.Children.Add(
            new Grid()
            {
                ColumnDefinitions = [
                    new ColumnDefinition(1, GridUnitType.Star),
                    new ColumnDefinition(4, GridUnitType.Star),
                    new ColumnDefinition(1, GridUnitType.Star)
                ]
            }
            .Children(
                new Image().SetGridColumn(0).SvgSource("WeatherIcon/..."),
                new StackPanel().SetGridColumn(1).Children(...),
                new TextBlock().SetGridColumn(2).FontSize(20).Text("...")
            )
        );
    }
}
```

### Supporting no-XAML helper files

- `Framework/Mvvm/ViewBase.cs` defines the base class for code-first views.
  - It creates the root panel, calls `LayoutStyles()` and `Layout()`, then sets `Content = Root`.
- `Framework/UI/Extensions/Grid.cs` provides extension methods for fluent grid layout configuration like `SetGridRow`, `SetGridColumn`, and span helpers.
- `Framework/UI/Extensions/Styles.cs` provides a fluent `Style.Add(...)` helper so you can construct Avalonia styles in code more easily.
- `Framework/UI/Extensions/Svg.cs` provides `SvgSource(...)` helpers to load SVG assets into `Image` controls from code.

## Architecture

The application follows the MVVM (Model-View-ViewModel) architectural pattern and is implemented as an all-code Avalonia experiment (no XAML is used):

- **Models**: Represent data structures and business logic
- **Views**: Define the UI layout and appearance through C# code (no XAML)
- **ViewModels**: Handle presentation logic and data binding
- **Services**: Provide application-wide functionality (API calls, storage, navigation)

Dependency injection is used throughout the application for loose coupling and testability.

## Contributing

This is a university project for educational purposes. Contributions are welcome for learning and improvement.

## License

This project is for educational use.