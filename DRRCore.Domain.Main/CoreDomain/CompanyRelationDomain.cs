using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class CompanyRelationDomain : ICompanyRelationDomain
    {
        private readonly ICompanyRelationRepository _companyRelationRepository;
        public CompanyRelationDomain(ICompanyRelationRepository companyRelationRepository)
        {
            _companyRelationRepository = companyRelationRepository;
        }

        public async Task<bool> AddAsync(CompanyRelation obj)
        {
            return await _companyRelationRepository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _companyRelationRepository.DeleteAsync(id);
        }

        public Task<List<CompanyRelation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyRelation> GetByIdAsync(int id)
        {
            return await _companyRelationRepository.GetByIdAsync(id);
        }

        public Task<List<CompanyRelation>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CompanyRelation>> GetCompanyRelationByIdCompany(int idCompany)
        {
            return await _companyRelationRepository.GetCompanyRelationByIdCompany(idCompany);
        }

        public async Task<bool> UpdateAsync(CompanyRelation obj)
        {
            return await _companyRelationRepository.UpdateAsync(obj);
        }
    }
}
