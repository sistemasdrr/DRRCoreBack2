using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class CountryDomain : ICountryDomain
    {
        private readonly ICountryRepository _repository;
        public CountryDomain(ICountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddAsync(Country obj)
        {
            return await _repository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<List<Country>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<Country>> GetByNameAsync(string name)
        {
            return await _repository.GetByNameAsync(name);
        }

        public async Task<List<Continent>> GetContinents()
        {
           return await _repository.GetContinents();
        }

        public async Task<List<Country>> GetCountriesByContinent(int idContinent)
        {
            return await _repository.GetCountriesByContinent(idContinent);
        }

        public async Task<bool> UpdateAsync(Country obj)
        {
            return await _repository.UpdateAsync(obj);
        }
    }
}
