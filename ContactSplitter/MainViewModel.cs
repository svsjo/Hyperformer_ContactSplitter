using System.ComponentModel;
using System.Runtime.CompilerServices;
using ContactSplitter.Control.ContactParseOverview;

namespace ContactSplitter;

public class MainViewModel: INotifyPropertyChanged
{
    private CustomControlViewModelMapper _userControlMapper;

    public CustomControlViewModelMapper UserControlMapper
    {
        get => _userControlMapper;
        set
        {
            if (Equals(value, _userControlMapper)) return;
            _userControlMapper = value;
            OnPropertyChanged();
        }
    }

    public MainViewModel(CustomControlViewModelMapper userControlMapper)
    {
        UserControlMapper = userControlMapper;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

 
}