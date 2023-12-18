using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCRestaurante.Models;
using MVCRestaurante.Models.Dto;
using MVCRestaurante.Service;
using MVCRestaurante.ViewModels;

namespace MVCRestaurante.Controllers
{
    public class LogInController : Controller
    {
        private readonly IAPIService _iApiService;
        public LogInController(IAPIService iApiService)
        {
            _iApiService = iApiService;
        }
        // GET: LogInController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(UsuarioCredencial credencial)
        {
            Usuario usuario = await _iApiService.ValidarUsuario(credencial);
            if (usuario != null)
            {
                if (usuario.Rol == "Administrador")
                {
                    return RedirectToAction("Index", "Menu");
                }
                else
                {
                    return View("Index");
                }
                
            }
            ModelState.AddModelError(string.Empty, "Credenciales inválidas. Inténtelo de nuevo.");
            return View("Index");
        }

       

       
    }
}
