#region

using ContactParser.Contracts;
using ContactParser.Contracts.Data;
using ContactSplitter.DataStorage;
using ContactSplitter.DataStorage.HelperClasses;

#endregion

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

        if (TryActualisateGender(title, out var newGender)) gender = newGender;

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
            "D" => "Damen und Herren",
            _ => string.Empty
        };

        if (string.IsNullOrEmpty(title)) return anrede;

        var splits = title.Split(' ').ToList();
        if (!TryFindTitle(splits.First(), out var titleObj)) return anrede;

        if (gender == "F") anrede = anrede + " " + titleObj!.FemaleTitle;
        else if (gender == "M") anrede = anrede + " " + titleObj!.MaleTitle;
        else anrede = titleObj!.GenericTitle;

        return anrede;
    }

    private bool TryFindTitle(string input, out Title? title)
    {
        title = _dataRepository.AllTitles.FirstOrDefault(x =>
            x.Abbreviation == input || x.FemaleTitle == input || x.MaleTitle == input);
        return title != null;
    }

    private string GetLetterSalutation(string salutation, string gender)
    {
        var anrede = gender switch
        {
            "M" => "Sehr geehrter",
            "F" => "Sehr geehrte",
            _ => "Sehr geehrte"
        };


        return anrede + " " + salutation;
    }

    private ParseResult TryGetLastName(string input)
    {
        var splits = input.Split(' ');
        var lastName = splits.Last();
        var prefix = splits.Where(x => _dataRepository.AllPrefixes.Contains(x)).ToList();

        var result = splits.Reverse().ToList();
        result.Remove(lastName);
        result.Reverse();

        if (!prefix.Any()) return new ParseResult(string.Join(' ', result), lastName);

        var concatString = prefix.Last() + " " + lastName;
        if (input.Contains(concatString))
        {
            result.Reverse();
            result.Remove(prefix.Last());
            result.Reverse();

            return new ParseResult(string.Join(' ', result), concatString);
        }
        else
        {
            return new ParseResult(string.Join(' ', result), lastName);
        }
    }

    private ParseResult TryGetTitle(string input)
    {
        var splits = input.Split(' ');
        if (splits.Length == 1) return new ParseResult(input, string.Empty);

        var results = splits
            .Where(x => TryFindTitle(x, out var title))
            .Distinct()
            .ToList();

        results.AddRange(splits.Except(results).Where(x => x.EndsWith('.')));

        var toIgnore = new List<string>(results);

        var newString = string.Empty;

        foreach (var split in splits)
        {
            if (toIgnore.Contains(split))
            {
                toIgnore.Remove(split);
                continue;
            }

            newString = newString + " " + split;
        }

        return new ParseResult(newString.Trim(), string.Join(' ', results));
        /* Ggf. beachten, dass alle Titel ja zusammenhängend sein müssen -> außerdem letztes Wort != Titel */
    }


    private ParseResult TryGetGender(string input)
    {
        var splits = input.Split(' ');
        if (splits.Length == 1) return new ParseResult(input, string.Empty);

        return splits[0].ToLower() switch
        {
            "herr" => new ParseResult(string.Join(' ', splits.Skip(1)), "M"),
            "frau" => new ParseResult(string.Join(' ', splits.Skip(1)), "F"),
            _ => new ParseResult(input, "D")
        };
    }

    private bool TryActualisateGender(string title, out string gender)
    {
        gender = string.Empty;
        if (!TryFindTitle(title, out var titleObj)) return false;
        if (!titleObj!.TryGetGender(title, out var genderStr)) return false;
        gender = genderStr;
        return true;
    }
}