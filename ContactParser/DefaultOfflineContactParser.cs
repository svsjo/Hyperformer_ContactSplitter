using ContactParser.Contracts;
using ContactParser.Contracts.Data;

namespace ContactParser;

public class DefaultOfflineContactParser : IOfflineContactParser
{
    public Task<PossibleContact> ParseContact(string input)
    {
        throw new NotImplementedException();
    }
}