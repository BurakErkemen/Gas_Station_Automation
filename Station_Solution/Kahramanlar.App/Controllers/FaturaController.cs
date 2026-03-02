using Kahramanlar.ServicesLayer.Services.Fatura;
using Microsoft.AspNetCore.Mvc;

namespace Kahramanlar.App.Controllers
{
    public class FaturaController : CustomBaseController
    {
        private readonly IFaturaService _faturaService;

        public FaturaController(IFaturaService faturaService)
        {
            _faturaService = faturaService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
