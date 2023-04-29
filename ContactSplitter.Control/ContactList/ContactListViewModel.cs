#region

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Input;
using ContactParser.Contracts.Data;

#endregion

namespace ContactSplitter.Control.ContactList;

public class ContactListViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Contact> _allContacts;

    private ICollectionView _contactsView;

    private string _searchText = string.Empty;

    public ContactListViewModel()
    {
        AllContacts = new ObservableCollection<Contact>() // Später Daten aus Repos beziehen
        {
            new()
            {
                ForeName = "Jonas Noah",
                LastName = "Schmid-Weis",
                Gender = "M",
                LetterSalutation = "Sehr geehrter",
                Salutation = "Sehr geehrter",
                Title = "Prof. Dr.-Ing."
            },
            new()
            {
                ForeName = "Nonas Joah",
                LastName = "Weis-Schmid",
                Gender = "F",
                LetterSalutation = "Sehr geehrte",
                Salutation = "Sehr geehrte",
                Title = "Dr.-Ing. net. rar."
            },
            new()
            {
                ForeName = "Arne",
                LastName = "Amel",
                Gender = "M",
                LetterSalutation = "Hallo",
                Salutation = "Moin",
                Title = "Absolvent"
            }
        };

        ContactsView = CollectionViewSource.GetDefaultView(AllContacts);
        ContactsView.Filter = FilterContacts;
    }

    public ICommand EditCommand { get; set; }

    public ObservableCollection<Contact> AllContacts
    {
        get => _allContacts;
        set
        {
            _allContacts = value;
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

    public event PropertyChangedEventHandler? PropertyChanged;

    private bool FilterContacts(object item)
    {
        if (item is not Contact contact) return false;

        if (string.IsNullOrEmpty(SearchText)) return true;

        var searchString = SearchText.ToLower();
        if (contact.ForeName.ToLower().Contains(searchString)
            || contact.LastName.ToLower().Contains(searchString)
            || contact.Salutation.ToLower().Contains(searchString)
            || contact.LetterSalutation.ToLower().Contains(searchString)
            || contact.Title.ToLower().Contains(searchString)
            || contact.Gender.ToLower().Contains(searchString))
            return true;

        return false;
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