using DRRCore.Application.DTO.Core.Response;
using DRRCore.Transversal.Common;

namespace DRRCore.Application.Interfaces.CoreApplication
{
    public interface IQueryApplication
    {

        //ABONADO
        Task<Response<List<GetQuery1_1ResponseDto>>> GetQuery1_1ByYear(int year);
        Task<Response<List<GetQuery1_1ByMonthResponseDto>>> GetQuery1_1ByMonth(int year, int month, int idSubscriber);

        Task<Response<List<GetQuery1_2ByYearResponseDto>>> GetQuery1_2ByYear(int year);

        Task<Response<List<GetQuery1_3BySubscriberResponseDto>>> GetQuery1_3BySubscriber(int idSubscriber, int year);

        Task<Response<List<GetQuery1_4SubscriberResponseDto>>> GetQuery1_4Subscribers();
        Task<Response<GetQuery1_4ResponseDto>> GetQuery1_4(int idSubscriber, int year);

        Task<Response<List<GetQuery1_5ResponseDto>>> GetQuery1_5(string startDate, string endDate);

        Task<Response<List<GetQuery1_6ResponseDto>>> GetQuery1_6();
        Task<Response<List<GetQuery1_6BySubscriberResponseDto>>> GetQuery1_6BySubscriber();

        Task<Response<List<GetQuery1_7TicketsReponseDto>>> GetQuery1_7Tickets(int year, int month, int idSubscriber); 
        Task<Response<List<GetQuery1_7SubscriberResponseDto>>> GetQuery1_7Subscriber(); 

        Task<Response<List<GetQuery1_8ResponseDto>>> GetQuery1_8(int year, int month);

        Task<Response<List<GetQuery1_9ResponseDto>>> GetQuery1_9(int year, int month);

        Task<Response<List<GetQuery1_10ResponseDto>>> GetQuery1_10(int idSubscriber, string startDate, string endDate);
        Task<Response<List<GetQuery1_11SubscribersResponseDto>>> GetQuery1_11Subscriber(int year);
        Task<Response<List<GetQuery1_11BySubscriberResponseDto>>> GetQuery1_11BySubscriber(int idSubscriber,int year, int month);


        //REPORTEROS
        Task<Response<List<GetReportersResponseDto>>> GetReporters();

        Task<Response<List<GetQuery2_1ByYearResponseDto>>> GetQuery2_1ByYear(int year);
        Task<Response<List<GetQuery2_1ByMonthResponseDto>>> GetQuery2_1ByMonth(int year,int month, string asignedTo);

        Task<Response<List<GetQuery2_2ByYearResponseDto>>> GetQuery2_2ByYear(int year, string asignedTo);


        //AGENTE 

        Task<Response<List<GetQuery3_1ByYearResponseDto>>> GetQuery3_1ByYear(int year); 
        Task<Response<List<GetQuery3_1ByMonthResponseDto>>> GetQuery3_1ByMonth(string asignedTo, int year, int month);

        Task<Response<List<GetQuery4_1_1ResponseDto>>> GetQuery4_1_1();
        Task<Response<GetFileResponseDto>> DownloadQuery_Fact_4_1_1(string format);
        Task<Response<bool>> SendMailQuery4_1_1_Fact_ByBill(string to, int idSubscriber, int idUser);
        Task<Response<List<GetQuery4_1_2ResponseDto>>> GetQuery4_1_2();
        Task<Response<GetFileResponseDto>> DownloadQuery_Fact_4_1_2(string format);
        Task<Response<List<GetQuery4_1_3ResponseDto>>> GetQuery4_1_3(string startDate, string endDate);
        Task<Response<GetFileResponseDto>> DownloadQuery_Fact_4_1_3(string format, string startDate, string endDate);
        Task<Response<List<GetQuery4_1_4ResponseDto>>> GetQuery4_1_4(int month, int year);
        Task<Response<GetFileResponseDto>> DownloadQuery_Fact_4_1_4(string format, int month, int year);
        Task<Response<GetFileResponseDto>> DownloadQuery_Fact_4_1_5(string format, string orderBy, int month, int year);
        Task<Response<List<GetQuery4_2_1ResponseDto>>> GetQuery4_2_1();
        Task<Response<GetFileResponseDto>> DownloadQuery_Fact_4_2_1(string format);
        Task<Response<List<GetQuery4_2_2ResponseDto>>> GetQuery4_2_2(string startDate, string endDate);
        Task<Response<GetFileResponseDto>> DownloadQuery_Fact_4_2_2(string format, string startDate, string endDate);

    }
}
