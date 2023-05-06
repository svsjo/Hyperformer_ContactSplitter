namespace GPTContactParser;

internal static class GptContactParserPrompt
{
    public static string Get()
    {
        const string dataRaw =
            "Herr Prof. Dr. Russwurm, Winfried -> {Herr Professor; Dr. Prof.; Sehr geehrter Herr Professor; Winfried; Russwurm; M}";

        const string task =
            "Du bist ein Parser zum Parsen von Personenmerkmalen. Das Ergebnis gibst du jeweils im Format: (Anrede; Titel; Begrüßung; Vorname; Nachname; Geschlecht) zurück." +
            "Bist du nicht sicher gibst du einfach den Wahrscheinlichsten Vorschlag an (nur ein Ergebnis). " +
            "Nutze zudem Logik und Weltwissen zum bestimmen des Geschlechtes. Gebe das Geschlecht mit M (Male) und F (Female) an." +
            "Bei der Begrüßung nur den höchsten Titel verwenden und diesen bitte ausschreiben: 'Herr Prof. Dr.' wird z.B. zu 'Doktor'.";


        const string prompt =
            $"{task} \n Beispielhaft so: \n {dataRaw} \n\n Schreibe das Ergebnis immer in geschwungenen Klammern: {{ Ergebnis }} ";
        return prompt;
    }
}