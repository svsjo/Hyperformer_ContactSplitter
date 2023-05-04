using ContactParser.Contracts;

namespace ContactSplitter.Tests;

public class GptParserTest
{
    public GptParserTest(IOnlineContactParser contactParser)
    {
        _contactParser = contactParser;
    }

    private readonly IOnlineContactParser _contactParser;

    /* Input, Anrede, Titel, Briefanrede, Vorname, Nachname, Geschlecht */
    [Theory]
    [InlineData("Frau Sandra Berger", "Frau", "", "Sehr geehrte Frau", "Sandra", "Berger", "F")]
    [InlineData("Herr Dr. Sandro Gutmensch", "Herr Dr.", "Dr.", "Sehr geehrter Herr Dr.", "Sandro", "Gutmensch", "M")]
    [InlineData("Professor Heinreich Freiherr vom Wald", "Herr Professor", "Professor", "Sehr geehrter Herr Professor", "Heinreich", "Freiherr vom Wald", "M")]
    [InlineData("Frau Prof. Dr. rer. nat. Maria von Leuthäuser-Schnarrenberger", "Frau Prof.", "Prof. Dr. rer. nat.", "Sehr geehrte Frau Prof.", "Maria", "von Leuthäuser-Schnarrenberger", "F")]
    [InlineData("Herr Dipl. Ing. Max von Müller", "Herr Dipl. Ing.", "Dipl. Ing.", "Sehr geehrter Herr Dipl. Ing.", "Max", "von Müller", "M")]
    [InlineData("Dr. Russwurm, Winfried", "Herr Dr.", "Dr.", "Sehr geehrter Herr Dr.", "Winfried", "Russwurm", "M")]
    [InlineData("Herr Dr.-Ing. Dr. rer. nat. Dr. h.c. mult. Paul Steffens", "Herr Dr.", "Dr.-Ing. Dr. rer. nat. Dr. h.c. mult.", "Sehr geehrter Herr Dr.", "Paul", "Steffens", "M")]
    [InlineData("Frau Dr. med. Petra Schmitz-Hoffmann", "Frau Dr.", "Dr. med.", "Sehr geehrte Frau Dr.", "Petra", "Schmitz-Hoffmann", "F")]
    [InlineData("Herr Professor Dr. rer. pol. Hans-Joachim Schmidt", "Herr Professor", "Professor Dr. rer. pol.", "Sehr geehrter Herr Professor", "Hans-Joachim", "Schmidt", "M")]
    [InlineData("Frau Dipl.-Ing. Karin Müller-Lüdenscheidt", "Frau Dipl.-Ing.", "Dipl.-Ing.", "Sehr geehrte Frau Dipl.-Ing.", "Karin", "Müller-Lüdenscheidt", "F")]
    [InlineData("Herr Dr. phil. habil. Frank Meier-Becker", "Herr Dr.", "Dr. phil. habil.", "Sehr geehrter Herr Dr.", "Frank", "Meier-Becker", "M")]
    [InlineData("Frau Prof. Dr. rer. nat. habil. Gisela Riedel-Hoffmann", "Frau Prof.", "Prof. Dr. rer. nat. habil.", "Sehr geehrte Frau Prof.", "Gisela", "Riedel-Hoffmann", "F")]
    [InlineData("Herr Dipl.-Kfm. Johannes Maier-Schulze", "Herr Dipl.-Kfm.", "Dipl.-Kfm.", "Sehr geehrter Herr Dipl.-Kfm.", "Johannes", "Maier-Schulze", "M")]
    [InlineData("Dr. rer. nat. Schulz, Ingrid", "Frau Dr.", "Dr. rer. nat.", "Sehr geehrte Frau Dr.", "Ingrid", "Schulz", "F")]
    [InlineData("Herr Dipl.-Ing. Michael Bauer", "Herr Dipl.-Ing.", "Dipl.-Ing.", "Sehr geehrter Herr Dipl.-Ing.", "Michael", "Bauer", "M")]
    [InlineData("Frau Dr. iur. Claudia Schuster-Müller", "Frau Dr.", "Dr. iur.", "Sehr geehrte Frau Dr.", "Claudia", "Schuster-Müller", "F")]
    [InlineData("Herr Dr. rer. nat. habil. Franz Bauer", "Herr Dr.", "Dr. rer. nat. habil.", "Sehr geehrter Herr Dr.", "Franz", "Bauer", "M")]
    [InlineData("Frau Prof. Dr. rer. pol. habil. Anna Schmidt-Weiß", "Frau Prof.", "Prof. Dr. rer. pol. habil.", "Sehr geehrte Frau Prof.", "Anna", "Schmidt-Weiß", "F")]
    public async void GivenInput_ShouldParseContact(string input, string salutation, string title, string letterSalutation, string foreName, string lastName, string gender)
    {
        // Act
        var contact = await _contactParser.ParseContact(input);

        // Assert
        Assert.Equal(salutation, contact.Salutation);
        Assert.Equal(title, contact.Title);
        Assert.Equal(letterSalutation, contact.LetterSalutation);
        Assert.Equal(foreName, contact.FirstName);
        Assert.Equal(lastName, contact.LastName);
        Assert.Equal(gender, contact.Gender);
    }
}