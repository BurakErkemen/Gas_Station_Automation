using Kahramanlar.ServicesLayer;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Kahramanlar.App.Controllers
{
    [ApiController]
    public class CustomBaseController : Controller
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(ServiceResult<T> result)
        {
            if (result.Status == HttpStatusCode.NoContent)
            {
                return new ObjectResult(null) { StatusCode = (int)result.Status };
            }
            return new ObjectResult(result) { StatusCode = (int)result.Status };
        }


        [NonAction]
        public IActionResult CreateActionResult(ServiceResult result)
        {
            if (result.Status == HttpStatusCode.NoContent)
            {
                return new ObjectResult(null) { StatusCode = (int)result.Status };
            }
            return new ObjectResult(result) { StatusCode = (int)result.Status };
        }
    }
}
