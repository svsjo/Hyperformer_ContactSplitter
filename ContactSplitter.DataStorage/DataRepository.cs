#region

using System.Collections.ObjectModel;
using ContactSplitter.DataStorage.Contracts;
using ContactSplitter.DataStorage.Contracts.HelperClasses;

#endregion

namespace ContactSplitter.DataStorage;

public class DataRepository : IDataRepository
{
    public ObservableCollection<Contact> AdressBook { get; set; } = new()
    {
        new Contact
        {
            Salutation = "Frau",
            LetterSalutation = "Sehr geehrte Frau",
            Title = "",
            Gender = "F",
            FirstName = "Sandra",
            LastName = "Berger"
        },
        new Contact
        {
            Salutation = "Herr Doktor",
            LetterSalutation = "Sehr geehrter Herr Doktor",
            Title = "Dr.",
            Gender = "M",
            FirstName = "Sandro",
            LastName = "Gutmensch"
        },
        new Contact
        {
            Salutation = "Herr Professor",
            LetterSalutation = "Sehr geehrter Herr Professor",
            Title = "Professor Freiherr",
            Gender = "M",
            FirstName = "Heinreich",
            LastName = "vom Wald"
        },
        new Contact
        {
            Salutation = "Frau Professorin",
            LetterSalutation = "Sehr geehrte Frau Professorin",
            Title = "Prof. Dr. rer. nat.",
            Gender = "F",
            FirstName = "Maria",
            LastName = "von Leuthäuser-Schnarrenberger"
        },
        new Contact
        {
            Salutation = "Herr Diplom-Ingenieur",
            LetterSalutation = "Sehr geehrter Herr Diplom-Ingenieur",
            Title = "Dipl.-Ing.",
            Gender = "M",
            FirstName = "Max Moritz",
            LastName = "von Müller"
        },
        new Contact
        {
            Salutation = "Doktoren und Doktorinnen",
            LetterSalutation = "Sehr geehrte Doktoren und Doktorinnen",
            Title = "Dr.",
            Gender = "D",
            FirstName = "Winfried",
            LastName = "Russwurm"
        },
        new Contact
        {
            Salutation = "Herr Doktor-Ingenieur",
            LetterSalutation = "Sehr geehrter Herr Doktor-Ingenieur",
            Title = "Dr.-Ing. Dr. rer. nat. Dr. h.c. mult.",
            Gender = "M",
            FirstName = "Paul Peter",
            LastName = "Steffens"
        },
        new Contact
        {
            Salutation = "Frau Doktorin",
            LetterSalutation = "Sehr geehrte Frau Doktorin",
            Title = "Dr. med.",
            Gender = "F",
            FirstName = "Petra Clara",
            LastName = "Schmitz-Hoffmann"
        },
        new Contact
        {
            Salutation = "Herr Professor",
            LetterSalutation = "Sehr geehrter Herr Professor",
            Title = "Professor Dr. rer. pol.",
            Gender = "M",
            FirstName = "Hans-Joachim",
            LastName = "Schmidt"
        },
        new Contact
        {
            Salutation = "Frau Diplom-Ingenieurin",
            LetterSalutation = "Sehr geehrte Frau Diplom-Ingenieurin",
            Title = "Dipl.-Ing.",
            Gender = "F",
            FirstName = "Karin",
            LastName = "Müller-Lüdenscheidt"
        },
        new Contact
        {
            Salutation = "Herr Doktor",
            LetterSalutation = "Sehr geehrter Herr Doktor",
            Title = "Dr. phil. habil.",
            Gender = "M",
            FirstName = "Horst",
            LastName = "Schmid-Weis"
        },
        new Contact
        {
            Salutation = "Herr Diplom-Kaufmann",
            LetterSalutation = "Sehr geehrter Herr Diplom-Kaufmann",
            Title = "Dipl.-Kfm.",
            Gender = "M",
            FirstName = "Johannes",
            LastName = "Maier-Schulze"
        },
        new Contact
        {
            Salutation = "Doktoren und Doktorinnen",
            LetterSalutation = "Sehr geehrte Doktoren und Doktorinnen",
            Title = "Dr. rer. nat.",
            Gender = "D",
            FirstName = "Ingrid",
            LastName = "Schulz"
        },
        new Contact
        {
            Salutation = "Herr Diplom-Ingenieur",
            LetterSalutation = "Sehr geehrter Herr Diplom-Ingenieur",
            Title = "Dipl.-Ing.",
            Gender = "M",
            FirstName = "Michael",
            LastName = "Bauer"
        },
        new Contact
        {
            Salutation = "Frau Doktorin",
            LetterSalutation = "Sehr geehrte Frau Doktorin",
            Title = "Dr. iur.",
            Gender = "F",
            FirstName = "Claudia",
            LastName = "Schuster-Müller"
        },
        new Contact
        {
            Salutation = "Herr Doktor",
            LetterSalutation = "Sehr geehrter Herr Doktor",
            Title = "Dr. rer. nat. habil.",
            Gender = "M",
            FirstName = "Franz",
            LastName = "Bauer"
        },
        new Contact
        {
            Salutation = "Frau Professorin",
            LetterSalutation = "Sehr geehrte Frau Professorin",
            Title = "Prof. Dr. rer. pol. habil.",
            Gender = "F",
            FirstName = "Anna",
            LastName = "Schmidt-Weiß"
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
        new Title { MaleTitle = "politicae", Abbreviation = "pol.", IsGeneric = true },
        new Title { MaleTitle = "rerum", Abbreviation = "rer.", IsGeneric = true },
        new Title { MaleTitle = "nat", Abbreviation = "nat.", IsGeneric = true }, // Naturwissenschaften
        new Title { MaleTitle = "physiologiae", Abbreviation = "physiol.", IsGeneric = true }, // Physiologie
        new Title { MaleTitle = "pharmaciae", Abbreviation = "pharm.", IsGeneric = true }, // Pharmazie
        new Title { MaleTitle = "odontologiae", Abbreviation = "odont.", IsGeneric = true }, // Zahnmedizin
        new Title { MaleTitle = "ophthalmologiae", Abbreviation = "ophthal.", IsGeneric = true }, // Augenheilkunde
        new Title { MaleTitle = "dermatologiae", Abbreviation = "derm.", IsGeneric = true }, // Dermatologie
        new Title { MaleTitle = "endocrinologiae", Abbreviation = "endocr.", IsGeneric = true }, // Endokrinologie
        new Title { MaleTitle = "gastroenterologiae", Abbreviation = "gastro.", IsGeneric = true }, // Gastroenterologie
        new Title { MaleTitle = "hematologiae", Abbreviation = "hematol.", IsGeneric = true }, // Hämatologie
        new Title { MaleTitle = "obstetriciae", Abbreviation = "obst.", IsGeneric = true }, // Geburtshilfe
        new Title { MaleTitle = "oncologiae", Abbreviation = "onco.", IsGeneric = true }, // Onkologie
        new Title
        {
            MaleTitle = "otolaryngologiae", Abbreviation = "oto.", IsGeneric = true
        }, // Hals-Nasen-Ohrenheilkunde
        new Title { MaleTitle = "pneumologiae", Abbreviation = "pneumol.", IsGeneric = true }, // Pneumologie
        new Title { MaleTitle = "proctologiae", Abbreviation = "proctol.", IsGeneric = true }, // Proktologie
        new Title { MaleTitle = "radiologiae", Abbreviation = "radiol.", IsGeneric = true }, // Radiologie
        new Title { MaleTitle = "rheumatologiae", Abbreviation = "rheumatol.", IsGeneric = true }, // Rheumatologie
        new Title { MaleTitle = "urologiae", Abbreviation = "uro.", IsGeneric = true }, // Urologie
        new Title { MaleTitle = "venerologiae", Abbreviation = "venerol.", IsGeneric = true }, // Venerologie
        new Title { MaleTitle = "toxicologiae", Abbreviation = "tox.", IsGeneric = true }, // Toxikologie
        new Title { MaleTitle = "anatomiae", Abbreviation = "anat.", IsGeneric = true }, // Anatomie
        new Title { MaleTitle = "pathologiae", Abbreviation = "pathol.", IsGeneric = true }, // Pathologie
        new Title { MaleTitle = "hygienicae", Abbreviation = "hyg.", IsGeneric = true }, // Hygiene
        new Title { MaleTitle = "socialis", Abbreviation = "soc.", IsGeneric = true }, // Sozialwissenschaften
        new Title { MaleTitle = "publicae", Abbreviation = "publ.", IsGeneric = true },
        new Title { MaleTitle = "artium", Abbreviation = "art.", IsGeneric = true }, // Geisteswissenschaften
        new Title { MaleTitle = "ethicae", Abbreviation = "eth.", IsGeneric = true }, // Ethik
        new Title { MaleTitle = "logicae", Abbreviation = "log.", IsGeneric = true }, // Logik
        new Title { MaleTitle = "linguae antiquae", Abbreviation = "ling. ant.", IsGeneric = true }, // Alte Sprachen
        new Title { MaleTitle = "architecturae", Abbreviation = "arch.", IsGeneric = true }, // Architektur
        new Title { MaleTitle = "astronomiae", Abbreviation = "astron.", IsGeneric = true }, // Astronomie
        new Title { MaleTitle = "psychiatriae", Abbreviation = "psychiat.", IsGeneric = true }, // Psychiatrie
        new Title { MaleTitle = "psychotherapiae", Abbreviation = "psychother.", IsGeneric = true }, // Psychotherapie
        new Title { MaleTitle = "sexologiae", Abbreviation = "sexol.", IsGeneric = true }, // Sexologie
        new Title { MaleTitle = "criminologiae", Abbreviation = "crim.", IsGeneric = true }, // Kriminologie
        new Title { MaleTitle = "linguae germanicae", Abbreviation = "germ.", IsGeneric = true }, // Germanistik
        new Title { MaleTitle = "linguae romanicae", Abbreviation = "rom.", IsGeneric = true }, // Romanistik
        new Title { MaleTitle = "linguae slavicae", Abbreviation = "slav.", IsGeneric = true }, // Slawistik
        new Title { MaleTitle = "philologiae", Abbreviation = "philol.", IsGeneric = true }, // Philologie
        new Title { MaleTitle = "geologiae", Abbreviation = "geol.", IsGeneric = true }, // Geologie
        new Title { MaleTitle = "technicae", Abbreviation = "tech.", IsGeneric = true }, // Technikwissenschaften
        new Title { MaleTitle = "pediatriae", Abbreviation = "ped.", IsGeneric = true }, // Pädiatrie
        new Title { MaleTitle = "orthopaediae", Abbreviation = "ortho.", IsGeneric = true }, // Orthopädie
        new Title { MaleTitle = "neonatologiae", Abbreviation = "neonatol.", IsGeneric = true }, // Neonatologie
        new Title { MaleTitle = "audiologiae", Abbreviation = "audiol.", IsGeneric = true }, // Audiologie
        new Title { MaleTitle = "neurochirurgiae", Abbreviation = "neurochir.", IsGeneric = true }, // Neurochirurgie
        new Title { MaleTitle = "radiatiotherapiae", Abbreviation = "rad.ther.", IsGeneric = true }, // Strahlentherapie
        new Title { MaleTitle = "medicinae veterinariae", Abbreviation = "vet.", IsGeneric = true }, // Veterinärmedizin
        new Title { MaleTitle = "didacticae", Abbreviation = "didact.", IsGeneric = true },
        new Title
        {
            MaleTitle = "aequatoriae", Abbreviation = "aequat.", IsGeneric = true
        }, // Äquatoriale Wissenschaften
        new Title
        {
            MaleTitle = "bibliothecariae", Abbreviation = "bibl.", IsGeneric = true
        }, // Bibliothekswissenschaften
        new Title { MaleTitle = "generosae", Abbreviation = "gen.", IsGeneric = true }, // Gender Studies
        new Title { MaleTitle = "ethnologiae", Abbreviation = "ethnol.", IsGeneric = true }, // Ethnologie
        new Title { MaleTitle = "chirurgiae", Abbreviation = "chir.", IsGeneric = true }, // Chirurgie
        new Title { MaleTitle = "cardiologiae", Abbreviation = "cardiol.", IsGeneric = true }, // Kardiologie
        new Title { MaleTitle = "gerontologiae", Abbreviation = "gerontol.", IsGeneric = true }, // Gerontologie
        new Title { MaleTitle = "anglisticae", Abbreviation = "angl.", IsGeneric = true }, // Anglistik
        new Title { MaleTitle = "sinologiae", Abbreviation = "sinol.", IsGeneric = true }, // Sinologie
        new Title { MaleTitle = "sinologicae", Abbreviation = "sinol.", IsGeneric = true }, // Sinologie (alternativ)
        new Title { MaleTitle = "sinicis", Abbreviation = "sin.", IsGeneric = true }, // China-Studien
        new Title { MaleTitle = "orientalium", Abbreviation = "or.", IsGeneric = true }, // Orientalistik
        new Title { MaleTitle = "tecnologiae", Abbreviation = "tec.", IsGeneric = true }, // Technologie
        new Title
        {
            MaleTitle = "aeronauticae", Abbreviation = "aero.", IsGeneric = true
        }, // Luft- und Raumfahrttechnik
        new Title { MaleTitle = "econometrica", Abbreviation = "econ.", IsGeneric = true }, // Ökonometrie
        new Title
        {
            MaleTitle = "institute of technology", Abbreviation = "IT", IsGeneric = true
        }, // Institut für Technologie
        new Title { MaleTitle = "biomaterialia", Abbreviation = "biomat.", IsGeneric = true }, // Biomaterialien
        new Title { MaleTitle = "horticulturae", Abbreviation = "hort.", IsGeneric = true }, // Gartenbau
        new Title { MaleTitle = "cellularis", Abbreviation = "cell.", IsGeneric = true }, // Zellbiologie
        new Title
        {
            MaleTitle = "mineralogia et crystallographia", Abbreviation = "min.cryst.", IsGeneric = true
        }, // Mineralogie und Kristallographie
        new Title { MaleTitle = "geobotanicae", Abbreviation = "geobot.", IsGeneric = true }, // Geobotanik
        new Title { MaleTitle = "geomorphologiae", Abbreviation = "geomorph.", IsGeneric = true } // Geomorph
    };

    public ObservableCollection<string> AllPrefixes { get; set; } = new()
    {
        "van",
        "von",
        "zu",
        "de",
        "der",
        "vom",
        "zur",
        "dem",
        "zu",
        "aus",
        "den",
        "über",
        "unter",
        "hinter"
    };
}