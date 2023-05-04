using ContactParser;
using ContactParser.Contracts;
using ContactSplitter.DataStorage;
using GPTContactParser;

namespace ContactSplitter.Tests;

public class GptParserTest
{
    public GptParserTest()
    {
        _contactParser = new GptOnlineContactParser();
    }

    private readonly IOnlineContactParser _contactParser;

    /* Input, Anrede, Titel, Briefanrede, Vorname, Nachname, Geschlecht */
    [Theory]
    [InlineData("Frau Sandra Berger", "Frau", "", "Sehr geehrte Frau", "Sandra", "Berger", "F")]
    [InlineData("Herr Dr. Sandro Gutmensch", "Herr Doktor", "Dr.", "Sehr geehrter Herr Doktor", "Sandro", "Gutmensch", "M")]
    [InlineData("Professor Heinreich Freiherr vom Wald", "Herr Professor", "Professor", "Sehr geehrter Herr Professor", "Heinreich", "Freiherr vom Wald", "M")]
    [InlineData("Frau Prof. Dr. rer. nat. Maria von Leuthäuser-Schnarrenberger", "Frau Professor", "Prof. Dr. rer. nat.", "Sehr geehrte Frau Professor", "Maria", "von Leuthäuser-Schnarrenberger", "F")]
    [InlineData("Herr Dipl.-Ing. Max von Müller", "Herr Diplom-Ingenieur.", "Dipl.-Ing.", "Sehr geehrter Herr Diplom-Ingenieur.", "Max", "von Müller", "M")]
    [InlineData("Dr. Russwurm, Winfried", "Herr Doktor", "Dr.", "Sehr geehrter Herr Doktor", "Winfried", "Russwurm", "M")]
    [InlineData("Herr Dr.-Ing. Dr. rer. nat. Dr. h.c. mult. Paul Steffens", "Herr Doktor-Ingenieur", "Dr.-Ing. Dr. rer. nat. Dr. h.c. mult.", "Sehr geehrter Herr Doktor-Ingenieur", "Paul", "Steffens", "M")]
    [InlineData("Frau Dr. med. Petra Schmitz-Hoffmann", "Frau Doktor", "Dr. med.", "Sehr geehrte Frau Doktor", "Petra", "Schmitz-Hoffmann", "F")]
    [InlineData("Herr Professor Dr. rer. pol. Hans-Joachim Schmidt", "Herr Professor", "Professor Dr. rer. pol.", "Sehr geehrter Herr Professor", "Hans-Joachim", "Schmidt", "M")]
    [InlineData("Frau Dipl.-Ing. Karin Müller-Lüdenscheidt", "Frau Diplom-Ingenieur", "Dipl.-Ing.", "Sehr geehrte Frau Diplom-Ingenieur", "Karin", "Müller-Lüdenscheidt", "F")]
    [InlineData("Herr Dr. phil. habil. Frank Meier-Becker", "Herr Doktor", "Dr. phil. habil.", "Sehr geehrter Herr Doktor", "Frank", "Meier-Becker", "M")]
    [InlineData("Frau Prof. Dr. rer. nat. habil. Gisela Riedel-Hoffmann", "Frau Professor", "Prof. Dr. rer. nat. habil.", "Sehr geehrte Frau Professor", "Gisela", "Riedel-Hoffmann", "F")]
    [InlineData("Herr Dipl.-Kfm. Johannes Maier-Schulze", "Herr Diplom-Kaufmann", "Dipl.-Kfm.", "Sehr geehrter Herr Diplom-Kaufmann.", "Johannes", "Maier-Schulze", "M")]
    [InlineData("Dr. rer. nat. Schulz, Ingrid", "Frau Doktor", "Dr. rer. nat.", "Sehr geehrte Frau Doktor", "Ingrid", "Schulz", "F")]
    [InlineData("Herr Dipl.-Ing. Michael Bauer", "Herr Diplom-Ingenieur", "Dipl.-Ing.", "Sehr geehrter Herr Diplom-Ingenieur", "Michael", "Bauer", "M")]
    [InlineData("Frau Dr. iur. Claudia Schuster-Müller", "Frau Doktor", "Dr. iur.", "Sehr geehrte Frau Doktor", "Claudia", "Schuster-Müller", "F")]
    [InlineData("Herr Dr. rer. nat. habil. Franz Bauer", "Herr Doktor", "Dr. rer. nat. habil.", "Sehr geehrter Herr Doktor", "Franz", "Bauer", "M")]
    [InlineData("Frau Prof. Dr. rer. pol. habil. Anna Schmidt-Weiß", "Frau Professor", "Prof. Dr. rer. pol. habil.", "Sehr geehrte Frau Professor", "Anna", "Schmidt-Weiß", "F")]
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