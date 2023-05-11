#region

using ContactParser;
using ContactParser.Contracts;
using ContactSplitter.DataStorage;

#endregion

namespace ContactSplitter.Tests;

public class DefaultParserTest
{
    private readonly IOfflineContactParser _contactParser;

    public DefaultParserTest()
    {
        _contactParser = new DefaultOfflineContactParser(new DataRepository());
    }

    /* Input, Anrede, Titel, Briefanrede, Vorname, Nachname, Geschlecht */
    [Theory]
    [InlineData("Frau Sandra Berger", "Frau", "", "Sehr geehrte Frau", "Sandra", "Berger", "F")]
    [InlineData("Herr Dr. Sandro Gutmensch", "Herr Doktor", "Dr.", "Sehr geehrter Herr Doktor", "Sandro", "Gutmensch",
        "M")]
    [InlineData("Professor Heinreich Freiherr vom Wald", "Herr Professor", "Professor Freiherr",
        "Sehr geehrter Herr Professor", "Heinreich", "vom Wald", "M")]
    [InlineData("Frau Prof. Dr. rer. nat. Maria von Leuthäuser-Schnarrenberger", "Frau Professorin",
        "Prof. Dr. rer. nat.", "Sehr geehrte Frau Professorin", "Maria", "von Leuthäuser-Schnarrenberger", "F")]
    [InlineData("Herr Dipl.-Ing. Max von Müller", "Herr Diplom-Ingenieur", "Dipl.-Ing.",
        "Sehr geehrter Herr Diplom-Ingenieur", "Max", "von Müller", "M")]
    [InlineData("Dr. Winfried Russwurm", "Doktoren und Doktorinnen", "Dr.", "Sehr geehrte Doktoren und Doktorinnen",
        "Winfried", "Russwurm", "D")]
    [InlineData("Herr Dr.-Ing. Dr. rer. nat. Dr. h.c. mult. Paul Steffens", "Herr Doktor-Ingenieur",
        "Dr.-Ing. Dr. rer. nat. Dr. h.c. mult.", "Sehr geehrter Herr Doktor-Ingenieur", "Paul", "Steffens", "M")]
    [InlineData("Frau Dr. med. Petra Schmitz-Hoffmann", "Frau Doktorin", "Dr. med.", "Sehr geehrte Frau Doktorin",
        "Petra", "Schmitz-Hoffmann", "F")]
    [InlineData("Herr Professor Dr. rer. pol. Hans-Joachim Schmidt", "Herr Professor", "Professor Dr. rer. pol.",
        "Sehr geehrter Herr Professor", "Hans-Joachim", "Schmidt", "M")]
    [InlineData("Frau Dipl.-Ing. Karin Müller-Lüdenscheidt", "Frau Diplom-Ingenieurin", "Dipl.-Ing.",
        "Sehr geehrte Frau Diplom-Ingenieurin", "Karin", "Müller-Lüdenscheidt", "F")]
    [InlineData("Herr Dr. phil. habil. Frank Meier-Becker", "Herr Doktor", "Dr. phil. habil.",
        "Sehr geehrter Herr Doktor", "Frank", "Meier-Becker", "M")]
    [InlineData("Frau Prof. Dr. rer. nat. habil. Gisela Riedel-Hoffmann", "Frau Professorin",
        "Prof. Dr. rer. nat. habil.", "Sehr geehrte Frau Professorin", "Gisela", "Riedel-Hoffmann", "F")]
    [InlineData("Herr Dipl.-Kfm. Johannes Maier-Schulze", "Herr Diplom-Kaufmann", "Dipl.-Kfm.",
        "Sehr geehrter Herr Diplom-Kaufmann", "Johannes", "Maier-Schulze", "M")]
    [InlineData("Dr. rer. nat. Ingrid Schulz", "Doktoren und Doktorinnen", "Dr. rer. nat.",
        "Sehr geehrte Doktoren und Doktorinnen", "Ingrid", "Schulz", "D")]
    [InlineData("Herr Dipl.-Ing. Michael Bauer", "Herr Diplom-Ingenieur", "Dipl.-Ing.",
        "Sehr geehrter Herr Diplom-Ingenieur", "Michael", "Bauer", "M")]
    [InlineData("Frau Dr. iur. Claudia Schuster-Müller", "Frau Doktorin", "Dr. iur.", "Sehr geehrte Frau Doktorin",
        "Claudia", "Schuster-Müller", "F")]
    [InlineData("Herr Dr. rer. nat. habil. Franz Bauer", "Herr Doktor", "Dr. rer. nat. habil.",
        "Sehr geehrter Herr Doktor", "Franz", "Bauer", "M")]
    [InlineData("Frau Prof. Dr. rer. pol. habil. Anna Schmidt-Weiß", "Frau Professorin", "Prof. Dr. rer. pol. habil.",
        "Sehr geehrte Frau Professorin", "Anna", "Schmidt-Weiß", "F")]
    [InlineData("Herr Weis", "Herr", "", "Sehr geehrter Herr", "", "Weis")]
    [InlineData("Prof. Dr. Jonas Noah Weis", "Professoren und Professorinnen", "Prof. Dr.", "Sehr geehrter Professoren und Professorinnen", "Jonas Noah", "Weis", "D")]
    public async void GivenInput_ShouldParseContact(string input, string salutation, string title,
        string letterSalutation, string foreName, string lastName, string gender)
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