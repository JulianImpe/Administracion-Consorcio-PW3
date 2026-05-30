using Administracion_Consorcio_PW3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Administracion_Consorcio_PW3.Controllers
{
    public class UnidadController : Controller
    {
        private readonly IUnidadService _unidadService;

        public UnidadController(IUnidadService unidadService)
        {
            _unidadService = unidadService;
        }
        public IActionResult VerUnidades()
        { 
            var unidades = _unidadService.ObtenerUnidades();
            return View(unidades);
        }

        [HttpGet]
        public IActionResult EditarUnidad(int Id)
        {
            var unidad = _unidadService.ObtenerUnidades().FirstOrDefault(u => u.IdUnidad == Id);
            return View(unidad);
        }

        [HttpPost]
        public IActionResult EditarUnidad(int Id, Models.Entidades.Unidad unidad)
        {
            _unidadService.EditarUnidad(Id, unidad);
            return RedirectToAction("VerUnidades");
        }

        [HttpGet]
        public IActionResult EliminarUnidad(int Id) 
        {
            var unidad = _unidadService.ObtenerUnidades().FirstOrDefault(u => u.IdUnidad == Id);
            return View(unidad);
        }

        [HttpPost]
        public IActionResult Eliminar(int IdUnidad)
        { 
            _unidadService.EliminarUnidad(IdUnidad);
            return RedirectToAction("VerUnidades");
        }

    }
}
