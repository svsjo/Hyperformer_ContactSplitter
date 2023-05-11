#region

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Input;
using ContactSplitter.DataStorage.Contracts;

#endregion

namespace ContactSplitter.Control.ContactList;

public class ContactListViewModel : INotifyPropertyChanged
{
    private readonly IDataRepository _dataRepository;
    private readonly IProjectSettings _projectSettings;

    private string _contactsCount;
    private ICollectionView _contactsView;

    private string _searchText = string.Empty;

    public ContactListViewModel(IDataRepository dataRepository, IProjectSettings projectSettings)
    {
        _dataRepository = dataRepository;
        _projectSettings = projectSettings;

        _contactsView = CollectionViewSource.GetDefaultView(AllContacts); /* Is a filtered View of AllContacts */
        ContactsView.Filter = FilterContacts;

        DeleteContactCommand = new DelegateCommand(x =>
        {
            if (x is not Contact contact) return;
            DeleteContact(contact);
        });

        _contactsCount = ContactsView.Cast<object>().Count() + " " + "(von " + AllContacts.Count + ") Einträgen";
    }

    public ICommand DeleteContactCommand { get; set; }

    public ObservableCollection<Contact> AllContacts
    {
        get => _dataRepository.AdressBook;
        set
        {
            _dataRepository.AdressBook = value;
            OnPropertyChanged();
        }
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

    private void DeleteContact(Contact contact)
    {
        AllContacts.Remove(contact);
    }

    private bool FilterContacts(object item)
    {
        if (item is not Contact contact) return false;

        if (string.IsNullOrEmpty(SearchText)) return true;

        var searchString = SearchText.ToLower();

        return contact.FirstName.ToLower().Contains(searchString)
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