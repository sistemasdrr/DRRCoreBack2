
using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Transversal.Common;

namespace DRRCore.Application.Interfaces.CoreApplication
{
    public interface IAgentApplication
    {
        Task<Response<List<GetListAgentResponseDto>>> GetListAgentAsync(string code, string name, string state);
        Task<Response<int>> AddOrUpdateAgent(AddOrUpdateAgentResponseDto obj);
        Task<Response<AddOrUpdateAgentResponseDto>> GetAgentById(int idAgent);
    }
}
