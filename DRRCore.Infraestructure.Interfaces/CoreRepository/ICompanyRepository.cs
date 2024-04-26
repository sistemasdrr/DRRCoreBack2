using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface ICompanyRepository:IBaseRepository<Company>
    {
        Task<List<Company>> GetByNameAsync(string name, string form, int idCountry, bool haveReport, string filterBy);
        Task<bool> ActiveWebVision(int id);
        Task<bool> DesactiveWebVision(int id);
        Task<int> AddCompanyAsync(Company obj);
        Task<Company> GetByOldCode(string oldCode);
        Task<List<Company>> GetCompanySearch(string name, string taxCode, int? idCountry);
        Task<List<Company>> GetCompanySituation(string typeSearch, string? search, int? idCountry);
        
    }
}
