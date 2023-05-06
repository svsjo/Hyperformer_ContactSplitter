using System.Runtime.CompilerServices;

namespace ContactParser.Contracts.Data;

public class Contact
{
    public string Salutation { get; set; } = string.Empty; // Anrede
    public string LetterSalutation { get; set; } = string.Empty; // Brief-Anrede
    public string Title { get; set; } = string.Empty; // Titel
    public string Gender { get; set; } = string.Empty; // Geschlecht
    public string FirstName { get; set; } = string.Empty; // Vorname
    public string LastName { get; set; } = string.Empty; // Nachname

    public bool IsEmpty => string.IsNullOrEmpty(Salutation)
                           && string.IsNullOrEmpty(LetterSalutation)
                           && string.IsNullOrEmpty(Title)
                           && string.IsNullOrEmpty(Gender)
                           && string.IsNullOrEmpty(FirstName)
                           && string.IsNullOrEmpty(LastName);
}