using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCRestaurante.Models;
using MVCRestaurante.Service;

namespace MVCRestaurante.Controllers
{
    public class NuevoEmpleadoController : Controller
    {
        private readonly IAPIService _iApiService;
        public NuevoEmpleadoController(IAPIService iApiService)
        {
            _iApiService = iApiService;
        }
        // GET: NuevoEmpleadoController
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CrearEmpleado(Usuario nEmpleado)
        {
            var empleado = await _iApiService.RegistrarEmpleado(nEmpleado);
            if (empleado == null)
            {
                return RedirectToAction("Index","NuevoEmpleado");
            }
            return RedirectToAction("Index", "ListaEmpleados");
        }
        
    }
}
