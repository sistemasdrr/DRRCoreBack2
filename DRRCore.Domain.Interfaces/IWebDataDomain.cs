

using DRRCore.Domain.Entities.SQLContext;

namespace DRRCore.Domain.Interfaces
{
    public interface IWebDataDomain
    {
        Task<bool> AddOrUpdateWebDataAsync();
        Task<List<WebQuery>> GetByParamAsync(string param,int page);
        Task<WebQuery> GetByCodeAsync(string code);
        Task<List<WebQuery>> GetByCountryAndBranchAsync(int country, string branch, int page);
        Task<List<WebQuery>> GetSimilarBrunchAsync(string code);
        Task<List<WebQuery>> GetByParamAndCountryAsync(string param, string country);
        Task<string> GetOldCodeAsync(string code);
    }
}
