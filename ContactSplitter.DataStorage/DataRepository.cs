using System.Collections.ObjectModel;
using ContactParser.Contracts.Data;
using ContactSplitter.DataStorage.HelperClasses;

namespace ContactSplitter.DataStorage;

public class DataRepository
{
    public ObservableCollection<Contact> AdressBook { get; set; } = new()
    {
        new Contact
        {
            FirstName = "TempData",
            LastName = "Temp-Data",
            Gender = "M",
            LetterSalutation = "Sehr geehrter Herr",
            Salutation = "Herr",
            Title = "Prof. Dr.-Ing."
        },
        new Contact
        {
            FirstName = "TempData",
            LastName = "Temp-Data",
            Gender = "M",
            LetterSalutation = "Sehr geehrter Herr",
            Salutation = "Herr",
            Title = "Prof. Dr.-Ing."
        },
        new Contact
        {
            FirstName = "TempData",
            LastName = "Temp-Data",
            Gender = "M",
            LetterSalutation = "Sehr geehrter Herr",
            Salutation = "Herr",
            Title = "Prof. Dr.-Ing."
        },
        new Contact
        {
            FirstName = "TempData",
            LastName = "Temp-Data",
            Gender = "M",
            LetterSalutation = "Sehr geehrter Herr",
            Salutation = "Herr",
            Title = "Prof. Dr.-Ing."
        },
        new Contact
        {
            FirstName = "TempData",
            LastName = "Temp-Data",
            Gender = "M",
            LetterSalutation = "Sehr geehrter Herr",
            Salutation = "Herr",
            Title = "Prof. Dr.-Ing."
        },
        new Contact
        {
            FirstName = "TempData",
            LastName = "Temp-Data",
            Gender = "M",
            LetterSalutation = "Sehr geehrter Herr",
            Salutation = "Herr",
            Title = "Prof. Dr.-Ing."
        },
        new Contact
        {
            FirstName = "TempData",
            LastName = "Temp-Data",
            Gender = "M",
            LetterSalutation = "Sehr geehrter Herr",
            Salutation = "Herr",
            Title = "Prof. Dr.-Ing."
        },
        new Contact
        {
            FirstName = "TempData",
            LastName = "Temp-Data",
            Gender = "M",
            LetterSalutation = "Sehr geehrter Herr",
            Salutation = "Herr",
            Title = "Prof. Dr.-Ing."
        },
        new Contact
        {
            FirstName = "TempData",
            LastName = "Temp-Data",
            Gender = "M",
            LetterSalutation = "Sehr geehrter Herr",
            Salutation = "Herr",
            Title = "Prof. Dr.-Ing."
        },
        new Contact
        {
            FirstName = "TempData",
            LastName = "Temp-Data",
            Gender = "M",
            LetterSalutation = "Sehr geehrter Herr",
            Salutation = "Herr",
            Title = "Prof. Dr.-Ing."
        },
        new Contact
        {
            FirstName = "TempData",
            LastName = "Temp-Data",
            Gender = "M",
            LetterSalutation = "Sehr geehrter Herr",
            Salutation = "Herr",
            Title = "Prof. Dr.-Ing."
        }
    };

