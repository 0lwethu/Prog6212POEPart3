using Microsoft.AspNetCore.Mvc;

namespace RaceDayMVC.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            // Check whether the user is logged in
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Email = HttpContext.Session.GetString("Email");

            return View();
        }
    }
}