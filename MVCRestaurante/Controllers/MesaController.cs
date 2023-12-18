using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVCRestaurante.Controllers
{
    public class MesaController : Controller
    {
        // GET: MesaController
        public ActionResult Index()
        {
            return View();
        }

       
    }
}
