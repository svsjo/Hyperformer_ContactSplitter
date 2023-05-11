#region

using System.Collections.ObjectModel;
using ContactSplitter.DataStorage.Contracts.HelperClasses;

#endregion

namespace ContactSplitter.DataStorage.Contracts;

public interface IDataRepository
{
    public ObservableCollection<Contact> AdressBook { get; set; }
    public ObservableCollection<Title> AllTitles { get; set; }
    public ObservableCollection<string> AllPrefixes { get; set; }
}