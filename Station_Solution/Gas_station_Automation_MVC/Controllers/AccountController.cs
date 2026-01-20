// Controllers/AccountController.cs
using Gas_station_Automation_MVC.Models.ViewModels;
using Gas_station_Automation_MVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gas_station_Automation_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly FirebaseAuthService _authService;

        public AccountController(FirebaseAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            // Zaten giriş yapmışsa yönlendir
            if (User.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var (success, message, user) = await _authService.LoginAsync(vm.Email, vm.Password, vm.RememberMe);

            if (!success)
            {
                ModelState.AddModelError("", message);
                return View(vm);
            }

            // Rolüne göre yönlendir
            return user!.Role.ToLower() switch
            {
                "admin" => RedirectToAction("Index", "AdminDashboard"),
                "moderator" => RedirectToAction("Index", "ModeratorDashboard"),
                "customer" => RedirectToAction("Index", "CustomerDashboard"),
                _ => RedirectToAction("Index", "Dashboard")
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return RedirectToAction("Login");
        }
    }
}