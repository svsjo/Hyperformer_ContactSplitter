#region

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Input;
using ContactParser.Contracts.Data;
using ContactSplitter.DataStorage;
using Wpf.Ui.Mvvm.Contracts;

#endregion

namespace ContactSplitter.Control.ContactList;

public class ContactListViewModel : INotifyPropertyChanged
{
    private readonly DataRepository _dataRepository;
    private ICollectionView _contactsView;
    public ICommand DeleteContactCommand { get; set; }

    private string _searchText = string.Empty;

    public ContactListViewModel(DataRepository dataRepository)
    {
        _dataRepository = dataRepository;

        _contactsView = CollectionViewSource.GetDefaultView(AllContacts);
        ContactsView.Filter = FilterContacts;
        DeleteContactCommand = new DelegateCommand((x) =>
        {
            if (x is not Contact contact) return;
            DeleteContact(contact);
        });

        _contactsCount = ContactsView.Cast<object>().Count() + " " + "(von " + AllContacts.Count + ") Einträgen";
    }

    public ObservableCollection<Contact> AllContacts
    {
        get => _dataRepository.AdressBook;
        set
        {
            _dataRepository.AdressBook = value;
            OnPropertyChanged();
        }
    }

    private void DeleteContact(Contact contact)
    {
        AllContacts.Remove(contact);
    }

    public string SearchText
    {
        get => _searchText;
        set
        {
            _searchText = value;
            ContactsView.Refresh();
            ContactsCount = ContactsView.Cast<object>().Count() + " ";
            OnPropertyChanged();
        }
    }

    public ICollectionView ContactsView
    {
        get => _contactsView;
        set
        {
            _contactsView = value;
            OnPropertyChanged();
        }
    }

    private string _contactsCount;

    public string ContactsCount
    {
        get => _contactsCount;
        set
        {
            _contactsCount = value + "(von " + AllContacts.Count + ") Einträgen";
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private bool FilterContacts(object item)
    {
        if (item is not Contact contact) return false;

        if (string.IsNullOrEmpty(SearchText)) return true;

        var searchString = SearchText.ToLower();
        return contact.ForeName.ToLower().Contains(searchString)
               || contact.LastName.ToLower().Contains(searchString)
               || contact.Salutation.ToLower().Contains(searchString)
               || contact.LetterSalutation.ToLower().Contains(searchString)
               || contact.Title.ToLower().Contains(searchString)
               || contact.Gender.ToLower().Contains(searchString);
    }

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