#region

using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using ContactParser.Contracts;
using ContactParser.Contracts.Data;

#endregion

namespace GPTContactParser;

public class GptOnlineContactParser : IOnlineContactParser
{
    public async Task<PossibleContact> ParseContact(string input)
    {
        var res = await Parse(input);
        var resParts = res.Split(";");
        if (resParts.Length < 6) return new PossibleContact();

        return new PossibleContact
        {
            Title = resParts[1],
            Salutation = resParts[0],
            LetterSalutation = resParts[2],
            FirstName = resParts[3],
            Gender = resParts[5],
            LastName = resParts[4]
        };
    }

    private static async Task<string> Parse(string input)
    {
        const string url = "https://api.openai.com/v1/chat/completions";


        var apiKeyEncoded = "c2stdkw2STNERVpFd2d1ZUI5ZENKdEpUM0JsYmtGSncxaXRZRVZvQ0hGMmpuaXVHblF2";

        var apiKey = Encoding.UTF8.GetString(Convert.FromBase64String(apiKeyEncoded));



        const string dataRaw = "Dr. Russwurm, Winfried -> {Herr Dr.; Dr.; Sehr geehrter Herr Doktor; Winfried; Russwurm; M}";


            const string task = "Du bist ein Parser zum Parsen von Personenmerkmalen. Das Ergebnis gibst du jeweils im Format: (Anrede; Titel; Begrüßung; Vorname; Nachname; Geschlecht)  zurück. Bist du nicht sicher gibst du einfach den Wahrscheinlichsten Vorschlag an (nur ein Ergebnis). Nutze zudem Logik und Weltwissen zum bestimmen des Geschlechtes. Bei der Begrüßung den Titel bitte ausschreiben: Dr. wird z.B. zu Doktor";


            var prompt =
                $"{task} \n Beispielhaft so: \n {dataRaw} \n\n Schreibe das Ergebnis immer in geschwungenen Klammern: {{ Ergebnis }} ";

            var data = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new
                    {
                        content = prompt,
                        role = "system"
                    },
                    new
                    {
                        content = $"Eingabe: {input}",
                        role = "user"
                    }
                }
            };

        var json = JsonSerializer.Serialize(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        var response = await client.PostAsync(url, content);

        var result = await response.Content.ReadAsStringAsync();

        var jsonDocument = JsonDocument.Parse(result);
        var res = jsonDocument.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content")
            .GetString();
        var pattern = @"\{(.*?)\}";
        var regex = new Regex(pattern);
        var s = regex.Match(res).Groups[1].Value;
        return s;
    }
}