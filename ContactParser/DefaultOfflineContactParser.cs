using ContactParser.Contracts;
using ContactParser.Contracts.Data;
using ContactSplitter.DataStorage;

namespace ContactParser;

public class DefaultOfflineContactParser : IOfflineContactParser
{
    private DataRepository _dataRepository;

    public DefaultOfflineContactParser(DataRepository dataRepository)
    {
        _dataRepository = dataRepository;
    }

    public Task<PossibleContact> ParseContact(string input)
    {
        var genderResult = TryGetGender(input);
        var gender = genderResult.Result;
        input = genderResult.NewString;

        var titleResult = TryGetTitle(input);
        var title = titleResult.Result;
        input = titleResult.NewString;

        /* Nachname + Präfix und Vorname */

        return new PossibleContact()
        {
            Gender = gender == string.Empty ? "D" : gender,
        };
    }

    private ParseResult TryGetTitle(string input)
    {
        var splits = input.Split(' ');
        var results = splits.Where(x => _dataRepository.AllTitles.Select(y => y.ToLower()).Contains(x.ToLower())).ToList();
        return new ParseResult(string.Join(' ', results), string.Join(' ', splits.Except(results)));
    }



    private ParseResult TryGetGender(string input)
    {
        var splits = input.Split(' ');
        string gender = string.Empty;
        if (splits[0].ToLower() == "herr")
        {
            return new ParseResult("M", string.Join(' ', splits.Skip(1)));
        }

        if (splits[0].ToLower() == "frau")
        {
            return new ParseResult("F", string.Join(' ', splits.Skip(1)));
        }

        return new ParseResult(input, gender);

    }


}

public record ParseResult(string NewString, string Result);