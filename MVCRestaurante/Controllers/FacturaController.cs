using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCRestaurante.Models;
using MVCRestaurante.Service;
using MVCRestaurante.ViewModels;

namespace  MVCRestaurante.Controllers
{
    public class FacturaController : Controller
    {
        private readonly IAPIService _iApiService;
        private FacturaViewModel facturaViewModel = new FacturaViewModel();
        // GET: FacturaController
        public FacturaController(IAPIService iApiService)
        {
            _iApiService = iApiService;
        }
        public async Task<IActionResult> Index()
        {
            facturaViewModel.facturas = await _iApiService.ObtenerFacturas();
            return View(facturaViewModel);
        }

        public async Task<IActionResult> Detalles(int IdFactura)
        {
            Factura factura = await _iApiService.ObtenerFactura(IdFactura);
            if (factura != null)
            {
                return View(factura);
            }
            return RedirectToAction("Index");
        }

    }
}
