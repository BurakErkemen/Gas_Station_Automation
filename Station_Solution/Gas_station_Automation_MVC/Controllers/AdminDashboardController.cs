using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Gas_station_Automation_MVC.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Admin Paneli";
            ViewData["UserName"] = User.FindFirstValue(ClaimTypes.Name);
            ViewData["UserRole"] = "Admin";
            ViewData["UserEmail"] = User.FindFirstValue(ClaimTypes.Email);
            ViewData["Page"] = "dashboard";

            return View();
        }

        public IActionResult Users()
        {
            ViewData["Title"] = "Kullanıcı Yönetimi";
            ViewData["UserName"] = User.FindFirstValue(ClaimTypes.Name);
            ViewData["UserRole"] = "Admin";
            ViewData["Page"] = "users";

            return View();
        }

        public IActionResult Reports()
        {
            ViewData["Title"] = "Raporlar";
            ViewData["UserName"] = User.FindFirstValue(ClaimTypes.Name);
            ViewData["UserRole"] = "Admin";
            ViewData["Page"] = "reports";

            return View();
        }
    }
}