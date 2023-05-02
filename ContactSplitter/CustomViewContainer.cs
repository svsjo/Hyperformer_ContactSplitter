using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ContactSplitter;

public class CustomViewContainer: Frame
{
    public static readonly DependencyProperty customViewMapperProperty = DependencyProperty.Register(
        nameof(customViewMapper), typeof(CustomControlViewModelMapper), typeof(CustomViewContainer), new PropertyMetadata(default(CustomControlViewModelMapper)));

    public CustomControlViewModelMapper customViewMapper
    {
        get { return (CustomControlViewModelMapper)GetValue(customViewMapperProperty); }
        set { SetValue(customViewMapperProperty, value); }
    }

    public CustomViewContainer()
    {
        this.Navigated+= OnNavigated;
    }

    private void OnNavigated(object sender, NavigationEventArgs e)
    {
        if(e.Content is not ContentControl c)
            return;
        customViewMapper.HandleNavigation(c);
    }
}