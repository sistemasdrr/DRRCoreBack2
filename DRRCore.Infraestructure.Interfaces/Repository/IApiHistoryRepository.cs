
using DRRCore.Domain.Entities.SQLContext;

namespace DRRCore.Infraestructure.Interfaces.Repository
{
    public interface IApiHistoryRepository
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
