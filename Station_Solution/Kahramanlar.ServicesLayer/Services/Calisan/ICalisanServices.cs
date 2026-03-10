using Kahramanlar.ServicesLayer.Services.Calisan.Create;

namespace Kahramanlar.ServicesLayer.Services.Calisan
{
    public interface ICalisanServices
    {
        Task<ServiceResult<CalisanResponse>> GetCalisanByIdAsync(string calisanId);
        Task<ServiceResult<List<CalisanResponse>>> GetAllCalisanAsync();
        Task<ServiceResult<CreateCalisanResponse>> CreateCalisanAsync(CreateCalisanRequest request);
        Task<ServiceResult<CalisanResponse>> UpdateCalisanAsync(CreateCalisanRequest request);
        Task<ServiceResult> DeleteCalisanAsync(string calisanId);
        Task<ServiceResult<List<CalisanResponse>>> GetCalisanlarByIseGirisOrCikisRangeAsync(DateTime start, DateTime end);
        Task<ServiceResult<CalisanResponse>> GetCalisanByTcNoAsync(string tcNo);
        Task<ServiceResult<List<CalisanResponse>>> GetCalisanlarByIsActiveAsync(bool isActive);
    }
}
