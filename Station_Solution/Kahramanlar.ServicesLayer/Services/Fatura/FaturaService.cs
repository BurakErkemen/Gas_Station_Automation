using Google.Cloud.Firestore;
using Kahramanlar.RepositoryLayer.Models.Faturalar;
using Kahramanlar.ServicesLayer.Services.Fatura.Create;
using Kahramanlar.ServicesLayer.Services.Fatura.Update;
using System.Net;

namespace Kahramanlar.ServicesLayer.Services.Fatura
{
    public class FaturaService(IFaturaRepository faturaRepository) : IFaturaService
    {
        public async Task<ServiceResult<CreateFaturaResponse>> CreateFaturaAsync(CreateFaturaRequest request)
        {
            var anyData = await faturaRepository.GetFaturaByFisNo(request.FisNo);

            if (anyData is not null)
            {
                return ServiceResult<CreateFaturaResponse>.Fail($"Fis No {request.FisNo} zaten mevcut.");
            }
            TimeZoneInfo turkeyZone = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");
            DateTime turkeyTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, turkeyZone);

            var faturaModel = new FaturaModel
            {
                FaturaId = Guid.NewGuid().ToString(),
                Turu = request.Turu,
                FisNo = request.FisNo,
                Lt = request.Lt,
                Tutar = request.Tutar,
                Tarih = request.Tarih,
                CreatedAt = DateTime.SpecifyKind(turkeyTime, DateTimeKind.Utc)
            };

            await faturaRepository.AddAsync(faturaModel);

            return ServiceResult<CreateFaturaResponse>.Success(new CreateFaturaResponse(faturaModel.FaturaId), HttpStatusCode.Created);
        }

        public async Task<ServiceResult> UpdateFatura(UpdateFaturaRequest request)
        {
            var anyData = await faturaRepository.GetByIdAsync(request.FaturaId);

            if (anyData is null)
                return ServiceResult.Fail("Fatura bulunamadı.", HttpStatusCode.NotFound);

            anyData.Turu = request.Turu;
            anyData.FisNo = request.FisNo;
            anyData.Lt = request.Lt;
            anyData.Tutar = request.Tutar;
            anyData.Tarih = request.Tarih;

            await faturaRepository.UpdateAsync(anyData.FaturaId,anyData);

            return ServiceResult.Success(HttpStatusCode.OK);
        }

        public Task<ServiceResult> DeleteFatura(string faturaId)
        {
            var anyData = faturaRepository.GetByIdAsync(faturaId).Result;
            if (anyData is not null)
            {
                faturaRepository.DeleteAsync(faturaId);
                return Task.FromResult(ServiceResult.Success());

            }

            return Task.FromResult(ServiceResult.Fail($"FaturaId {faturaId} bulunamadı.", HttpStatusCode.NotFound));
        }

        public async Task<ServiceResult<List<FaturaResponse>>> GetAllFaturalarAsync()
        {
            var anyData = await faturaRepository.GetAllAsync();

            if (anyData is null)
                return ServiceResult<List<FaturaResponse>>.Fail("Hiç fatura bulunamadı.", HttpStatusCode.NotFound);

            var response = anyData.Select(f => new FaturaResponse(f.Turu, f.FisNo, f.Lt, f.Tutar, f.Tarih, f.CreatedAt)).ToList();

            return ServiceResult<List<FaturaResponse>>.Success(response, HttpStatusCode.OK);
        }

        public async Task<ServiceResult<FaturaResponse>> GetByFaturaId(string faturaId)
        {
            var anyData = await faturaRepository.GetByIdAsync(faturaId);

            if (anyData == null)
            {
                return ServiceResult<FaturaResponse>.Fail($"Fatura bulunamadı.", HttpStatusCode.NotFound);
            }
            var response = new FaturaResponse(anyData.Turu, anyData.FisNo, anyData.Lt, anyData.Tutar, anyData.Tarih, anyData.CreatedAt);

            return ServiceResult<FaturaResponse>.Success(response, HttpStatusCode.OK);
        }

        public async Task<ServiceResult<FaturaResponse>> GetFaturaByFisNo(int fisNo)
        {
            var anyData = await faturaRepository.GetFaturaByFisNo(fisNo);
            if (anyData == null)
                return ServiceResult<FaturaResponse>.Fail($"Fatura bulunamadı.", HttpStatusCode.NotFound);

            var response = new FaturaResponse(anyData.Turu, anyData.FisNo, anyData.Lt, anyData.Tutar, anyData.Tarih, anyData.CreatedAt);

            return ServiceResult<FaturaResponse>.Success(response, HttpStatusCode.OK);
        }

        public async Task<ServiceResult<List<FaturaResponse>>> GetFaturalarByDateRange(DateTime startDate, DateTime endDate)
        {
            var anyData =await faturaRepository.GetFaturalarByDateRange(startDate, endDate);

            if (anyData == null)
                return ServiceResult<List<FaturaResponse>>.Fail("Hiç fatura bulunamadı.", HttpStatusCode.NotFound);

            var response = anyData.Select(f => new FaturaResponse(f!.Turu, f.FisNo, f.Lt, f.Tutar, f.Tarih, f.CreatedAt)).ToList();

            return ServiceResult<List<FaturaResponse>>.Success(response, HttpStatusCode.OK);
        }

        public async Task<ServiceResult<List<FaturaResponse>>> GetFaturalarByLtRange(double minLt, double maxLt)
        {
            var anyData = await faturaRepository.GetFaturalarByLtRange(minLt, maxLt);

            if (anyData == null)
                return ServiceResult<List<FaturaResponse>>.Fail("Hiç fatura bulunamadı.", HttpStatusCode.NotFound);

            var response = anyData.Select(f => new FaturaResponse(f!.Turu, f.FisNo, f.Lt, f.Tutar, f.Tarih, f.CreatedAt)).ToList();

            return ServiceResult<List<FaturaResponse>>.Success(response, HttpStatusCode.OK);
        }

        public async Task<ServiceResult<List<FaturaResponse>>> GetFaturalarByTuru(string turu)
        {
            var anyData = await faturaRepository.GetFaturalarByTuru(turu);

            if (anyData == null || !anyData.Any())
                return ServiceResult<List<FaturaResponse>>.Fail($"Turu {turu} olan fatura bulunamadı.", HttpStatusCode.NotFound);

            var response = anyData.Select(f => new FaturaResponse(f!.Turu, f.FisNo, f.Lt, f.Tutar, f.Tarih, f.CreatedAt)).ToList();

            return ServiceResult<List<FaturaResponse>>.Success(response, HttpStatusCode.OK);
        }

        public Task<ServiceResult<List<FaturaResponse>>> GetFaturalarByTutarRange(double minTutar, double maxTutar)
        {
            var anyData = faturaRepository.GetFaturalarByTutarRange(minTutar, maxTutar).Result;

            if (anyData == null)
                return Task.FromResult(ServiceResult<List<FaturaResponse>>.Fail("Hiç fatura bulunamadı.", HttpStatusCode.NotFound));

            var response = anyData.Select(f => new FaturaResponse(f!.Turu, f.FisNo, f.Lt, f.Tutar, f.Tarih, f.CreatedAt)).ToList();

            return Task.FromResult(ServiceResult<List<FaturaResponse>>.Success(response, HttpStatusCode.OK));
        }
    }
}
