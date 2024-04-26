using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface ICountryRepository:IBaseRepository<Country>
    {
        Task<List<Continent>> GetContinents();
        Task<List<Country>> GetCountriesByContinent(int idContinent);
    }
}
