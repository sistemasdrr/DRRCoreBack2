using DRRCore.Application.DTO.Core.Response;
using DRRCore.Transversal.Common;

namespace DRRCore.Application.Interfaces.CoreApplication
{
    public interface IReportApplication
    {
        Task<Response<GetFileResponseDto>> DownloadReport6_1_5(int idSubscriber, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_1_7(string orderBy, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_1_14(string type, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_1_15(int idCountry, string format);
    }
}
