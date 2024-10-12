using DRRCore.Application.DTO.Core.Response;
using DRRCore.Transversal.Common;

namespace DRRCore.Application.Interfaces.CoreApplication
{
    public interface IReportApplication
    {
        Task<Response<GetFileResponseDto>> DownloadReport6_1_5(int idSubscriber);
        Task<Response<GetFileResponseDto>> DownloadReport6_1_7(string orderBy);
        Task<Response<GetFileResponseDto>> DownloadReport6_1_14(string type);
    }
}
