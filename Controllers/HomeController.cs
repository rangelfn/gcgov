using GCGov.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GCGov.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacidade()
        {
            return View();
        }

        public IActionResult Aditivos()
        {
            return RedirectToAction("Index", "Aditivos");
        }

        public IActionResult Apostilamentos()
        {
            return RedirectToAction("Index", "Apostilamentos");
        }

        public IActionResult Contratos()
        {
            return RedirectToAction("Index", "Contratos");
        }

        public IActionResult Editais()
        {
            return RedirectToAction("Index", "Editais");
        }

        public IActionResult NaturezasDespesas()
        {
            return RedirectToAction("Index", "NaturezasDespesas");
        }
        public IActionResult Pagamentos()
        {
            return RedirectToAction("Index", "Pagamentos");
        }

        public IActionResult PgtosOrigens()
        {
            return RedirectToAction("Index", "PgtosOrigens");
        }

        public IActionResult Servidores()
        {
            return RedirectToAction("Index", "Servidores");
        }

        public IActionResult PessoasPortarias()
        {
            return RedirectToAction("Index", "PortariasServidores");
        }

        public IActionResult Portarias()
        {
            return RedirectToAction("Index", "Portarias");
        }

        public IActionResult UsuariosContratos()
        {
            return RedirectToAction("Index", "UsuariosContratos");
        }

        public IActionResult Usuarios()
        {
            return RedirectToAction("Index", "Usuarios");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}