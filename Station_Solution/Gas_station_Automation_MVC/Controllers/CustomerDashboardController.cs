using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Gas_station_Automation_MVC.Controllers
{
    [Authorize(Roles = "customer")]
    public class CustomerDashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Müşteri Paneli";
            ViewData["UserName"] = User.FindFirstValue(ClaimTypes.Name);
            ViewData["UserRole"] = "Müşteri";
            ViewData["UserEmail"] = User.FindFirstValue(ClaimTypes.Email);
            ViewData["Page"] = "dashboard";

            return View();
        }

        public IActionResult MyDebts()
        {
            ViewData["Title"] = "Borçlarım";
            ViewData["UserName"] = User.FindFirstValue(ClaimTypes.Name);
            ViewData["UserRole"] = "Müşteri";
            ViewData["Page"] = "debts";

            return View();
        }

        public IActionResult Transactions()
        {
            ViewData["Title"] = "İşlem Geçmişi";
            ViewData["UserName"] = User.FindFirstValue(ClaimTypes.Name);
            ViewData["UserRole"] = "Müşteri";
            ViewData["Page"] = "transactions";

            return View();
        }

        public IActionResult Payments()
        {
            ViewData["Title"] = "Ödemelerim";
            ViewData["UserName"] = User.FindFirstValue(ClaimTypes.Name);
            ViewData["UserRole"] = "Müşteri";
            ViewData["Page"] = "payments";

            return View();
        }
    }
}