    public ObservableCollection<Title> AllTitles { get; set; } = new()
    {
        new Title { MaleTitle = "Graf", Abbreviation = "Gf." },
        new Title { MaleTitle = "Baron", Abbreviation = "Bar." },
        new Title { MaleTitle = "Freiherr", Abbreviation = "Frhr." },
        new Title { MaleTitle = "König", Abbreviation = "Kg." },
        new Title { MaleTitle = "Kaiser", Abbreviation = "Ks." },
        new Title { MaleTitle = "Doktor", Abbreviation = "Dr." },
        new Title { MaleTitle = "Professor", Abbreviation = "Prof." },
        new Title { MaleTitle = "Bachelor", Abbreviation = "B." },
        new Title { MaleTitle = "Master", Abbreviation = "M." },
        new Title { MaleTitle = "Magister", Abbreviation = "Mag." },
        new Title { MaleTitle = "Bachelor", Abbreviation = "B." },
        new Title { MaleTitle = "Diplom-Ingenieur", Abbreviation = "Dipl.-Ing." },
        new Title { MaleTitle = "Diplom-Psychologe", Abbreviation = "Dipl.-Psych." },
        new Title { MaleTitle = "Diplom-Betriebswirt", Abbreviation = "Dipl.-Bw." },
        new Title { MaleTitle = "Diplom-Kaufmann", Abbreviation = "Dipl.-Kfm." },
        new Title { MaleTitle = "Diplom-Jurist", Abbreviation = "Dipl.-Jur." },
        new Title { MaleTitle = "Diplom-Mediziner", Abbreviation = "Dipl.-Med." },
        new Title { MaleTitle = "Diplom-Pädagoge", Abbreviation = "Dipl.-Päd." },
        new Title { MaleTitle = "Diplom-Soziologe", Abbreviation = "Dipl.-Soz." },
        new Title { MaleTitle = "Diplom-Verwaltungswirt", Abbreviation = "Dipl.-Verw." },
        new Title { MaleTitle = "Diplom-Theologe", Abbreviation = "Dipl.-Theol." },
        new Title { MaleTitle = "Diplom-Volkswirt", Abbreviation = "Dipl.-Vw." },
        new Title { MaleTitle = "Diplom-Kauffrau", Abbreviation = "Dipl.-Kffr." },
        new Title { MaleTitle = "Diplom-Informatiker", Abbreviation = "Dipl.-Inf." },
        new Title { MaleTitle = "Diplom-Physiker", Abbreviation = "Dipl.-Phys." },
        new Title { MaleTitle = "Diplom-Chemiker", Abbreviation = "Dipl.-Chem." },
        new Title { MaleTitle = "Diplom-Mathematiker", Abbreviation = "Dipl.-Math." },
        new Title { MaleTitle = "Diplom-Geologe", Abbreviation = "Dipl.-Geol." },
        new Title { MaleTitle = "Diplom-Sozialpädagoge", Abbreviation = "Dipl.-Soz.-Päd." },
        new Title { MaleTitle = "Diplom-Designer", Abbreviation = "Dipl.-Des." },
        new Title { MaleTitle = "Diplom-Kulturwissenschaftler", Abbreviation = "Dipl.-Kult." },
        new Title { MaleTitle = "Diplom-Handelslehrer", Abbreviation = "Dipl.-Hdl." },
        new Title { MaleTitle = "Diplom-Sportwissenschaftler", Abbreviation = "Dipl.-Sportwiss." },
        new Title { MaleTitle = "Diplom-Umweltwissenschaftler", Abbreviation = "Dipl.-Umweltwiss." },
        new Title { MaleTitle = "Diplom-Informatiker", Abbreviation = "Dipl.-Inform." },
        new Title { MaleTitle = "Diplom-Wirtschaftsingenieur", Abbreviation = "Dipl.-Wi.-Ing." },
        new Title { MaleTitle = "Diplom-Agraringenieur", Abbreviation = "Dipl.-Agraring." },
        new Title { MaleTitle = "Diplom-Architekt", Abbreviation = "Dipl.-Arch." },
        new Title { MaleTitle = "Doktor-Ingenieur", Abbreviation = "Dr.-Ing." },
        new Title { MaleTitle = "agriculturae", Abbreviation = "agr.", IsGeneric = true },
        new Title { MaleTitle = "biologiae", Abbreviation = "biol.", IsGeneric = true },
        new Title { MaleTitle = "animalis", Abbreviation = "anim.", IsGeneric = true },
        new Title { MaleTitle = "Ingenieur", Abbreviation = "Ing." },
        new Title { MaleTitle = "Techniker", Abbreviation = "Tech." },
        new Title { MaleTitle = "Meister", Abbreviation = "Mst." },
        new Title { MaleTitle = "Architekt", Abbreviation = "Arch." },
        new Title { MaleTitle = "Psychologe", Abbreviation = "Psych." },
        new Title { MaleTitle = "Sozialarbeiter", Abbreviation = "Soz." },
        new Title { MaleTitle = "Pfarrer", Abbreviation = "Pfr." },
        new Title { MaleTitle = "Präsident", Abbreviation = "Präs." },
        new Title { MaleTitle = "Vizepräsident", Abbreviation = "VPräs." },
        new Title { MaleTitle = "Bürgermeister", Abbreviation = "Bgm." },
        new Title { MaleTitle = "Staatssekretär", Abbreviation = "StS." },
        new Title { MaleTitle = "Generaldirektor", Abbreviation = "GenDir." },
        new Title { MaleTitle = "Geschäftsführer", Abbreviation = "Gf." },
        new Title { MaleTitle = "Leitender Oberarzt", Abbreviation = "Ltd. OA" },
        new Title { MaleTitle = "Facharzt", Abbreviation = "FA" },
        new Title { MaleTitle = "Oberstleutnant", Abbreviation = "Oberstlt." },
        new Title { MaleTitle = "Major", Abbreviation = "Maj." },
        new Title { MaleTitle = "Hauptmann", Abbreviation = "Hptm." },
        new Title { MaleTitle = "Oberfeldwebel", Abbreviation = "OFw." },
        new Title { MaleTitle = "Leutnant", Abbreviation = "Lt." },
        new Title { MaleTitle = "Feldwebel", Abbreviation = "Fw." },
        new Title { MaleTitle = "Gefreiter", Abbreviation = "Gefr." },
        new Title { MaleTitle = "Soldat", Abbreviation = "Sold." },
        new Title { MaleTitle = "Künstler", Abbreviation = "Kü." },
        new Title { MaleTitle = "Autor", Abbreviation = "Autor" },
        new Title { MaleTitle = "Musiker", Abbreviation = "Mus." },
        new Title { MaleTitle = "Sänger", Abbreviation = "Säng." },
        new Title { MaleTitle = "Schauspieler", Abbreviation = "Schaus." },
        new Title { MaleTitle = "Regisseur", Abbreviation = "Reg." },
        new Title { MaleTitle = "Sportler", Abbreviation = "Sp." },
        new Title { MaleTitle = "Trainer", Abbreviation = "Tr." },
        new Title { MaleTitle = "Philosoph", Abbreviation = "Phil." },
        new Title { MaleTitle = "Wissenschaftler", Abbreviation = "Wiss." },
        new Title { MaleTitle = "pedagogicae", Abbreviation = "päd.", IsGeneric = true },
        new Title { MaleTitle = "biomedicinae", Abbreviation = "biomed.", IsGeneric = true },
        new Title { MaleTitle = "biophysicae", Abbreviation = "biophys.", IsGeneric = true },
        new Title { MaleTitle = "biotechnologiae", Abbreviation = "biotech.", IsGeneric = true },
        new Title { MaleTitle = "geneticae", Abbreviation = "genet.", IsGeneric = true },
        new Title { MaleTitle = "neurologicae", Abbreviation = "neuro.", IsGeneric = true },
        new Title { MaleTitle = "molecularis", Abbreviation = "mol.", IsGeneric = true },
        new Title { MaleTitle = "agronomicae", Abbreviation = "agron.", IsGeneric = true },
        new Title { MaleTitle = "forensicae", Abbreviation = "forens.", IsGeneric = true },
        new Title { MaleTitle = "evolutionis", Abbreviation = "evol.", IsGeneric = true },
        new Title { MaleTitle = "immunologiae", Abbreviation = "immun.", IsGeneric = true },
        new Title { MaleTitle = "ecologicae", Abbreviation = "ecol.", IsGeneric = true },
        new Title { MaleTitle = "zoologicae", Abbreviation = "zool.", IsGeneric = true },
        new Title { MaleTitle = "botanicae", Abbreviation = "bot.", IsGeneric = true },
        new Title { MaleTitle = "meteorologicae", Abbreviation = "met.", IsGeneric = true },
        new Title { MaleTitle = "astrophysicae", Abbreviation = "astro.", IsGeneric = true },
        new Title { MaleTitle = "biogeographicae", Abbreviation = "biogeo.", IsGeneric = true },
        new Title { MaleTitle = "palaeontologicae", Abbreviation = "paläo.", IsGeneric = true },
        new Title { MaleTitle = "linguae", Abbreviation = "ling.", IsGeneric = true },
        new Title { MaleTitle = "Habilitation", Abbreviation = "Habil.", IsGeneric = true },
        new Title { MaleTitle = "medicinae", Abbreviation = "med.", IsGeneric = true },
        new Title { MaleTitle = "juris", Abbreviation = "jur.", IsGeneric = true },
        new Title { MaleTitle = "physicae", Abbreviation = "phys.", IsGeneric = true },
        new Title { MaleTitle = "chemiae", Abbreviation = "chem.", IsGeneric = true },
        new Title { MaleTitle = "linguisticae", Abbreviation = "ling.", IsGeneric = true },
        new Title { MaleTitle = "mathematicae", Abbreviation = "math.", IsGeneric = true },
        new Title { MaleTitle = "geographicae", Abbreviation = "geogr.", IsGeneric = true },
        new Title { MaleTitle = "musicae", Abbreviation = "mus.", IsGeneric = true },
        new Title { MaleTitle = "theologicae", Abbreviation = "theol.", IsGeneric = true },
        new Title { MaleTitle = "informatik", Abbreviation = "inf.", IsGeneric = true },
        new Title { MaleTitle = "psychologiae", Abbreviation = "psychol.", IsGeneric = true },
        new Title { MaleTitle = "soziologiae", Abbreviation = "soz.", IsGeneric = true },
        new Title { MaleTitle = "philosophiae", Abbreviation = "phil.", IsGeneric = true },
        new Title { MaleTitle = "historicae", Abbreviation = "hist.", IsGeneric = true },
        new Title { MaleTitle = "politicae", Abbreviation = "pol.", IsGeneric = true }
    };

    public ObservableCollection<string> AllPrefixes { get; set; } = new()
    {
        "van",
        "von",
        "zu",
        "de",
        "der"
    };
}