using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace GPTContactParser;

internal static class GptApiClient
{
    public static async Task<string> Request(string input, string prompt)
    {
        const string url = "https://api.openai.com/v1/chat/completions";


        const string apiKeyEncoded = "c2stdkw2STNERVpFd2d1ZUI5ZENKdEpUM0JsYmtGSncxaXRZRVZvQ0hGMmpuaXVHblF2";

        var apiKey = Encoding.UTF8.GetString(Convert.FromBase64String(apiKeyEncoded));

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
        const string pattern = @"\{(.*?)\}";
        var regex = new Regex(pattern);
        if (res == null) return res;
        var s = regex.Match(res).Groups[1].Value;
        return s;

    }
}