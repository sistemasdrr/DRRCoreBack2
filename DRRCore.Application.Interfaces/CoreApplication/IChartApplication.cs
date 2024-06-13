using DRRCore.Transversal.Common;
using  DRRCore.Application.DTO.Core.Response;
namespace DRRCore.Application.Interfaces.CoreApplication
{
    public interface IChartApplication
    {
        Task<Response<GetQuery5_1_1ResponseDto>> GetQuery5_1_1(string startDate, string endDate);
        Task<Response<GetQuery5_1_2ResponseDto>> GetQuery5_1_2(string startDate, string endDate);
        Task<Response<List<GetQuery5_1_3ResponseDto>>> GetQuery5_1_3(int month, int year);
        Task<Response<GetFileResponseDto>> DownloadReport5_1_3(string format, int month, int year);
        Task<Response<List<GetQuery5_1_4ResponseDto>>> GetQuery5_1_4(int month, int year);
        Task<Response<List<GetQuery5_1_5ResponseDto>>> GetQuery5_1_5();
        Task<Response<GetFileResponseDto>> DownloadReport5_1_5(string format);
        Task<Response<List<GetQuery5_1_6ResponseDto>>> GetQuery5_1_6(int month, int year);
        Task<Response<GetFileResponseDto>> DownloadReport5_1_7(string format, string orderBy);
        Task<Response<GetFileResponseDto>> DownloadReport5_1_9(string format, int year);
        Task<Response<List<GetQuery5_1_15ResponseDto>>> GetQuery5_1_15(int idCountry);
        Task<Response<List<GetQuery5_1_18ResponseDto>>> GetQuery5_1_18(int idCountry, int year);
        Task<Response<GetQuery5_1_19_1ResponseDto>> GetQuery5_1_19Subscriber(int month, int year);
        Task<Response<GetQuery5_1_19_2ResponseDto>> GetQuery5_1_19Countries(int month, int year);
        Task<Response<GetQuery5_1_20ResponseDto>> GetQuery5_1_20Countries(int month, int year);
        Task<Response<List<GetQuery5_1_21ResponseDto>>> GetQuery5_1_21(int month, int year);
        Task<Response<List<GetQuery5_1_26ResponseDto>>> GetQuery5_1_26(int idCountry);
        Task<Response<List<GetQuery5_1_27ResponseDto>>> GetQuery5_1_27(int year);
        Task<Response<List<GetQuery5_2_1ResponseDto>>> GetQuery5_2_1(string startDate, string endDate, string reporter);
        Task<Response<List<GetQuery5_2_2ResponseDto>>> GetQuery5_2_2(string reporter);
        Task<Response<List<GetQuery5_2_3ResponseDto>>> GetQuery5_2_3(string startDate, string endDate, string reporter);
        Task<Response<List<GetQuery5_2_4ResponseDto>>> GetQuery5_2_4(int month, int year);
    }
}
