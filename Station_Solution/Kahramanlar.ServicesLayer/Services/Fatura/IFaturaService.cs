using Kahramanlar.ServicesLayer.Services.Fatura.Create;
using Kahramanlar.ServicesLayer.Services.Fatura.Update;

namespace Kahramanlar.ServicesLayer.Services.Fatura
{
    public interface IFaturaService
    {
        #region Generic CRUD Operations
        Task<ServiceResult<CreateFaturaResponse>> CreateFaturaAsync(CreateFaturaRequest request);
        Task<ServiceResult> UpdateFatura (UpdateFaturaRequest request);
        Task<ServiceResult> DeleteFatura (string faturaId);
        Task<ServiceResult<List<FaturaResponse>>> GetAllFaturalarAsync();
        Task<ServiceResult<FaturaResponse>> GetByFaturaId(string faturaId);
        #endregion

        #region Ekstra Operations
        Task<ServiceResult<List<FaturaResponse>>> GetFaturalarByDateRange(DateTime startDate, DateTime endDate);
        Task<ServiceResult<FaturaResponse>> GetFaturaByFisNo(int fisNo);
        Task<ServiceResult<List<FaturaResponse>>> GetFaturalarByTuru(string turu);
        Task<ServiceResult<List<FaturaResponse>>> GetFaturalarByTutarRange(double minTutar, double maxTutar);
        Task<ServiceResult<List<FaturaResponse>>> GetFaturalarByLtRange(double minLt, double maxLt);
        #endregion
    }
}