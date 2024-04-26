using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Transversal.Common;

namespace DRRCore.Application.Interfaces.CoreApplication
{
    public interface IAnniversaryApplication
    {
        Task<Response<GetAnniversaryResponseDto>> GetByIdAsync(int id);
        Task<Response<List<GetAnniversaryResponseDto>>> GetAllAsync();
        Task<Response<List<GetAnniversaryResponseDto>>> GetCurrentAnniversary();
        Task<Response<bool>> AddOrUpdateAsync(AddOrUpdateAnniversaryRequestDto obj);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<bool>> ActiveAsync(int id);
    }
}
