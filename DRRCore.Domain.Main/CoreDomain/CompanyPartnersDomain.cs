using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class CompanyPartnersDomain : ICompanyPartnersDomain
    {
        private readonly ICompanyPartnersRepository _companyPartnersRepository;
        public CompanyPartnersDomain(ICompanyPartnersRepository companyPartnersRepository)
        {
            _companyPartnersRepository = companyPartnersRepository;
        }

        public async Task<bool> AddAsync(CompanyPartner obj)
        {
            return await _companyPartnersRepository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _companyPartnersRepository.DeleteAsync(id);
        }

        public Task<List<CompanyPartner>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyPartner> GetByIdAsync(int id)
        {
            return await _companyPartnersRepository.GetByIdAsync(id);
        }

        public Task<List<CompanyPartner>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CompanyPartner>> GetPartnersByIdCompany(int idCompany)
        {
            return await _companyPartnersRepository.GetPartnersByIdCompany(idCompany);
        }

        public async Task<List<CompanyPartner>> GetPartnersByIdPerson(int idPerson)
        {
            return await _companyPartnersRepository.GetPartnersByIdPerson(idPerson);
        }

        public async Task<bool> UpdateAsync(CompanyPartner obj)
        {
            return await _companyPartnersRepository.UpdateAsync(obj);
        }
    }
}
