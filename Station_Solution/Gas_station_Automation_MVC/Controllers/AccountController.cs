using Microsoft.AspNetCore.Mvc;

namespace Gas_station_Automation_MVC.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password,bool rememberMe)
        {
            if(username != "test")
            {
                ViewBag.Error = "Kullanıcı adı ve şifre zorunludur.";
                return View();
            }

            // Demo doğrulama (örnek): şifre "1234" ise kabul et
            if (password != "1234")
            {
                ViewBag.Error = "Hatalı kullanıcı adı veya şifre.";
                return View();
            }
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
