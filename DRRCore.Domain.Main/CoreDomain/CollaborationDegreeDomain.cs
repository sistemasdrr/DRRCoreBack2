using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class CollaborationDegreeDomain : ICollaborationDegreeDomain
    {
        private readonly ICollaborationDegreeRepository _repository;
        public CollaborationDegreeDomain(ICollaborationDegreeRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> AddAsync(CollaborationDegree obj)
        {
            return await _repository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<List<CollaborationDegree>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CollaborationDegree> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public Task<List<CollaborationDegree>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(CollaborationDegree obj)
        {
            return await _repository.UpdateAsync(obj);
        }
    }
}
