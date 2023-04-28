namespace ContactParser.Contracts.Data;

public class Contact
{
    public string RawContact { get; set; } = string.Empty; // Input String
    public string Salutation { get; set; } = string.Empty; // Anrede
    public string LetterSalutation { get; set; } = string.Empty; // Brief-Anrede
    public string Title { get; set; } = string.Empty; // Titel
    public string Gender { get; set; } = string.Empty; // Geschlecht
    public string ForeName { get; set; } = string.Empty; // Vorname
    public string LastName { get; set; } = string.Empty; // Nachname
}