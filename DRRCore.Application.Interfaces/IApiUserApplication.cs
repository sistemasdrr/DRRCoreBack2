using DRRCore.Application.DTO.API;
using DRRCore.Transversal.Common;


namespace DRRCore.Application.Interfaces
{
    public interface IApiUserApplication
    {
        Task<Response<string>> AddApiUserAsync(ApiUserDto obj);
        Task<Response<string>> GetTokenByInsertApiUser(ApiUserDto obj);

    }
}
