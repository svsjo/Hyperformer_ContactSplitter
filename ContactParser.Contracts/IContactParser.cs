#region

using ContactSplitter.DataStorage.Contracts;

#endregion

namespace ContactParser.Contracts;

/// <summary>
/// Represents a variant of IContactParser, which does not use online ressources
/// </summary>
public interface IContactParser
{
    public Task<PossibleContact> ParseContact(string input);
}