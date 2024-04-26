using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class CompanyShareHolderDomain : ICompanyShareHolderDomain
    {
        private readonly ICompanyShareHolderRepository _companyShareHolderRepository;
        public CompanyShareHolderDomain(ICompanyShareHolderRepository companyShareHolderRepository)
        {
            _companyShareHolderRepository = companyShareHolderRepository;
        }

        public async Task<bool> AddAsync(CompanyShareHolder obj)
        {
            return await _companyShareHolderRepository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _companyShareHolderRepository.DeleteAsync(id);
        }

        public Task<List<CompanyShareHolder>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyShareHolder> GetByIdAsync(int id)
        {
            return await _companyShareHolderRepository.GetByIdAsync(id);
        }

        public Task<List<CompanyShareHolder>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CompanyShareHolder>> GetShareHoldersByIdCompany(int idCompany)
        {
            return await _companyShareHolderRepository.GetShareHoldersByIdCompany(idCompany);
        }

        public async Task<bool> UpdateAsync(CompanyShareHolder obj)
        {
            return await _companyShareHolderRepository.UpdateAsync(obj);
        }
    }
}
