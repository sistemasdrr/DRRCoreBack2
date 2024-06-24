using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class CompanyImagesRepository : ICompanyImagesRepository
    {
        private readonly ILogger _logger;
        public CompanyImagesRepository(ILogger logger)
        {
            _logger = logger;
        }

        public Task<bool> AddAsync(CompanyImage obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddCompanyImage(CompanyImage obj, List<Traduction> traductions)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();

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
            throw new NotImplementedException();
        }
    }
}
