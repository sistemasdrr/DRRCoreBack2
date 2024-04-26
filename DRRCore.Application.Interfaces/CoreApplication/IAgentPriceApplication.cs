using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Transversal.Common;

namespace DRRCore.Application.Interfaces.CoreApplication
{
    public interface IAgentPriceApplication
    {
        Task<Response<List<GetListAgentPriceResponseDto>>> GetPricesById(int idAgent);
        Task<Response<bool>> AddOrUpdateAgentPrice(AddOrUpdateAgentPriceRequestDto request);
        Task<Response<bool>> DeleteAgentPrice(int id);
        Task<Response<AddOrUpdateAgentPriceRequestDto>> GetPriceById(int id);
    }
}
