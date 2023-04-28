using ContactParser.Contracts.Data;

namespace ContactParser.Contracts;

public interface IContactParser
{
    public PossibleContact ParseContact(string input);
}