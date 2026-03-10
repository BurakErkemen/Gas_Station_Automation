using Kahramanlar.ServicesLayer.Services.Fatura;
using Kahramanlar.ServicesLayer.Services.Fatura.Create;
using Kahramanlar.ServicesLayer.Services.Fatura.Update;
using Microsoft.AspNetCore.Mvc;

namespace Kahramanlar.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaturaController(IFaturaService faturaService) : CustomBaseController
    {
        [HttpPost("create")]
        public async Task<IActionResult> CreateFatura(CreateFaturaRequest request)
        {
            var faturaResult = await faturaService.CreateFaturaAsync(request);

            return CreateActionResult(faturaResult);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteFatura(string id)
        {
            var deleteResult = await faturaService.DeleteFatura(id);

            return CreateActionResult(deleteResult);
        }

        [HttpPatch("update")]
        public async Task<IActionResult> UpdateFatura(UpdateFaturaRequest request)
        {
            var updateResult = await faturaService.UpdateFatura(request);

            return CreateActionResult(updateResult);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllFaturalar()
        {
            var getAllResult = await faturaService.GetAllFaturalarAsync();
            return CreateActionResult(getAllResult);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetByFaturaId(string id)
        {
            var getByIdResult = await faturaService.GetByFaturaId(id);
            return CreateActionResult(getByIdResult);
        }

        [HttpGet("TarihSıralaması")]
        public async Task<IActionResult> GetFaturalarByDateRange(DateTime startDate, DateTime endDate)
        {
            var result = await faturaService.GetFaturalarByDateRange(startDate, endDate);
            return CreateActionResult(result);
        }

        [HttpGet("FisNoSıralaması")]
        public async Task<IActionResult> GetFaturaByFisNo(int fisNo)
        {
            var result = await faturaService.GetFaturaByFisNo(fisNo);
            return CreateActionResult(result);
        }

        [HttpGet("TuruSıralaması")]
        public async Task<IActionResult> GetFaturalarByTuru(string turu)
        {
            var result = await faturaService.GetFaturalarByTuru(turu);
            return CreateActionResult(result);
        }

        [HttpGet("TutarAralığıSıralaması")]
        public async Task<IActionResult> GetFaturalarByTutarRange(double minTutar, double maxTutar)
        {
            var result = await faturaService.GetFaturalarByTutarRange(minTutar, maxTutar);
            return CreateActionResult(result);
        }

        [HttpGet("LtAralığıSıralaması")]
        public async Task<IActionResult> GetFaturalarByLtRange(double minLt, double maxLt)
        {
            var result = await faturaService.GetFaturalarByLtRange(minLt, maxLt);
            return CreateActionResult(result);
        }
    }
}
