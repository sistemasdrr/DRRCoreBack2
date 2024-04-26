using DRRCore.Application.DTO.Core.Response;
using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IProviderDomain : IBaseDomain<Provider>
    {
        Task<List<Provider>> GetProvidersByIdCompany(int idCompany);
        Task<List<Provider>> GetProviderByIdPerson(int idPerson);
        Task<List<GetProviderHistoryResponseDto>> GetProvidersHistoryByIdCompany(int idCompany);
        Task<List<GetProviderHistoryResponseDto>> GetProvidersHistoryByIdPerson(int idPerson);
    }
}
