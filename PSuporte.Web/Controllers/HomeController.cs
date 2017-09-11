using Microsoft.AspNetCore.Mvc;
using PSuporte.Service;

namespace PSuporte.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProcessoSeletivoService _processoSeletivoService;

        public HomeController(ProcessoSeletivoService processoSeletivoService)
        {
            _processoSeletivoService = processoSeletivoService;
        }

        public IActionResult Index()
        {
            var processosSeletivos = _processoSeletivoService.GetProcessosSeletivos();

            return View(processosSeletivos);
        }
    }
}