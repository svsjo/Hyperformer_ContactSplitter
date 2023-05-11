namespace ContactParser;

/// <summary>
/// </summary>
/// <param name="NewString">the remaining string after cutting out the successfully parsed one</param>
/// <param name="Result">the parsed result</param>
public record ParseResult(string NewString, string Result);