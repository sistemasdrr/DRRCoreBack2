using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Entities.SQLContext;

namespace DRRCore.Infraestructure.Interfaces.Repository
{
    public interface IWebQueryRepository
    {
        Task<bool> UpdateData(List<ViewConsultaWeb> listWebData);
        Task<List<WebQuery>> GetByParamAsync(string param, int page);
        Task<WebQuery> GetByCodeAsync(string code);
        Task<List<WebQuery>> GetByCountryAndBranchAsync(int country, string branch, int page);
        Task<List<WebQuery>> GetSimilarBrunchAsync(string code);
        Task<List<WebQuery>> GetByParamAndCountryAsync(string param, string country);
        Task<string> GetOldCodeAsync(string code);
    }
}
