namespace ContactSplitter.DataStorage.Contracts;

/// <summary>
/// Represents the results of parsing, before adjustment and confirmation by the user.
/// </summary>
public class PossibleContact
{
    public string RawContact { get; init; } = string.Empty;
    public string Salutation { get; init; } = string.Empty;
    public string LetterSalutation { get; init; } = string.Empty;
    public string Title { get; init; } = string.Empty;
    public string Gender { get; init; } = string.Empty;
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Note { get; set; } = string.Empty;
    public string NotParsed { get; set; } = string.Empty;
}