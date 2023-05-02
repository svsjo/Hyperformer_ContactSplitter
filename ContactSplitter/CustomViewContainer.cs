#region

using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

#endregion

namespace ContactSplitter;

public class CustomViewContainer : Frame
{
    public static readonly DependencyProperty CustomViewMapperProperty = DependencyProperty.Register(
        nameof(CustomViewMapper), typeof(CustomControlViewModelMapper), typeof(CustomViewContainer),
        new PropertyMetadata(default(CustomControlViewModelMapper)));

    public CustomViewContainer()
    {
        Navigated += OnNavigated;
    }

    public CustomControlViewModelMapper CustomViewMapper
    {
        get => (CustomControlViewModelMapper)GetValue(CustomViewMapperProperty);
        set => SetValue(CustomViewMapperProperty, value);
    }

    private void OnNavigated(object sender, NavigationEventArgs e)
    {
        if (e.Content is not ContentControl c)
            return;
        CustomViewMapper.HandleNavigation(c);
    }
}