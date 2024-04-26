using DRRCore.Application.DTO.Core.Response;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class ProviderDomain : IProviderDomain
    {
        private readonly IProviderRepository _providerRepository;
        public ProviderDomain(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }
        public async Task<bool> AddAsync(Provider obj)
        {
            return await _providerRepository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _providerRepository.DeleteAsync(id);
        }

        public Task<List<Provider>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Provider> GetByIdAsync(int id)
        {
            return await _providerRepository.GetByIdAsync(id);
        }

        public Task<List<Provider>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Provider>> GetProviderByIdPerson(int idPerson)
        {
            return await _providerRepository.GetProviderByIdPerson(idPerson);
        }

        public async Task<List<Provider>> GetProvidersByIdCompany(int idCompany)
        {
            return await _providerRepository.GetProviderByIdCompany(idCompany);
        }

        public async Task<List<GetProviderHistoryResponseDto>> GetProvidersHistoryByIdCompany(int idCompany)
        {
            return await _providerRepository.GetProvidersHistoryByIdCompany(idCompany);
        }

        public async Task<List<GetProviderHistoryResponseDto>> GetProvidersHistoryByIdPerson(int idPerson)
        {
            return await _providerRepository.GetProvidersHistoryByIdPerson(idPerson);
        }

        public async Task<bool> UpdateAsync(Provider obj)
        {
            return await _providerRepository.UpdateAsync(obj);
        }
    }
}
