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
using ContactSplitter.Dependency_Injection;
using Microsoft.Extensions.DependencyInjection;
using GPTContactParser;

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
        var diContainer = new DiContainerConfig();
        StartWindow(diContainer.Init());
    }
    private void StartWindow(IServiceProvider provider)
    {
        MainWindow = provider.GetService<MainWindow>();
        MainWindow?.Show();
    }
}