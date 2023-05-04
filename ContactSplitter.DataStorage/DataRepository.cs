using System.Collections.ObjectModel;
using ContactParser.Contracts.Data;
using ContactSplitter.DataStorage.HelperClasses;

namespace ContactSplitter.DataStorage
{
    public class DataRepository
    {
        public ObservableCollection<Contact> AdressBook { get; set; } = new ObservableCollection<Contact>()
        {
            new()
            {
                FirstName = "Jonas Noah",
                LastName = "Schmid-Weis",
                Gender = "M",
                LetterSalutation = "Sehr geehrter",
                Salutation = "Sehr geehrter",
                Title = "Prof. Dr.-Ing."
            },
            new()
            {
                FirstName = "Nonas Joah",
                LastName = "Weis-Schmid",
                Gender = "F",
                LetterSalutation = "Sehr geehrte",
                Salutation = "Sehr geehrte",
                Title = "Dr.-Ing. net. rar."
            },
            new()
            {
                FirstName = "Arne",
                LastName = "Amel",
                Gender = "M",
                LetterSalutation = "Hallo",
                Salutation = "Moin",
                Title = "Absolvent"
            },
            new()
            {
                FirstName = "Jonas Noah",
                LastName = "Schmid-Weis",
                Gender = "M",
                LetterSalutation = "Sehr geehrter",
                Salutation = "Sehr geehrter",
                Title = "Prof. Dr.-Ing."
            },
            new()
            {
                FirstName = "Nonas Joah",
                LastName = "Weis-Schmid",
                Gender = "F",
                LetterSalutation = "Sehr geehrte",
                Salutation = "Sehr geehrte",
                Title = "Dr.-Ing. net. rar."
            },
            new()
            {
                FirstName = "Arne",
                LastName = "Amel",
                Gender = "M",
                LetterSalutation = "Hallo",
                Salutation = "Moin",
                Title = "Absolvent"
            },
            new()
            {
                FirstName = "Jonas Noah",
                LastName = "Schmid-Weis",
                Gender = "M",
                LetterSalutation = "Sehr geehrter",
                Salutation = "Sehr geehrter",
                Title = "Prof. Dr.-Ing."
            },
            new()
            {
                FirstName = "Nonas Joah",
                LastName = "Weis-Schmid",
                Gender = "F",
                LetterSalutation = "Sehr geehrte",
                Salutation = "Sehr geehrte",
                Title = "Dr.-Ing. net. rar."
            },
            new()
            {
                FirstName = "Arne",
                LastName = "Amel",
                Gender = "M",
                LetterSalutation = "Hallo",
                Salutation = "Moin",
                Title = "Absolvent"
            },
            new()
            {
                FirstName = "Jonas Noah",
                LastName = "Schmid-Weis",
                Gender = "M",
                LetterSalutation = "Sehr geehrter",
                Salutation = "Sehr geehrter",
                Title = "Prof. Dr.-Ing."
            },
            new()
            {
                FirstName = "Nonas Joah",
                LastName = "Weis-Schmid",
                Gender = "F",
                LetterSalutation = "Sehr geehrte",
                Salutation = "Sehr geehrte",
                Title = "Dr.-Ing. net. rar."
            },
            new()
            {
                FirstName = "Arne",
                LastName = "Amel",
                Gender = "M",
                LetterSalutation = "Hallo",
                Salutation = "Moin",
                Title = "Absolvent"
            },
            new()
            {
                FirstName = "Jonas Noah",
                LastName = "Schmid-Weis",
                Gender = "M",
                LetterSalutation = "Sehr geehrter",
                Salutation = "Sehr geehrter",
                Title = "Prof. Dr.-Ing."
            },
            new()
            {
                FirstName = "Nonas Joah",
                LastName = "Weis-Schmid",
                Gender = "F",
                LetterSalutation = "Sehr geehrte",
                Salutation = "Sehr geehrte",
                Title = "Dr.-Ing. net. rar."
            },
            new()
            {
                FirstName = "Arne",
                LastName = "Amel",
                Gender = "M",
                LetterSalutation = "Hallo",
                Salutation = "Moin",
                Title = "Absolvent"
            },
            new()
            {
                FirstName = "Jonas Noah",
                LastName = "Schmid-Weis",
                Gender = "M",
                LetterSalutation = "Sehr geehrter",
                Salutation = "Sehr geehrter",
                Title = "Prof. Dr.-Ing."
            },
            new()
            {
                FirstName = "Nonas Joah",
                LastName = "Weis-Schmid",
                Gender = "F",
                LetterSalutation = "Sehr geehrte",
                Salutation = "Sehr geehrte",
                Title = "Dr.-Ing. net. rar."
            },
            new()
            {
                FirstName = "Arne",
                LastName = "Amel",
                Gender = "M",
                LetterSalutation = "Hallo",
                Salutation = "Moin",
                Title = "Absolvent"
            },
            new()
            {
                FirstName = "Jonas Noah",
                LastName = "Schmid-Weis",
                Gender = "M",
                LetterSalutation = "Sehr geehrter",
                Salutation = "Sehr geehrter",
                Title = "Prof. Dr.-Ing."
            },
            new()
            {
                FirstName = "Nonas Joah",
                LastName = "Weis-Schmid",
                Gender = "F",
                LetterSalutation = "Sehr geehrte",
                Salutation = "Sehr geehrte",
                Title = "Dr.-Ing. net. rar."
            },
            new()
            {
                FirstName = "Arne",
                LastName = "Amel",
                Gender = "M",
                LetterSalutation = "Hallo",
                Salutation = "Moin",
                Title = "Absolvent"
            },
            new()
            {
                FirstName = "Jonas Noah",
                LastName = "Schmid-Weis",
                Gender = "Männlich",
                LetterSalutation = "Sehr geehrter",
                Salutation = "Sehr geehrter",
                Title = "Prof. Dr.-Ing."
            },
            new()
            {
                FirstName = "Nonas Joah",
                LastName = "Weis-Schmid",
                Gender = "F",
                LetterSalutation = "Sehr geehrte",
                Salutation = "Sehr geehrte",
                Title = "Dr.-Ing. net. rar."
            },
            new()
            {
                FirstName = "Arne",
                LastName = "Amel",
                Gender = "M",
                LetterSalutation = "Hallo",
                Salutation = "Moin",
                Title = "Absolvent"
            },
        };

        public ObservableCollection<Title> AllTitles { get; set; } = new ObservableCollection<Title>()
        {
            new Title { MaleTitle = "Graf", Abbreviation = "Gf." },
            new Title { MaleTitle = "Gräfin", Abbreviation = "Grfn." },
            new Title { MaleTitle = "Baron", Abbreviation = "Bar." },
            new Title { MaleTitle = "Baronin", Abbreviation = "Barin." },
            new Title { MaleTitle = "Freiherr", Abbreviation = "Frhr." },
            new Title { MaleTitle = "Freifrau", Abbreviation = "Frn." },
            new Title { MaleTitle = "Freiherrin", Abbreviation = "Frn." },
            new Title { MaleTitle = "Doktor", Abbreviation = "Dr." },
            new Title { MaleTitle = "Professor", Abbreviation = "Prof." },
        };

        public ObservableCollection<string> AllPrefixes { get; set; } = new ObservableCollection<string>()
        {
            "van",
            "von"
        };
    }
}