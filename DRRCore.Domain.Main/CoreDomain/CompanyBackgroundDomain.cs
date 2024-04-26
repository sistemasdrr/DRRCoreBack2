using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class CompanyBackgroundDomain : ICompanyBackgroundDomain
    {
        private readonly ICompanyBackgroundRepository _companyBackgroundRepository;

        public CompanyBackgroundDomain(ICompanyBackgroundRepository companyBackgroundRepository)
        {
            _companyBackgroundRepository= companyBackgroundRepository;
        }
        public async Task<int?> AddAsync(CompanyBackground obj, List<Traduction> traductions)
        {
            return await _companyBackgroundRepository.AddAsync(obj,traductions);
        }

        public Task<bool> AddAsync(CompanyBackground obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CompanyBackground>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyBackground> GetByIdAsync(int id)
        {
            return await _companyBackgroundRepository.GetByIdAsync(id);
        }

        public Task<List<CompanyBackground>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> UpdateAsync(CompanyBackground obj, List<Traduction> traductions)
        {
            return await _companyBackgroundRepository.UpdateAsync(obj, traductions);   
        }

        public Task<bool> UpdateAsync(CompanyBackground obj)
        {
            throw new NotImplementedException();
        }
    }
}
