using ContactParser.Contracts.Data;

namespace ContactParser.Contracts;

public interface IContactParser
{
    public Contact ParseContact(string input);
}