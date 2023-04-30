using System.Collections.ObjectModel;
using ContactParser.Contracts.Data;

namespace ContactSplitter.DataStorage
{
    public static class DataRepository
    {
        public static ObservableCollection<Contact> AdressBook { get; set; } = new ObservableCollection<Contact>()
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
            },
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
            },
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
            },
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
            },
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
            },
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
            },
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
            },
            new()
            {
                ForeName = "Jonas Noah",
                LastName = "Schmid-Weis",
                Gender = "Männlich",
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
            },
        };

        public static ObservableCollection<string> AllTitles { get; set; } = new ObservableCollection<string>()
        {
            "Dr.",
            "Prof.",
            "Dipl.-Ing.",
            "Ing.",
            "Mag.",
            "Baron",
            "Graf",
            "Herzog",
            "Fürst",
            "Dipl.-Kfm.",
            "RA",
            "Notar"
        };
    }
}