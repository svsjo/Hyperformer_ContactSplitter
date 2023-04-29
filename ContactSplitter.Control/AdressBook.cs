using System.Collections.ObjectModel;
using ContactParser.Contracts.Data;

namespace ContactSplitter.Control;

public static class AdressBook
{
    public static ObservableCollection<Contact> AllContacts { get; set; } = new ObservableCollection<Contact>()
    {
        new Contact()
        {
            ForeName = "Jonas Noah",
            LastName = "Schmid-Weis",
            Gender = "M",
            LetterSalutation = "Sehr geehrter",
            Salutation = "Sehr geehrter",
            Title = "Prof. Dr.-Ing."
        },
        new Contact()
        {
            ForeName = "Nonas Joah",
            LastName = "Weis-Schmid",
            Gender = "F",
            LetterSalutation = "Sehr geehrte",
            Salutation = "Sehr geehrte",
            Title = "Dr.-Ing. net. rar."
        },
        new Contact()
        {
            ForeName = "Arne",
            LastName = "Amel",
            Gender = "M",
            LetterSalutation = "Hallo",
            Salutation = "Moin",
            Title = "Absolvent"
        },
    };
}