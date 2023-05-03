using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using ContactParser.Contracts;
using ContactParser.Contracts.Data;

namespace GPTContactParser
{
    public class GptOnlineContactParser:IOnlineContactParser
    {
        public async Task<PossibleContact> ParseContact(string input)
        {
            //const string Input = "Dr. Phil. Antonius Van Hoof";
            var res = await Parse(input);
            var resParts = res.Split(";");
            return new PossibleContact()
            {
                Title = new ContactFieldWrapper()
                {
                    ParsedText = resParts[1]
                },
                Salutation = new ContactFieldWrapper()
                {
                    ParsedText = resParts[0]
                },
                LetterSalutation = new ContactFieldWrapper()
                {
                    ParsedText = resParts[2]
                },
                ForeName = new ContactFieldWrapper()
                {
                    ParsedText = resParts[3]
                },
                Gender = new ContactFieldWrapper()
                {
                    ParsedText = resParts[5]
                },
                LastName = new ContactFieldWrapper()
                {
                    ParsedText = resParts[4]
                }
            };
        }

        private static async Task<string> Parse(string input)
        {
            const string url = "https://api.openai.com/v1/chat/completions";

            const string apiKey = "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";

            const string dataRaw = "Dr. Russwurm, Winfried -> (Herr Dr.; Dr.; Sehr geehrter Herr Dr.; Winfried; Russwurm; M)";


            const string task =
                "Du bist ein Parser zum Parsen von Personenmerkmalen. Das Ergebnis gibst du jeweils im Format: (Anrede; Titel; Begrüßung; Vorname; Nachname; Geschlecht)  zurück. Bist du nicht sicher gibst du einfach den Wahrscheinlichsten Vorschlag an (nur ein Ergebnis). Nutzte zudem Logik und Weltwissen zum bestimmen des Geschlechtes";


            var prompt =
                $"{task} \n Beispielhaft so: \n {dataRaw} \n\n Schreibe das Ergebnis immer in geschwungenen Klammern: {{result}} Eingabe: {input}";

            var data = new
            {
                model = "gpt-3.5-turbo",
                // max_tokens = 10,
                messages = new[]
                {
                    new
                    {
                        content = prompt,
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
}