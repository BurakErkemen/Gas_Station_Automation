// Controllers/DashboardController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Gas_station_Automation_MVC.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            var role = User.FindFirstValue(ClaimTypes.Role)?.ToLowerInvariant();

            return role switch
            {
                "admin" => RedirectToAction("Index", "AdminDashboard"),
                "moderator" => RedirectToAction("Index", "ModeratorDashboard"),
                "customer" => RedirectToAction("Index", "CustomerDashboard"),
                _ => RedirectToAction("Login", "Account")
            };
        }
    }
}