using System;
using System.Collections.Generic;
using System.Linq;
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
public class CustomControlViewModelMapper
{
    private readonly IServiceProvider _iServiceProvider;
    private readonly Dictionary<Type, Type> _map = new();
    public void AddMapping<T,T2>()
    {
        _map.Add(typeof(T), typeof(T2));
    }

    public CustomControlViewModelMapper(IServiceProvider iServiceProvider)
    {
        _iServiceProvider = iServiceProvider;
    }
    public void HandleNavigation(ContentControl content)
    {
        var match = _map.FirstOrDefault(x => x.Key == content.GetType());
        if (match.Equals(null)) return;
        content.DataContext = _iServiceProvider.GetService(match.Value);
    }
}