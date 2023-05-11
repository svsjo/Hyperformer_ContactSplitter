#region

using System.ComponentModel;
using System.Runtime.CompilerServices;
using ContactSplitter.Dependency_Injection;

#endregion

namespace ContactSplitter;

public class MainViewModel : INotifyPropertyChanged
{
    private ViewModelInjector _userControlInjector;

    public MainViewModel(ViewModelInjector userControlInjector)
    {
        UserControlInjector = userControlInjector;
    }

    public ViewModelInjector UserControlInjector
    {
        get => _userControlInjector;
        set
        {
            if (Equals(value, _userControlInjector)) return;
            _userControlInjector = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}