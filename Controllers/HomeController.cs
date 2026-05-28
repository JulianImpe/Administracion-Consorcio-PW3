using Administracion_Consorcio_PW3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Administracion_Consorcio_PW3.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public HomeController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ingresar()
        {
            return View();
        }

        public IActionResult Registrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registrar(string email, string password)
        {
            var resultado = _usuarioService.Registrar(email, password);

            if (!resultado)
            {
                ViewBag.Error = "Email ya existente";
                return View();
            }

            return RedirectToAction("Ingresar");
        }

        [HttpPost]
        public IActionResult Ingresar(string email, string password)
        {
            var usuarios = _usuarioService.Login(email, password);

            if (usuarios == null)
            {
                ViewBag.Error = "Credenciales invalidas";
                return View();
            }

            HttpContext.Session.SetInt32("IdUsuario", usuarios.IdUsuario);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
