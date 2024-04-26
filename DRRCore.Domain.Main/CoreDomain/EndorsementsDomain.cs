using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class EndorsementsDomain : IEndorsementsDomain
    {
        private readonly IEndorsementsRepository _endorsementsRepository;
        public EndorsementsDomain(IEndorsementsRepository endorsementsRepository)
        {
            _endorsementsRepository = endorsementsRepository;
        }

        public async Task<bool> AddAsync(Endorsement obj)
        {
            return await _endorsementsRepository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _endorsementsRepository.DeleteAsync(id);
        }

        public Task<List<Endorsement>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Endorsement> GetByIdAsync(int id)
        {
            return await _endorsementsRepository.GetByIdAsync(id);
        }

        public async Task<List<Endorsement>> GetByIdCompany(int idCompany)
        {
            return await _endorsementsRepository.GetByIdCompany(idCompany);
        }

        public Task<List<Endorsement>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Endorsement obj)
        {
            return await _endorsementsRepository.UpdateAsync(obj);
        }
    }
}
