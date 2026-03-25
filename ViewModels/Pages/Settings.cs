using System.Threading.Tasks;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using UniversityWeatherApp.Framework.Mvvm;
using UniversityWeatherApp.Models;
using UniversityWeatherApp.Services;

namespace UniversityWeatherApp.ViewModels.Pages;

public partial class SettingsViewModel(IServiceProvider serviceProvider) : ViewModelBase
{
    private readonly StorageService _storageService =
        serviceProvider.GetRequiredService<StorageService>();

    private readonly ApiKeyService _apiKeyService =
        serviceProvider.GetRequiredService<ApiKeyService>();

    [ObservableProperty]
    private string _apiKey = "";

    public async Task SetApiKey()
    {
        if (ApiKey == "")
            return;
            
        _storageService.WriteData(
            "settings.json",
            new SettingsModel()
            {
                ApiKey = ApiKey
            }
        );

        Dispatcher.UIThread.Post(async () =>
        {
            await _apiKeyService.Setup(); 
        });

        ApiKey = "";
    }
}