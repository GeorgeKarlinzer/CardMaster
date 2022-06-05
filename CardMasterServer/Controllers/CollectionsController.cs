using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardMaster.Server.Controllers
{
    public class CollectionsController : Controller
    {
        private CardMasterContext context;

        private int UserId => int.Parse(HttpContext.User.Claims.First().Value);

        public CollectionsController(CardMasterContext context)
        {
            this.context = context;
        }

        // GET: CollectionsController
        [Authorize]
        public ActionResult Index()
        {
            var collections = context.CardCollections.Where(x => x.Id_User == UserId);

            return View(collections);
        }

        // GET: CollectionsController/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CollectionsController/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CollectionsController/Create
        [Authorize]
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
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CollectionsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
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
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CollectionsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
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
