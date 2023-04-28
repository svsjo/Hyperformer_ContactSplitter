using System.Collections.ObjectModel;
using ContactParser.Contracts.Data;

namespace ContactSplitter.Control;

public static class AdressBook
{
    public static ObservableCollection<Contact> AllContacts { get; set; } = new ObservableCollection<Contact>();
}