using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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

namespace ContactSplitter
{
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


            var controlMapper = provider.GetService<CustomControlViewModelMapper>();
            controlMapper.AddMapping<ContactParseOverviewControl, ContactParseViewModel>();
            controlMapper.AddMapping<SettingsControl, SettingsViewModel>();
            controlMapper.AddMapping<ContactListControl, ContactListViewModel>();
            controlMapper.AddMapping<UserGuideControl, UserGuideViewModel>();
            this.MainWindow = provider.GetService<MainWindow>();
            this.MainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            /* Datenhaltung */
            services.AddSingleton<DataRepository>();
            services.AddScoped<UserGuidingNotes>();

            /* Logik */
            services.AddScoped<IContactParser, DefaultContactParser>();

            /* View Models */
            services.AddTransient<UserGuideViewModel>();
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<ContactParseViewModel>();
            services.AddTransient<ContactListViewModel>();
            services.AddTransient<MainViewModel>();

            /*MainWindow */
            services.AddSingleton<MainWindow>();

            services.AddSingleton<CustomControlViewModelMapper>();
        }
    }
}
