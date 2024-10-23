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
        Task<Response<GetFileResponseDto>> DownloadReport6_3_1(string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_3_10(string startDate, string endDate, string code, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_3_20(string code, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_3_30(string startDate, string endDate, string code, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_3_40(int month, int year, string orderBy, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_3_5(string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_3_6(string code, int year, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_3_7(string code, int month, int year, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_3_8(string type, int year, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_3_11(string code, int year, string format);

        Task<Response<GetFileResponseDto>> DownloadReport6_4_1(string startDate, string endDate, string code, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_4_2(string code, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_4_3(string startDate, string endDate, string code, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_4_4(int month, int year, string orderBy, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_5_1(string startDate, string endDate, string code, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_5_2(string code, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_5_3(string startDate, string endDate, string code, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_5_4(int month, int year, string orderBy, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_6_1(string code, string format);
        Task<Response<GetFileResponseDto>> DownloadReport5_1_2(int year, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_1_7(string orderBy, string type, string format);
        Task<Response<GetFileResponseDto>> DownloadReport6_3_10(string code, int year, string format);
    }
}
