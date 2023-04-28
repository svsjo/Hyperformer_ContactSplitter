using ContactParser.Contracts.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ContactSplitter.Control.ContactList;

public class ContactListViewModel : INotifyPropertyChanged
{
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

    public ContactListViewModel()
    {
        // Aktuelle Daten von AdressBook abrufen
        _allContacts = AdressBook.AllContacts;

        // Event abonnieren, um Änderungen an AllContacts zu überwachen
        AdressBook.AllContacts.CollectionChanged += OnAllContactsChanged;
    }

    private void OnAllContactsChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        // Änderungen an AllContacts propagieren
        OnPropertyChanged(nameof(AllContacts));
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