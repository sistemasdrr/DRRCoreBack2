using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class CompanyBranchDomain : ICompanyBranchDomain
    {
        private readonly ICompanyBranchRepository _companyBranchRepository;

        public CompanyBranchDomain(ICompanyBranchRepository companyBranchRepository)
        {
            _companyBranchRepository = companyBranchRepository;
        }

        public async Task<int> AddAsync(CompanyBranch obj, List<Traduction> traductions)
        {
            return await _companyBranchRepository.AddAsync(obj, traductions);
        }

        public Task<bool> AddAsync(CompanyBranch obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CompanyBranch>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyBranch> GetByIdAsync(int id)
        {
            return await _companyBranchRepository.GetByIdAsync(id);
        }

        public Task<List<CompanyBranch>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyBranch> GetCompanyBranchByIdCompany(int idCompany)
        {
            return await _companyBranchRepository.GetCompanyBranchByIdCompany(idCompany);
        }

        public async Task<int> UpdateAsync(CompanyBranch obj, List<Traduction> traductions)
        {
            return await _companyBranchRepository.UpdateAsync(obj, traductions);
        }

        public Task<bool> UpdateAsync(CompanyBranch obj)
        {
            throw new NotImplementedException();
        }
    }
}
