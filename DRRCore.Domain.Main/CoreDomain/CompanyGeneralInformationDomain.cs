using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class CompanyGeneralInformationDomain : ICompanyGeneralInformationDomain
    {
        private readonly ICompanyGeneralInformationRepository _repository;
        public CompanyGeneralInformationDomain(ICompanyGeneralInformationRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> AddAsync(CompanyGeneralInformation obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddGeneralInformation(CompanyGeneralInformation obj, List<Traduction> traductions)
        {
            return await _repository.AddGeneralInformation(obj, traductions);
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CompanyGeneralInformation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CompanyGeneralInformation> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyGeneralInformation> GetByIdCompany(int idCompany)
        {
            return await _repository.GetByIdCompany(idCompany);
        }

        public Task<List<CompanyGeneralInformation>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(CompanyGeneralInformation obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateGeneralInformation(CompanyGeneralInformation obj, List<Traduction> traductions)
        {
            return await _repository.UpdateGeneralInformation(obj, traductions);
        }
    }
}
