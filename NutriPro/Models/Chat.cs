using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NutriPro.Models
{
    public class Chat
    {
        private readonly string _apiKey;

        // Construtor para injetar a API Key
        public Chat(string apiKey)
        {
            _apiKey = apiKey;
        }

        // Método para gerar texto com a OpenAI API
        public async Task<string> GenerateDietAsync(string prompt)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

            var requestBody = new
            {
                model = "gpt-4", // Altere para um modelo atual
                messages = new[]
                {
            new { role = "system", content = "Você é um profissional da saúde que cria dietas personalizadas. Se perguntarem alguma coisa que não seja relacionada a dieta e saúde não responda e explique o porque" },
            new { role = "user", content = prompt }
        },
                max_tokens = 500, // Controle do tamanho da resposta
                temperature = 0.7
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://api.openai.com/v1/chat/completions", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<JsonElement>(responseBody);
                return result.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString().Trim();
            }
            else
            {
                throw new HttpRequestException($"Erro: {response.StatusCode}, {await response.Content.ReadAsStringAsync()}");
            }
        }

        // Método para gerar texto com no máximo 8 linhas
        public async Task<string> GenerateDietLimitedAsync(string prompt)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

            var requestBody = new
            {
                model = "gpt-4",
                messages = new[]
                {
                new { role = "system", content = "Você é um profissional da saúde que cria dietas personalizadas. Se perguntarem alguma coisa que não seja relacionada a dieta e saúde não responda e explique o porque" },
                new { role = "user", content = prompt }
            },
                max_tokens = 200, // Reduzido para limitar a resposta
                temperature = 0.7
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://api.openai.com/v1/chat/completions", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<JsonElement>(responseBody);
                return result.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString().Trim();
            }
            else
            {
                throw new HttpRequestException($"Erro: {response.StatusCode}, {await response.Content.ReadAsStringAsync()}");
            }
        }

    }
}
