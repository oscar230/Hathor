using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class TrackRepository : Controller
    {
        // GET: TrackRepository
        public ActionResult Index()
        {
            return View();
        }

        // GET: TrackRepository/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TrackRepository/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrackRepository/Create
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

        // GET: TrackRepository/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TrackRepository/Edit/5
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

        // GET: TrackRepository/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TrackRepository/Delete/5
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
