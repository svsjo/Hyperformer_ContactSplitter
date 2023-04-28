using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ContactParser.Contracts;
using ContactParser.Contracts.Data;

namespace ContactSplitter.Control.ContactParseOverview;

public class ContactParseViewModel : INotifyPropertyChanged
{
    private IContactParser _contactParser = null!;
    public ICommand BtnParse { get; set; }
    public ICommand BtnSave { get; set; }

    private string _input = null!;

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

    public ContactParseViewModel()
    {
        BtnParse = new DelegateCommand((x) =>
        {
            var possibleContact = _contactParser.ParseContact(Input);
        }, null);

        BtnSave = new DelegateCommand((x) =>
        {
            // Zeug aus Felder holen
        }, null);
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