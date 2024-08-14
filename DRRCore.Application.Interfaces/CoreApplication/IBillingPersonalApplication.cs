using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Transversal.Common;

namespace DRRCore.Application.Interfaces.CoreApplication
{
    public interface IBillingPersonalApplication
    {
        Task<Response<bool>> AddOrUpdateBillingPersonal(AddOrUpdateBillingPersonal obj);
        Task<Response<bool>> DeleteBillingPersonal(int id);
        Task<Response<GetBillingPersonalResponseDto>> GetBillingPersonalById(int id);
        Task<Response<List<GetBillingPersonalResponseDto>>> GetBillingPersonalsByCode(string code);
        Task<Response<List<GetBillingPersonalResponseDto>>> GetBillingPersonalsByIdEmployee(int idEmployee); 
        Task<Response<List<string>>> GetOtherUserCode(int idEmployee);
    }
}
