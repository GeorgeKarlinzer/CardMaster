using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardMaster.Server.Controllers
{
    public class CollectionsController : Controller
    {
        // GET: CollectionsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CollectionsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CollectionsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CollectionsController/Create
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

        // GET: CollectionsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CollectionsController/Edit/5
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

        // GET: CollectionsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CollectionsController/Delete/5
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
