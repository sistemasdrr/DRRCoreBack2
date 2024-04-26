using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface ICountryDomain:IBaseDomain<Country>
    {
        Task<List<Continent>> GetContinents();
        Task<List<Country>> GetCountriesByContinent(int idContinent);
    }
}
