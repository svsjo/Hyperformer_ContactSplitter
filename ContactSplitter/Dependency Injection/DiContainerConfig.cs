#region

using System;
using ContactParser;
using ContactParser.Contracts;
using ContactSplitter.Control.ContactList;
using ContactSplitter.Control.ContactParseOverview;
using ContactSplitter.Control.Settings;
using ContactSplitter.Control.UserGuide;
using ContactSplitter.DataStorage;
using ContactSplitter.DataStorage.Contracts;
using GPTContactParser;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace ContactSplitter.Dependency_Injection;

/// <summary>
/// Configures the dependecy injection container
/// </summary>
internal class DiContainerConfig
{
    public ServiceProvider Init()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);


        var provider = services.BuildServiceProvider();

        MapCustomControls(provider);
        return provider;
    }

    private static void MapCustomControls(IServiceProvider provider)
    {
        var controlMapper = provider.GetService<ViewModelInjector>();
        controlMapper?.AddMapping<ContactParseOverviewControl, ContactParseViewModel>();
        controlMapper?.AddMapping<SettingsControl, SettingsViewModel>();
        controlMapper?.AddMapping<ContactListControl, ContactListViewModel>();
        controlMapper?.AddMapping<UserGuideControl, UserGuideViewModel>();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        /* Datenhaltung */
        services.AddSingleton<IDataRepository, DataRepository>();
        services.AddScoped<IUserGuidingNotes, UserGuidingNotes>();
        services.AddSingleton<IProjectSettings, ProjectSettings>();

        /* Logik */
        services.AddScoped<IOfflineContactParser, DefaultOfflineContactParser>();
        services.AddScoped<IOnlineContactParser, GptOnlineContactParser>();

        /* View Models */
        services.AddTransient<UserGuideViewModel>();
        services.AddTransient<SettingsViewModel>();
        services.AddTransient<ContactParseViewModel>();
        services.AddTransient<ContactListViewModel>();
        services.AddTransient<MainViewModel>();

        /*MainWindow */
        services.AddSingleton<MainWindow>();
        services.AddSingleton<ViewModelInjector>();
    }
}