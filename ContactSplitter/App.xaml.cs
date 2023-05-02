#region

using System;
using System.Windows;
using ContactParser;
using ContactParser.Contracts;
using ContactSplitter.Control;
using ContactSplitter.Control.ContactList;
using ContactSplitter.Control.ContactParseOverview;
using ContactSplitter.Control.Settings;
using ContactSplitter.Control.UserGuide;
using ContactSplitter.DataStorage;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace ContactSplitter;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        var services = new ServiceCollection();
        ConfigureServices(services);


        var provider = services.BuildServiceProvider();

        MapCustomControls(provider);
        StartWindow(provider);
    }

    private void StartWindow(IServiceProvider provider)
    {
        MainWindow = provider.GetService<MainWindow>();
        MainWindow?.Show();
    }

    private static void MapCustomControls(IServiceProvider provider)
    {
        var controlMapper = provider.GetService<CustomControlViewModelMapper>();
        controlMapper?.AddMapping<ContactParseOverviewControl, ContactParseViewModel>();
        controlMapper?.AddMapping<SettingsControl, SettingsViewModel>();
        controlMapper?.AddMapping<ContactListControl, ContactListViewModel>();
        controlMapper?.AddMapping<UserGuideControl, UserGuideViewModel>();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        /* Datenhaltung */
        services.AddSingleton<DataRepository>();
        services.AddScoped<UserGuidingNotes>();

        /* Logik */
        services.AddScoped<IContactParser, DefaultContactParser>();

        /* View Models */
        services.AddScoped<UserGuideViewModel>();
        services.AddScoped<SettingsViewModel>();
        services.AddScoped<ContactParseViewModel>();
        services.AddScoped<ContactListViewModel>();
        services.AddScoped<MainViewModel>();

        /*MainWindow */
        services.AddSingleton<MainWindow>();
        services.AddSingleton<CustomControlViewModelMapper>();
    }
}