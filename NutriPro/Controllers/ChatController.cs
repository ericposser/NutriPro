using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NutriPro.Models;
using System.Text.Json;

namespace NutriPro.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                // Redireciona para uma tela de erro se o parâmetro não estiver presente
                return RedirectToAction("Erro");
            }

            // Caso o parâmetro esteja presente, renderiza a view normalmente
            return View();
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly Chat _chatService;

        public ChatController(IConfiguration configuration)
        {
            var apiKey = configuration["OpenAI:ApiKey"];
            _chatService = new Chat(apiKey);
        }

        [HttpPost]
        public async Task<IActionResult> GenerateDiet([FromBody] JsonElement body)
        {
            try
            {
                // Tenta obter o valor do campo 'prompt'
                if (!body.TryGetProperty("prompt", out JsonElement promptElement) || string.IsNullOrWhiteSpace(promptElement.GetString()))
                {
                    return BadRequest("O prompt não pode estar vazio.");
                }

                string prompt = promptElement.GetString(); // Extrai o valor do prompt como string

                var result = await _chatService.GenerateDietAsync(prompt);
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
