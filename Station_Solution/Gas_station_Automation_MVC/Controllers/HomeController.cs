using Microsoft.AspNetCore.Mvc;

namespace Gas_station_Automation_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
