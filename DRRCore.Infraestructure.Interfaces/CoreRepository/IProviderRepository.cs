using DRRCore.Application.DTO.Core.Response;
using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IProviderRepository : IBaseRepository<Provider>
    {
        Task<List<Provider>> GetProviderByIdCompany(int idCompany);
        Task<List<Provider>> GetProviderByIdPerson(int idPerson);
        Task<List<GetProviderHistoryResponseDto>> GetProvidersHistoryByIdCompany(int idCompany);
        Task<List<GetProviderHistoryResponseDto>> GetProvidersHistoryByIdPerson(int idPerson);
    }
}
