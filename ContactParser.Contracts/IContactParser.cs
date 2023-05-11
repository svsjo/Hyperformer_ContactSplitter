using ContactParser.Contracts.Data;

namespace ContactParser.Contracts;

/// <summary>
/// Represents a variant of IContactParser, which does not use online ressources
/// </summary>
public interface IContactParser
{
    public Task<PossibleContact> ParseContact(string input);
}