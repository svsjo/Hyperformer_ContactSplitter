using System;
using ContactParser.Contracts.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;
using System.Windows.Input;
using System.Globalization;

namespace ContactSplitter.Control.ContactList;

public class ContactListViewModel : INotifyPropertyChanged
{
    public ICommand SaveCommand { get; set; }
    public ICommand SortCommand { get; set; }

    private ObservableCollection<Contact> _allContacts;

    public ObservableCollection<Contact> AllContacts
    {
        get { return _allContacts; }
        set
        {
            if (_allContacts != null)
            {
                _allContacts.CollectionChanged -= OnAllContactsCollectionChanged;
            }

            _allContacts = value;

            if (_allContacts != null)
            {
                _allContacts.CollectionChanged += OnAllContactsCollectionChanged;
            }

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

    private void OnAllContactsChanged(object sender, NotifyCollectionChangedEventArgs e = default)
    {
        // Änderungen an AllContacts propagieren
        OnPropertyChanged(nameof(AllContacts));
    }

    private void OnAllContactsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        // Propagate changes back to AdressBook.AllContacts
        AdressBook.AllContacts.CollectionChanged -= OnAllContactsChanged;
        AdressBook.AllContacts.Clear();

        foreach (var contact in _allContacts)
        {
            AdressBook.AllContacts.Add(contact);
        }

        AdressBook.AllContacts.CollectionChanged += OnAllContactsChanged;
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