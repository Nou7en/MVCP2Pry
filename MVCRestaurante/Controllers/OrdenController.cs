using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCRestaurante.Models;
using MVCRestaurante.Service;
using MVCRestaurante.ViewModels;

namespace MVCRestaurante.Controllers
{
    public class OrdenController : Controller
    {
        private readonly IAPIService _iApiService;
        private OrdenViewModel ordenViewModel = new OrdenViewModel();
        public OrdenController(IAPIService iApiService)
        {
            _iApiService = iApiService;
        }
        
        // GET: OrdenController
        public async Task<ActionResult> Index()
        {

            ordenViewModel.mesas = await _iApiService.ObtenerMesas();
            return View(ordenViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CrearOrden(int IdMesa,int IdUsuario)
        {
            Orden nuevaOrden = new Orden()
            {
                IdMesa = IdMesa,
                Estado = true
            };
            var ordenCreada = await _iApiService.CrearOrden(nuevaOrden);

            ordenViewModel.menu = await _iApiService.ObtenerListaPlatos();
            foreach (var plato in ordenViewModel.menu )
            {
                var platoOrdenado = await _iApiService.CrearPlatoOrden(plato.IdPlato);
                
            }
           
            if (ordenCreada != null)
            {
                return RedirectToAction("Pedido", "Orden");
                ordenViewModel.pedido = await _iApiService.ObtenerPedido(0);
            }
            else
            {
                return View("Index","Mesa");
            }
        }
        /*[HttpPut]
        public async Task<IActionResult> RealizarPedido(int IdPlatoOrdenado, int Cantidad)
        {
            await _iApiService.ActualizarCantidad(IdPlatoOrdenado);
            return View();

        }*/

    }
}
