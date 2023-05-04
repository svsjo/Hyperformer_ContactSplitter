using ContactParser.Contracts;
using ContactParser.Contracts.Data;
using ContactSplitter.DataStorage;
using ContactSplitter.DataStorage.HelperClasses;

namespace ContactParser;

public class DefaultOfflineContactParser : IOfflineContactParser
{
    private readonly DataRepository _dataRepository;

    public DefaultOfflineContactParser(DataRepository dataRepository)
    {
        _dataRepository = dataRepository;
    }

    public async Task<PossibleContact> ParseContact(string input)
    {
        var rawInput = input;

        var genderResult = TryGetGender(input);
        var gender = genderResult.Result;
        input = genderResult.NewString;

        var titleResult = TryGetTitle(input);
        var title = titleResult.Result;
        input = titleResult.NewString;

        var lastNameResult = TryGetLastName(input);
        var lastName = lastNameResult.Result;
        input = lastNameResult.NewString;

        var firstName = input;

        var salutation = GetSalutation(gender, title);
        var letterSalutation = GetLetterSalutation(salutation, gender);

        return new PossibleContact
        {
            Gender = gender,
            FirstName = firstName,
            LastName = lastName,
            Title = title,
            Salutation = salutation,
            LetterSalutation = letterSalutation,
            RawContact = rawInput
        };
    }

    private string GetSalutation(string gender, string title)
    {
        var anrede = gender switch
        {
            "M" => "Herr",
            "F" => "Frau",
            _ => string.Empty,
        };

        if (string.IsNullOrEmpty(title)) return anrede;

        var splits = title.Split(' ').ToList();
        if (!TryFindTitle(splits.First(), out var titleObj)) return anrede;

        if (gender == "F") anrede = anrede + " " + titleObj?.FemaleTitle;
        if (gender == "M") anrede = anrede + " " + titleObj?.MaleTitle;
        else anrede = anrede + " " + titleObj?.GenericTitle;

        return anrede;
    }

    private bool TryFindTitle(string input, out Title? title)
    {
        title = _dataRepository.AllTitles.FirstOrDefault(x => x.Abbreviation == input || x.FemaleTitle == input || x.MaleTitle == input);
        return title != null;
    }

    private string GetLetterSalutation(string salutation, string gender)
    {
        var anrede = gender switch
        {
            "M" => "Sehr geehrter",
            "F" => "Sehr geehrte",
            _ => "Sehr geehrte",
        };


        return anrede + " " + salutation;
    }

    private ParseResult TryGetLastName(string input)
    {
        var splits = input.Split(' ');
        var lastName = splits.Last();
        var prefix = splits.Where(x => _dataRepository.AllPrefixes.Contains(x)).ToList();
        if (!prefix.Any()) return new ParseResult(string.Join(' ', splits.Where(x => x != lastName)), lastName);

        var concatString = prefix.Last() + " " + lastName;
        return input.Contains(concatString) /* Ansonsten unzusammenhängend -> kein echter Prefix */
            ? new ParseResult(string.Join(' ', splits.Where(x => x != lastName)), lastName)
            : new ParseResult(string.Join(' ', splits.Where(x => x != lastName && x != prefix.Last())), lastName);
    }

    private ParseResult TryGetTitle(string input)
    {
        var splits = input.Split(' ');
        var results = splits
            .Where(x => TryFindTitle(x, out var title))
            .ToList();

        results.AddRange(splits.Except(results).Where(x => x.EndsWith('.')));
        return new ParseResult(string.Join(' ', splits.Except(results)), string.Join(' ', results));
        /* Ggf. beachten, dass alle Titel ja zusammenhängend sein müssen -> außerdem letztes Wort != Titel */
    }


    private ParseResult TryGetGender(string input)
    {
        var splits = input.Split(' ');

        return splits[0].ToLower() switch
        {
            "herr" => new ParseResult(string.Join(' ', splits.Skip(1)), "M"),
            "frau" => new ParseResult(string.Join(' ', splits.Skip(1)), "F"),
            _ => new ParseResult(input, "D")
        };
    }
}