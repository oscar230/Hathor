using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    public class TrackRepository : Controller
    {
        private readonly ILogger<TrackRepository> _logger;
        private readonly List<ITrackProvider> _trackProviders;

        public TrackRepository(ILogger<TrackRepository> logger, SliderTrackProviderService sliderTrackProviderService, BtdigTrackProviderService btdigTrackProviderService)
        {
            _logger = logger;
            _trackProviders = new List<ITrackProvider>
            {
                btdigTrackProviderService,
                sliderTrackProviderService
            };
        }

        public ActionResult<List<Track>> Index(string? query = null)
        {
            return TrackProvidersHelper.Index(_trackProviders, query);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

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

        public ActionResult Edit(int id)
        {
            return View();
        }

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

        public ActionResult Delete(int id)
        {
            return View();
        }

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
