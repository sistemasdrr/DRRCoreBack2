using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class ProfessionDomain : IProfessionDomain
    {
        private readonly IProfessionRepository _repository;
        public ProfessionDomain(IProfessionRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> AddAsync(Profession obj)
        {
            return await _repository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<List<Profession>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Profession> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public Task<List<Profession>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Profession obj)
        {
            return await _repository.UpdateAsync(obj);
        }
    }
}
