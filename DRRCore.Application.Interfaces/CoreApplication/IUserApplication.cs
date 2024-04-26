using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Transversal.Common;

namespace DRRCore.Application.Interfaces.CoreApplication
{
    public interface IUserApplication
    {
        Task<Response<List<GetProcessResponseDto>>> GetProcessAsync();
        Task<Response<string>> LoginUser(string username, string password);
        Task<Response<GetUserResponseDto>> getUserById(int id);
        Task<Response<GetUserProcessResponseDto>> getProcessByIdEmployee(int idEmployee);
        Task<Response<bool>> UpdateProcess(AddOrUpdateUserProcessRequestDto obj);
    }
}
