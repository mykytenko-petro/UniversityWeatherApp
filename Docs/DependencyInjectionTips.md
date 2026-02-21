### to use DI in c# install **Microsoft.Extensions.DependencyInjection** NuGet package

* add service collection in Program.cs
```csharp
    var services = new ServiceCollection();
```

* then add your singletons
```csharp
    services.AddSingleton<YourService>();
```

* then create provider to access registered singletons
```csharp
    ServiceProvider = services.BuildServiceProvider();
```

### To access your singletons pass provider in the constructor and use method GetRequiredService
```csharp
    serviceProvider?.GetRequiredService<YourService>()
```