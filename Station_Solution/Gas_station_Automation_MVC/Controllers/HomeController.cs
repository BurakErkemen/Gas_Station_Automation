using Microsoft.AspNetCore.Mvc;

namespace Gas_station_Automation_MVC.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
