### View models
- to create property use:
```csharp
    [ObservableProperty]
```
- to create methods use:
```csharp
    [RelayCommand]
```

### Views
- to use property:
```csharp
    .Bind( ..., new Binding("Property"));
```

- to use Method:
```csharp
    .Bind(Button.CommandProperty, new Binding("NameOfMethodCommand"));
```