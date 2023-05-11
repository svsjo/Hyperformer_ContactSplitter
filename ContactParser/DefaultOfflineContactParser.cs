#region

using ContactParser.Contracts;
using ContactSplitter.DataStorage;
using ContactSplitter.DataStorage.Contracts;
using ContactSplitter.DataStorage.Contracts.HelperClasses;

#endregion

namespace ContactParser;

public class DefaultOfflineContactParser : IOfflineContactParser
{
    private readonly IDataRepository _dataRepository;

    public DefaultOfflineContactParser(IDataRepository dataRepository)
    {
        _dataRepository = dataRepository;
    }

    public Task<PossibleContact> ParseContact(string input)
    {
        var rawInput = input;

        var genderResult = TryGetGender(input);
        var gender = genderResult.Result;
        input = genderResult.NewString;

        var titleResult = TryGetTitle(input);
        var title = titleResult.Result;
        input = titleResult.NewString;

        if (TryUpdateGender(title, out var newGender)) gender = newGender;

        var lastNameResult = TryGetLastName(input);
        var lastName = lastNameResult.Result;
        input = lastNameResult.NewString;

        var firstName = input;

        var salutation = GetSalutation(gender, title);
        var letterSalutation = GetLetterSalutation(salutation, gender);

        return Task.FromResult(new PossibleContact
        {
            Gender = gender,
            FirstName = firstName,
            LastName = lastName,
            Title = title,
            Salutation = salutation,
            LetterSalutation = letterSalutation,
            RawContact = rawInput
        });
    }

    /// <summary>
    /// Takes Gender and Title and generates the Salutation from them
    /// </summary>
    /// <param name="gender">Already parsed Gender</param>
    /// <param name="title">Already parsed Title</param>
    /// <returns></returns>
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

        return gender switch
        {
            "F" => anrede + " " + titleObj!.FemaleTitle,
            "M" => anrede + " " + titleObj!.MaleTitle,
            _ => titleObj!.GenericTitle
        };
    }

    /// <summary>
    /// Checks if the input is a title (independent from its form: male, female, abbreviation) and returns its object
    /// </summary>
    /// <param name="input"></param>
    /// <param name="title"></param>
    /// <returns></returns>
    private bool TryFindTitle(string input, out Title? title)
    {
        title = _dataRepository.AllTitles.FirstOrDefault(x =>
            x.Abbreviation == input || x.FemaleTitle == input || x.MaleTitle == input);
        return title != null;
    }

    /// <summary>
    /// Takes Salutation and Gender and generates the formal letter Salutation
    /// </summary>
    /// <param name="salutation"></param>
    /// <param name="gender"></param>
    /// <returns></returns>
    private string GetLetterSalutation(string salutation, string gender)
    {
        var genericSalutation = gender switch
        {
            "M" => "Sehr geehrter",
            "F" => "Sehr geehrte",
            _ => "Sehr geehrte"
        };

        return genericSalutation + " " + salutation;
    }

    /// <summary>
    /// Takes the remaining string as input und extracts the Lastname
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Takes the remaining string as input and tries to match its words to known titles
    /// Extracts (possibly multiple) titles
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    private ParseResult TryGetTitle(string input)
    {
        var splits = input.Split(' ');
        if (splits.Length == 1) return new ParseResult(input, string.Empty);

        var results = splits
            .Where(x => TryFindTitle(x, out _))
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
    }

    /// <summary>
    /// Takes the input und tries to evaluate the Gender from it
    /// Same is done after extracting the title to verify/update the Gender
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    private static ParseResult TryGetGender(string input)
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

    /// <summary>
    /// Takes the title and checks if it is stricty male or female. Then it returns the gender if found
    /// </summary>
    /// <param name="titleString"></param>
    /// <param name="gender"></param>
    /// <returns></returns>
    private bool TryUpdateGender(string titleString, out string gender)
    {
        gender = string.Empty;
        var splits = titleString.Split(' ').ToList();
        foreach (var title in splits)
        {
            if (!TryFindTitle(title, out var titleObj)) continue;
            if (!titleObj!.TryGetGender(title, out var genderStr)) continue;
            gender = genderStr;
            return true;
        }

        return false;
    }
}