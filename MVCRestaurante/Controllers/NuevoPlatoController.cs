using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVCRestaurante.Controllers
{
    public class NuevoPlatoController : Controller
    {
        // GET: NuevoPlatoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: NuevoPlatoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NuevoPlatoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NuevoPlatoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NuevoPlatoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NuevoPlatoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NuevoPlatoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NuevoPlatoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
