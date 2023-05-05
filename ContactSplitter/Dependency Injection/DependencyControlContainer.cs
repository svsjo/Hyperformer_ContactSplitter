#region

using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

#endregion

namespace ContactSplitter;

public class DependencyControlContainer : Frame
{
    public static readonly DependencyProperty CustomViewInjectorProperty = DependencyProperty.Register(
        nameof(CustomViewInjector), typeof(ViewModelInjector), typeof(DependencyControlContainer),
        new PropertyMetadata(default(ViewModelInjector)));

    public DependencyControlContainer()
    {
        Navigated += OnNavigated;
    }

    public ViewModelInjector CustomViewInjector
    {
        get => (ViewModelInjector)GetValue(CustomViewInjectorProperty);
        set => SetValue(CustomViewInjectorProperty, value);
    }

    private void OnNavigated(object sender, NavigationEventArgs e)
    {
        if (e.Content is not ContentControl c)
            return;
        CustomViewInjector.HandleNavigation(c);
    }
}