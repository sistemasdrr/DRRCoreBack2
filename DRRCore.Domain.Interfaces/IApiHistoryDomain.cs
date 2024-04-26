

using DRRCore.Domain.Entities.SQLContext;

namespace DRRCore.Domain.Interfaces
{
    public interface IApiHistoryDomain
    {
        Task<List<ApiHistory>> GetAllApiHistoryAsync();
        Task<List<ApiHistory>> GetAllApiHistoryByApiUserAsync(int idApiUser);
        Task<List<ApiHistory>> GetAllApiHistoryBySearchAsync(string search);
        Task<List<ApiHistory>> GetAllApiHistoryBySuccessAsync(bool success);
        Task<ApiHistory> GetApiHistoryByIdAsync(int idApiHistory);
        Task<bool> AddApiHistoryAsync(ApiHistory obj);
        Task<bool> DeleteApiHistoryAsync(int idApiHistory);
        Task<bool> UpdateApiHistoryAsync(ApiHistory obj);
    }
}
