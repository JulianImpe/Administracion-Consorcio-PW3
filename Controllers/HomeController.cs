using Administracion_Consorcio_PW3.Models;
using Administracion_Consorcio_PW3.Models.ViewModels; // Importamos los ViewModels
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
        public IActionResult Registrar(RegistrarViewModel model)
        {
            // Ahora el ModelState evaluará las anotaciones de RegistrarViewModel (incluyendo PasswordValidacion)
            if (!ModelState.IsValid)
            {
                // Si hay errores, devolvemos la misma vista con el modelo para que se muestren los mensajes
                return View(model);
            }

            // Si es válido, usamos los datos del modelo para el servicio
            var resultado = _usuarioService.Registrar(model.Email, model.Password);

            // Guardamos el mensaje en TempData para que persista tras la redirección
            TempData["Success"] = "¡Registro exitoso! Ya podés iniciar sesión.";

            return RedirectToAction("Ingresar");
        }

        [HttpPost]
        public IActionResult Ingresar(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var usuarios = _usuarioService.Login(model.Email, model.Password);

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
