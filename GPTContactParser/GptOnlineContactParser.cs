#region

using System.Net;
using ContactParser.Contracts;
using ContactParser.Contracts.Data;

#endregion

namespace GPTContactParser;

public class GptOnlineContactParser : IOnlineContactParser
{
    public async Task<PossibleContact> ParseContact(string input)
    {
        var res = await GptApiClient.Request(input, GptContactParserPrompt.Get());
        var resParts = res.Split(";");
        if (resParts.Length < 6) return new PossibleContact();

        return new PossibleContact
        {
            Title = resParts[1].Trim(),
            Salutation = resParts[0].Trim(),
            LetterSalutation = resParts[2].Trim(),
            FirstName = resParts[3].Trim(),
            Gender = resParts[5].Trim(),
            LastName = resParts[4].Trim()
        };
    }
}