using ContactParser;
using ContactParser.Contracts;
using ContactParser.Contracts.Data;

namespace ContactSplitter.Tests;

public class FullParserTest
{
    private readonly IContactParser _contactParser = new DefaultContactParser();

    [Theory]
    [InlineData("Frau Sandra Berger", "Frau", "", "", "Sandra", "Berger", "F")]
    [InlineData("Herr Dr. Sandro Gutmensch", "Herr", "Dr.", "", "Sandro", "Gutmensch", "M")]
    [InlineData("Professor Heinreich Freiherr vom Wald", "", "Professor", "", "Heinreich", "Freiherr vom Wald", "M")]
    [InlineData("Mrs. Doreen Faber", "", "", "Mrs.", "Doreen", "Faber", "F")]
    [InlineData("Mme. Charlotte Noir", "", "", "Mme.", "Charlotte", "Noir", "F")]
    [InlineData("Estobar y Gonzales", "", "", "", "Estobar", "Gonzales", "M")]
    [InlineData("Frau Prof. Dr. rer. nat. Maria von Leuthäuser-Schnarrenberger", "Frau", "Prof. Dr. rer. nat.", "", "Maria", "von Leuthäuser-Schnarrenberger", "F")]
    [InlineData("Herr Dipl. Ing. Max von Müller", "Herr", "Dipl. Ing.", "", "Max", "von Müller", "M")]
    [InlineData("Dr. Russwurm, Winfried", "", "Dr.", "", "Winfried", "Russwurm", "M")]
    [InlineData("Herr Dr.-Ing. Dr. rer. nat. Dr. h.c. mult. Paul Steffens", "Herr", "Dr.-Ing. Dr. rer. nat. Dr. h.c. mult.", "", "Paul", "Steffens", "M")]
    public void GivenInput_ShouldParseContact(string input, string salutation, string title, string letterSalutation, string foreName, string lastName, string gender)
    {
        // Act
        var contact = _contactParser.ParseContact(input);

        // Assert
        Assert.Equal(salutation, contact.Salutation.ParsedText);
        Assert.Equal(title, contact.Title.ParsedText);
        Assert.Equal(letterSalutation, contact.LetterSalutation.ParsedText);
        Assert.Equal(foreName, contact.ForeName.ParsedText);
        Assert.Equal(lastName, contact.LastName.ParsedText);
        Assert.Equal(gender, contact.Gender.ParsedText);
    }
}