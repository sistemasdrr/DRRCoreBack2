using DRRCore.Domain.Entities.SQLContext;
using DRRCore.Domain.Interfaces;
using DRRCore.Infraestructure.Interfaces.Repository;

namespace DRRCore.Domain.Main
{
    public class ApiHistoryDomain : IApiHistoryDomain
    {
        public readonly IApiHistoryRepository _apiHistoryRepository;
        public ApiHistoryDomain(IApiHistoryRepository apiHistoryRepository)
        {
            _apiHistoryRepository = apiHistoryRepository;
        }

        public async Task<bool> AddApiHistoryAsync(ApiHistory obj)
        {
            return await _apiHistoryRepository.AddApiHistoryAsync(obj);
        }

        public async Task<bool> DeleteApiHistoryAsync(int idApiHistory)
        {
            return await _apiHistoryRepository.DeleteApiHistoryAsync(idApiHistory);
        }

        public async Task<List<ApiHistory>> GetAllApiHistoryAsync()
        {
            return await _apiHistoryRepository.GetAllApiHistoryAsync();
        }

        public async Task<List<ApiHistory>> GetAllApiHistoryByApiUserAsync(int idApiUser)
        {
            return await _apiHistoryRepository.GetAllApiHistoryByApiUserAsync(idApiUser);
        }

        public async Task<List<ApiHistory>> GetAllApiHistoryBySearchAsync(string search)
        {
            return await _apiHistoryRepository.GetAllApiHistoryBySearchAsync(search);
        }

        public async Task<List<ApiHistory>> GetAllApiHistoryBySuccessAsync(bool success)
        {
            return await _apiHistoryRepository.GetAllApiHistoryBySuccessAsync(success);
        }

        public async Task<ApiHistory> GetApiHistoryByIdAsync(int idApiHistory)
        {
            return await _apiHistoryRepository.GetApiHistoryByIdAsync(idApiHistory);
        }

        public async Task<bool> UpdateApiHistoryAsync(ApiHistory obj)
        {
            return await _apiHistoryRepository.UpdateApiHistoryAsync(obj);
        }
    }
}
