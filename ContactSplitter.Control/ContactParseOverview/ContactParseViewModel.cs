using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
    public ICommand BtnSave { get; set; } // In AdressBook speichern den Kontakt

    private ObservableCollection<Contact> _allContacts;

    public ObservableCollection<Contact> AllContacts
    {
        get { return _allContacts; }
        set
        {
            _allContacts = value;
            OnPropertyChanged();
        }
    }

    private void OnAllContactsChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        // Änderungen an AllContacts propagieren
        OnPropertyChanged(nameof(AllContacts));
    }

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
        // Aktuelle Daten von AdressBook abrufen
        _allContacts = AdressBook.AllContacts;

        // Event abonnieren, um Änderungen an AllContacts zu überwachen
        AdressBook.AllContacts.CollectionChanged += OnAllContactsChanged;

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