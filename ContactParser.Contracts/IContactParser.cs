using ContactParser.Contracts.Data;

namespace ContactParser.Contracts;

public interface IContactParser
{
    public Task<PossibleContact> ParseContact(string input);
}