using System.IO;
using System.Linq;
using DotNetEnv;

namespace UniversityWeatherApp.Framework.Debug;

public sealed class DebugService
{
    public bool Debug { get; private set; } = false;
    public Dictionary<string, string>? EvnVariables { get; private set; }

    public DebugService()
    {
        LoadEnv();
    }

    private void LoadEnv()
    {
        var projectDir = Directory.GetParent(AppContext.BaseDirectory)!
                          .Parent!
                          .Parent!
                          .Parent!
                          .FullName;
        var dotenvPath = Path.Combine(projectDir, ".env");

        if (File.Exists(dotenvPath))
        {
            Console.WriteLine(".env found, activating debug mode");

            EvnVariables = Env.Load(dotenvPath).ToDictionary();
            
            Debug = true;
        }
    }
}