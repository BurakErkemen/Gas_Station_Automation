using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Gas_station_Automation_MVC.Controllers
{
    [Authorize(Roles = "moderator")]
    public class ModeratorDashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Moderatör Paneli";
            ViewData["UserName"] = User.FindFirstValue(ClaimTypes.Name);
            ViewData["UserRole"] = "Moderatör";
            ViewData["UserEmail"] = User.FindFirstValue(ClaimTypes.Email);
            ViewData["Page"] = "dashboard";

            return View();
        }

        public IActionResult Shifts()
        {
            ViewData["Title"] = "Vardiya Yönetimi";
            ViewData["UserName"] = User.FindFirstValue(ClaimTypes.Name);
            ViewData["UserRole"] = "Moderatör";
            ViewData["Page"] = "shifts";

            return View();
        }

        public IActionResult Invoices()
        {
            ViewData["Title"] = "Fatura İşlemleri";
            ViewData["UserName"] = User.FindFirstValue(ClaimTypes.Name);
            ViewData["UserRole"] = "Moderatör";
            ViewData["Page"] = "invoices";

            return View();
        }
    }
}