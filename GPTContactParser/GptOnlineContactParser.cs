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
        string res;
        try
        {
            res = await GptApiClient.Request(input, GptContactParserPrompt.Get());
        }
        catch (Exception)
        {
            throw new ApiException();
        }

        var resParts = res.Split(";");
        if (resParts.Length < 6) return new PossibleContact();

        return new PossibleContact
        {
            Title = resParts.ElementAtOrDefault(1)?.Trim() ?? "",
            Salutation = resParts.ElementAtOrDefault(0)?.Trim() ?? "",
            LetterSalutation = resParts.ElementAtOrDefault(2)?.Trim() ?? "",
            FirstName = resParts.ElementAtOrDefault(3)?.Trim() ?? "",
            Gender = resParts.ElementAtOrDefault(5)?.Trim() ?? "",
            LastName = resParts.ElementAtOrDefault(4)?.Trim() ?? ""
        };
    }
}