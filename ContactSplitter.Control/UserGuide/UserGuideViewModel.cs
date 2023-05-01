using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ContactSplitter.Control.UserGuide;

public class UserGuideViewModel : INotifyPropertyChanged
{
    private string _bedieneranleitung = "TODO";
    private string _bestPractices = "TODO";
    private string _developers = "Jonathan Schwab, Felix Wochele, Seva Pypenko, Jonas Weis";

    public string Bedieneranleitung
    {
        get => _bedieneranleitung;
        set
        {
            _bedieneranleitung = value;
            OnPropertyChanged();
        }
    }

    public string BestPractices
    {
        get => _bestPractices;
        set
        {
            _bestPractices = value;
            OnPropertyChanged();
        }
    }

    public string Developers
    {
        get => _developers;
        set
        {
            _developers = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}