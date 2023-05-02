using System.ComponentModel;
using System.Runtime.CompilerServices;
using ContactSplitter.Control.ContactParseOverview;

namespace ContactSplitter;

public class MainViewModel: INotifyPropertyChanged
{
    private ContactParseViewModel _parseViewModel;

    public ContactParseViewModel ParseViewModel
    {
        set
        {
            if (Equals(value, _parseViewModel)) return;
            _parseViewModel = value;
            OnPropertyChanged();
        }
    }

    public MainViewModel(ContactParseViewModel contactParseViewModel)
    {
        ParseViewModel = contactParseViewModel;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

 
}