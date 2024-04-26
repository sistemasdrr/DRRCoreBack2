using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class CompanyFinancialInformationDomain : ICompanyFinancialInformationDomain
    {
        private readonly ICompanyFinancialInformationRepository _repository;
        public CompanyFinancialInformationDomain(ICompanyFinancialInformationRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddAsync(CompanyFinancialInformation obj)
        {
            return await _repository.AddAsync(obj);
        }

        public async Task<int> AddCompanyFinancialInformation(CompanyFinancialInformation obj, List<Traduction> traduction)
        {
            return await _repository.AddCompanyFinancialInformation(obj, traduction);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public Task<List<CompanyFinancialInformation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyFinancialInformation> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<CompanyFinancialInformation> GetByIdCompany(int idCompany)
        {
            return await _repository.GetByIdCompany(idCompany);
        }

        public Task<List<CompanyFinancialInformation>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(CompanyFinancialInformation obj)
        {
            return await _repository.UpdateAsync(obj);
        }

        public async Task<int> UpdateCompanyFinancialInformation(CompanyFinancialInformation obj, List<Traduction> traduction)
        {
            return await _repository.UpdateCompanyFinancialInformation(obj, traduction);
        }
    }
}
