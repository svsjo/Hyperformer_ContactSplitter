namespace ContactParser.Contracts.Data;

public class PossibleContact
{
    public ContactFieldWrapper RawContact { get; set; } // Input String
    public ContactFieldWrapper Salutation { get; set; } // Anrede
    public ContactFieldWrapper LetterSalutation { get; set; } // Brief-Anrede
    public ContactFieldWrapper Title { get; set; } // Titel
    public ContactFieldWrapper Gender { get; set; } // Geschlecht
    public ContactFieldWrapper ForeName { get; set; } // Vorname
    public ContactFieldWrapper LastName { get; set; } // Nachname
    public string Note { get; set; } = string.Empty;
    public string NotParsed { get; set; } = string.Empty;
}