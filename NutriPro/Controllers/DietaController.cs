using Microsoft.AspNetCore.Mvc;
using NutriPro.Models;
using System.Text.Json;

namespace NutriPro.Controllers
{
    public class DietaController : Controller
    {
        private readonly Chat _chatService;

        public DietaController(IConfiguration configuration)
        {
            var apiKey = configuration["OpenAI:ApiKey"];
            _chatService = new Chat(apiKey);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GenerateLimitedDiet([FromBody] JsonElement body)
        {
            try
            {
                // Tenta obter o valor do campo 'prompt'
                if (!body.TryGetProperty("prompt", out JsonElement promptElement) || string.IsNullOrWhiteSpace(promptElement.GetString()))
                {
                    return BadRequest("O prompt não pode estar vazio.");
                }

                string prompt = promptElement.GetString(); // Extrai o valor do prompt como string

                var result = await _chatService.GenerateDietLimitedAsync(prompt);
                return Json(new { success = true, diet = result });
            }
            catch (HttpRequestException ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = $"Erro inesperado: {ex.Message}" });
            }
        }
    }
}
