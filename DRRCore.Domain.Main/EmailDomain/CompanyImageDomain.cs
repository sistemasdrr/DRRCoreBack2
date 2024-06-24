using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.EmailDomain;
using DRRCore.Infraestructure.Interfaces.Repository;

namespace DRRCore.Domain.Main.EmailDomain
{
    public class CompanyImageDomain : ICompanyImageDomain
    {
        private readonly ICompanyImageRepository _companyImageRepository;
        public CompanyImageDomain(ICompanyImageRepository companyImageRepository)
        {
            _companyImageRepository = companyImageRepository;
        }

        public async Task<bool> AddAsync(CompanyImage obj)
        {
            return await _companyImageRepository.AddAsync(obj);
        }

        public async Task<int?> AddCompanyImage(CompanyImage obj)
        {
            return await _companyImageRepository.AddCompanyImage(obj);
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CompanyImage>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CompanyImage> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CompanyImage>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyImage> GetImagesByIdCompany(int idCompany)
        {
            return await _companyImageRepository.GetImagesByIdCompany(idCompany);
        }

        public Task<bool> UpdateAsync(CompanyImage obj)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateImageCompany(int idCompany, int number, string? base64, string? description, string? descriptionEng, bool? print)
        {
            return await _companyImageRepository.UpdateImageCompany(idCompany,number, base64, description, descriptionEng, print);
        }
    }
}
