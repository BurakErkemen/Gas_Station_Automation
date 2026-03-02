using Firebase.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebSite.Repository.Layer.ViewModels;
using WebSite.Services.Layer.AuthServices;

namespace WebSite.Controllers;

public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        ViewBag.ReturnUrl = returnUrl;
        return View(new LoginVm());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginVm model, string? returnUrl = null)
    {
        if (!ModelState.IsValid)
            return View(model);

        try
        {
            var token = await _authService.Login(model.Email, model.Password);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, model.Email),
                new Claim(ClaimTypes.Email, model.Email),
                new Claim("FirebaseToken", token)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = model.RememberMe,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties
            );
            // returnUrl varsa ama Home'a dönüyorsa bunu istemiyoruz:
            if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                var ru = returnUrl.ToLowerInvariant();
                var homeLike = ru == "/" || ru.StartsWith("/home", StringComparison.OrdinalIgnoreCase);

                if (!homeLike)
                    return Redirect(returnUrl);
            }

            // yoksa (veya home gibi ise) Dashboard/Index
            return RedirectToAction("Index", "Dashboard");
        }
        catch (FirebaseAuthException ex)
        {
            var message = ex.Reason switch
            {
                AuthErrorReason.WrongPassword => "Girdiğiniz şifre hatalı. 🔑",
                AuthErrorReason.UnknownEmailAddress => "Bu e-posta adresi ile kayıtlı bir kullanıcı bulunamadı. 📧",
                AuthErrorReason.UserDisabled => "Hesabınız askıya alınmış. 🚫",
                _ => $"Giriş hatası: {ex.Reason}. Lütfen tekrar deneyin. ⚠️"
            };

            ModelState.AddModelError(string.Empty, message);
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, "Sistem kaynaklı bir hata oluştu: " + ex.Message);
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
}
