using ContactParser.Contracts;
using ContactParser;
using ContactSplitter.Control.ContactList;
using ContactSplitter.Control.ContactParseOverview;
using ContactSplitter.Control.Settings;
using ContactSplitter.Control.UserGuide;
using ContactSplitter.Control;
using ContactSplitter.DataStorage;
using GPTContactParser;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ContactSplitter.Dependency_Injection
{
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
            services.AddSingleton<DataRepository>();
            services.AddScoped<UserGuidingNotes>();
            services.AddSingleton<ProjectSettings>();

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
}
