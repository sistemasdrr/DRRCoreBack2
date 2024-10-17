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
        Task<Response<GetFileResponseDto>> DownloadReport6_1_18(int idCountry, int year, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_1_19_1(int month, int year, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_1_19_2(int month, int year, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_1_20(int month, int year, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_1_21(int month, int year, string orderBy, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_1_22(int year, string orderBy, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_1_25(string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_2_1(string startDate, string endDate, string code, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_2_2(string code, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_2_3(string startDate, string endDate, string code, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_2_4(int month, int year, string orderBy, string format);
    }
}
