using Microsoft.AspNetCore.Mvc;
using RaceDayMVC.Models;
using RaceDayMVC.Services;

namespace RaceDayMVC.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApiService _api;

        public EventsController(ApiService api)
        {
            _api = api;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var events = await _api.GetAsync<List<EventViewModel>>("events");
                return View(events ?? new List<EventViewModel>());
            }
            catch (Exception)
            {
                ViewBag.Error = "Unable to load events. Please make sure the API is running.";
                return View(new List<EventViewModel>());
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var raceEvent = await _api.GetAsync<EventViewModel>($"events/{id}");
                if (raceEvent == null) return NotFound();
                return View(raceEvent);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}