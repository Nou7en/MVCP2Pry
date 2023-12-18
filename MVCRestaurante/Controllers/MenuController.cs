using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCRestaurante.Models;
using MVCRestaurante.Service;
using MVCRestaurante.ViewModels;

namespace MVCRestaurante.Controllers
{
    public class MenuController : Controller
    {
        private readonly IAPIService _iApiService;
        private MenuViewModel menuViewModel = new MenuViewModel();
        public MenuController(IAPIService iApiService)
        {
            _iApiService = iApiService;
        }
        // GET: MenuController
        public async Task<ActionResult> Index()
        {
            menuViewModel.menu = await _iApiService.ObtenerListaPlatos();
            return View(menuViewModel);
        }

        public async Task<IActionResult> EliminarPlato(int IdPlato)
        {
            var eliminado = await _iApiService.EliminarPlato(IdPlato);
            if(eliminado == true)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Editar(int IdPlato)
        {
            menuViewModel.plato = await _iApiService.ObtenerPlato(IdPlato);
            if (menuViewModel.plato != null)
            {
                Plato plato = menuViewModel.plato;
                return View(plato);
            }
            return View("Index");                                                                                                                                                    
        }
        [HttpPost]
        public async Task<IActionResult> Editar(Plato plato, int IdPlato)
        {
            if(plato != null)
            {
                Plato modelo = new Plato
                {
                    DescripcionPlato = plato.DescripcionPlato,
                    NombrePlato = plato.NombrePlato,
                    Precio = plato.Precio
                };
                await _iApiService.EditarPlato(modelo,IdPlato);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Plato plato)
        {
            if (plato != null)
            {
                Plato modelo = new Plato
                {
                    DescripcionPlato = plato.DescripcionPlato,
                    NombrePlato = plato.NombrePlato,
                    Precio = plato.Precio
                };
                await _iApiService.CrearPlato(modelo);
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Detalles(int IdPlato)
        {
            Plato plato = await _iApiService.ObtenerPlato(IdPlato);
            if (plato != null)
            {
                return View(plato);
            }
            return RedirectToAction("Index");
        }
    }
}
