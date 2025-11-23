using Microsoft.AspNetCore.Mvc;

namespace ejerCore_T2_02.Controllers
{
    public class DistritoController : Controller
    {
        private readonly IConfiguration _config;

        public DistritoController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
