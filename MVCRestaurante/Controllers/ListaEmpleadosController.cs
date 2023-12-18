using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCRestaurante.Models;
using MVCRestaurante.Service;
using MVCRestaurante.ViewModels;

namespace MVCRestaurante.Controllers
{
    public class ListaEmpleadosController : Controller
    {
        private readonly IAPIService _iApiService;
        private ListaEmpleadosViewModel listaEViewModel = new ListaEmpleadosViewModel();
        public ListaEmpleadosController(IAPIService iApiService)
        {
            _iApiService = iApiService;
        }
        // GET: ListaEmpleadosController
        public async Task<ActionResult> IndexAsync()
        {
            listaEViewModel.empleados = await _iApiService.ObtenerListaEmpleados();
            return View(listaEViewModel);
        }

        public async Task<IActionResult> EliminarEmpleado(int IdUsuario)
        {
            var eliminado = await _iApiService.EliminarUsuario(IdUsuario);
            if (eliminado == true)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Usuario nEmpleado)
        {
            if (nEmpleado != null)
            {
                Usuario modelo = new Usuario
                {
                    Nombre = nEmpleado.Nombre,
                    Apellido = nEmpleado.Apellido,
                    NombreUsuario = nEmpleado.NombreUsuario,
                    Clave = nEmpleado.Clave,
                    Rol = nEmpleado.Rol,

                };
                await _iApiService.RegistrarEmpleado(nEmpleado);
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
