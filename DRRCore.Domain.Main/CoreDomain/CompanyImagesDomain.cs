using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class CompanyImagesDomain : ICompanyImagesDomain
    {
        private readonly ICompanyImagesRepository _companyImagesRepository;
        public CompanyImagesDomain(ICompanyImagesRepository companyImagesRepository)
        {
            _companyImagesRepository = companyImagesRepository;
        }

        public Task<bool> AddAsync(CompanyImage obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddCompanyImage(CompanyImage obj, List<Traduction> traductions)
        {
            return await _companyImagesRepository.AddCompanyImage(obj, traductions);
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

        public async Task<CompanyImage> GetByIdCompany(int idCompany)
        {
            return await _companyImagesRepository.GetByIdCompany(idCompany);
        }

        public Task<List<CompanyImage>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(CompanyImage obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateCompanyImage(CompanyImage obj, List<Traduction> traductions)
        {
            return await _companyImagesRepository.UpdateCompanyImage(obj, traductions);
        }
    }
}
