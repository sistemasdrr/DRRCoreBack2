using DRRCore.Application.DTO.Core.Response;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Transversal.Common;

namespace DRRCore.Application.Interfaces.CoreApplication
{
    public interface IXmlApplication
    {
        Task<Response<GetFileResponseDto>> GetXmlCredendoAsync(int idTicket);
        Task<Response<GetFileResponseDto>> GetXmlAtradiusAsync(int idTicket);
    }
}
