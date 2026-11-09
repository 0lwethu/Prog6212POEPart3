using Microsoft.AspNetCore.Mvc;
using RaceDayMVC.Filters;
using RaceDayMVC.Models;
using RaceDayMVC.Services;

namespace RaceDayMVC.Controllers
{
    [AuthorizeRole("Organiser", "Admin")]
    public class OrganiserController : Controller
    {
        private readonly ApiService _apiService;

        public OrganiserController(ApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return RedirectToAction(nameof(Dashboard));
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            var events = await _apiService.GetAsync<List<EventViewModel>>("api/organiser/events");
            return View(events ?? new List<EventViewModel>());
        }

        [HttpGet]
        public IActionResult CreateEvent()
        {
            return View(new CreateEventViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEvent(CreateEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var success = await _apiService.PostAsync("api/organiser/events", model);
            if (!success)
            {
                ModelState.AddModelError(string.Empty, "Unable to create event. Please ensure backend API is running.");
                return View(model);
            }

            return RedirectToAction(nameof(Dashboard));
        }
    }
}