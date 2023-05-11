namespace ContactSplitter.DataStorage.Contracts;

public class Contact
{
    public string Salutation { get; init; } = string.Empty;
    public string LetterSalutation { get; init; } = string.Empty;
    public string Title { get; init; } = string.Empty;
    public string Gender { get; init; } = string.Empty;
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;

    public bool IsEmpty => string.IsNullOrEmpty(Salutation)
                           && string.IsNullOrEmpty(LetterSalutation)
                           && string.IsNullOrEmpty(Title)
                           && string.IsNullOrEmpty(Gender)
                           && string.IsNullOrEmpty(FirstName)
                           && string.IsNullOrEmpty(LastName);
}