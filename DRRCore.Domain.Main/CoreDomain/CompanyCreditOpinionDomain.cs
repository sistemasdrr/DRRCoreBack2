using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class CompanyCreditOpinionDomain : ICompanyCreditOpinionDomain
    {
        private readonly ICompanyCreditOpinionRepository _repository;
        public CompanyCreditOpinionDomain(ICompanyCreditOpinionRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> AddAsync(CompanyCreditOpinion obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddCreditOpinion(CompanyCreditOpinion obj, List<Traduction> traductions)
        {
            return await _repository.AddCreditOpinion(obj, traductions);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public Task<List<CompanyCreditOpinion>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CompanyCreditOpinion> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyCreditOpinion> GetByIdCompany(int idCompany)
        {
            return await _repository.GetByIdCompany(idCompany);
        }

        public Task<List<CompanyCreditOpinion>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(CompanyCreditOpinion obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateCreditOpinion(CompanyCreditOpinion obj, List<Traduction> traductions)
        {
            return await _repository.UpdateCreditOpinion(obj, traductions);
        }
    }
}
