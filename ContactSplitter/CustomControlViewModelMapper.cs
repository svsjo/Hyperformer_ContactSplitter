using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace ContactSplitter;

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