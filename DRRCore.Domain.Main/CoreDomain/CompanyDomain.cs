using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class CompanyDomain : ICompanyDomain
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyDomain(ICompanyRepository companyRepository) { 
          _companyRepository = companyRepository;
        }

        public async Task<bool> ActiveWebVision(int id)
        {
           return await _companyRepository.ActiveWebVision(id);
        }

        public async Task<bool> AddAsync(Company obj)
        {
            return await _companyRepository.AddAsync(obj);
        }

        public async Task<int> AddCompanyAsync(Company obj)
        {
            return await _companyRepository.AddCompanyAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _companyRepository.DeleteAsync(id);
        }

        public async Task<bool> DesactiveWebVision(int id)
        {
            return await _companyRepository.DesactiveWebVision(id);
        }

        public Task<List<Company>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _companyRepository.GetByIdAsync(id);
        }

        public async Task<List<Company>> GetByNameAsync(string name, string form, int idCountry,bool haveReport, string filterBy)
        {
            return await _companyRepository.GetByNameAsync(name,form,idCountry, haveReport,filterBy);
        }

        public Task<List<Company>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Company> GetByOldCode(string oldCode)
        {
            return await _companyRepository.GetByOldCode(oldCode);
        }

        public async Task<List<Company>> GetCompanySearch(string name, string taxCode, int? idCountry)
        {
            return await _companyRepository.GetCompanySearch(name, taxCode, idCountry);
        }

        public async Task<List<Company>> GetCompanySituation(string typeSearch, string? search, int? idCountry)
        {
            return await _companyRepository.GetCompanySituation(typeSearch, search, idCountry);
        }

        public async Task<bool> UpdateAsync(Company obj)
        {
            return await _companyRepository.UpdateAsync(obj);

        }

       
    }
}
