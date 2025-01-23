using Microsoft.AspNetCore.Mvc;

namespace NutriPro.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class TermosController : Controller
    {
        // Método para a página Termos de Uso
        [HttpGet("termos-de-uso")]
        public IActionResult TermosDeUso()
        {
            return View("TermosDeUso");
        }

        // Método para a página Política de Privacidade
        [HttpGet("termos-de-privacidade")]
        public IActionResult TermosDePrivacidade()
        {
            return View("TermosDePrivacidade");
        }
    }

}
