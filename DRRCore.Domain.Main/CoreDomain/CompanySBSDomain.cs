using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class CompanySBSDomain : ICompanySBSDomain
    {
        private readonly ICompanySBSRepository _companySBSRepository;
        public CompanySBSDomain(ICompanySBSRepository companySBSRepository)
        {
            _companySBSRepository = companySBSRepository;
        }

        public Task<bool> AddAsync(CompanySb obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddCompanySBS(CompanySb companySb, List<Traduction> traductions)
        {
            return await _companySBSRepository.AddCompanySBS(companySb, traductions);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _companySBSRepository.DeleteAsync(id);
        }

        public Task<List<CompanySb>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CompanySb> GetByIdAsync(int id)
        {
            return await _companySBSRepository.GetByIdAsync(id);
        }

        public async Task<CompanySb> GetByIdCompany(int idCompany)
        {
            return await _companySBSRepository.GetByIdCompany(idCompany);
        }

        public Task<List<CompanySb>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> NewComercialReferences(int idCompany, int? idTicket)
        {
            return await _companySBSRepository.NewComercialReferences(idCompany, idTicket);
        }

        public Task<bool> UpdateAsync(CompanySb obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateCompanySBS(CompanySb companySb, List<Traduction> traductions)
        {
            return await _companySBSRepository.UpdateCompanySBS(companySb, traductions);
        }
    }
}
