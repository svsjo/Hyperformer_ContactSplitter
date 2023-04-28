using System.ComponentModel.DataAnnotations;

namespace ContactParser.Contracts.Data;

public class ContactFieldWrapper
{
    public string ParsedText { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;

    [Range(0, 100)]
    public int Probability { get; set; } = 100;
}