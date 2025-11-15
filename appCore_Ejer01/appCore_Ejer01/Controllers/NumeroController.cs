using appCore_Ejer01.Models;
using Microsoft.AspNetCore.Mvc;

namespace appCore_Ejer01.Controllers
{
    public class NumeroController : Controller
    {
        public IActionResult Index()
        {
            return View(new clsNumero());
        }

        [HttpPost]
        public IActionResult Index(clsNumero model)
        {

            // validación básica para números negativos
            if (model.Numero < 0)
            {
                ModelState.AddModelError("Numero", "Por favor, ingrese un número no negativo.");
                return View(model);
            }

            // llama al método para calcular si el número es primo
            model.EsPrimoResultado = clsNumero.EsPrimo(model.Numero);

            // devuelve la vista con el modelo actualizado
            return View(model);
        }

        // ===== Acción para calcular el factorial =====

        public IActionResult CalcularFactorial()
        {
            return View(new clsNumero());
        }

        [HttpPost]
        public IActionResult CalcularFactorial(clsNumero model)
        {
            // validación básica para números negativos
            if (model.Numero < 0)
            {
                ModelState.AddModelError("Numero", "Por favor, ingrese un número no negativo.");
                return View("Factorial", model);
            }
            // llama al método para calcular el factorial
            model.FactorialResultado = clsNumero.CalcularFactorial(model.Numero);

            // devuelve la vista con el modelo actualizado
            return View("ResultadoFactorial", model);
        }
    }
}
