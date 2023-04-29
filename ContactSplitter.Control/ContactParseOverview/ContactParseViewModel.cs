#region

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ContactParser.Contracts;

#endregion

namespace ContactSplitter.Control.ContactParseOverview;

public class ContactParseViewModel : INotifyPropertyChanged
{
    private IContactParser _contactParser = null!;

    private string _input = null!;

    public ContactParseViewModel()
    {
        BtnParse = new DelegateCommand(x =>
        {
            var possibleContact = _contactParser.ParseContact(Input);
        }, null);

        BtnSave = new DelegateCommand(x =>
        {
            // Zeug aus Felder holen und in Data Repos speichern
        }, null);
    }

    public ICommand BtnParse { get; set; }
    public ICommand BtnSave { get; set; }

    // TODO: Felder für alles

    private string Input
    {
        get => _input;
        set
        {
            if (value == _input) return;
            _input = value;
            OnPropertyChanged();
        }
    }

    public IContactParser ContactParser
    {
        get => _contactParser;
        set
        {
            if (Equals(value, _contactParser)) return;
            _contactParser = value;
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