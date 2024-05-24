using DRRCore.Application.DTO.Core.Response;
using DRRCore.Transversal.Common;

namespace DRRCore.Application.Interfaces.CoreApplication
{
    public interface IQueryApplication
    {
        Task<Response<List<GetQuery1_1ResponseDto>>> GetQuery1_1ByYear(int year);
        Task<Response<List<GetQuery1_1ByMonthResponseDto>>> GetQuery1_1ByMonth(int month, int idSubscriber);

        Task<Response<List<GetQuery1_2ByYearResponseDto>>> GetQuery1_2ByYear(int year);

        Task<Response<List<GetQuery1_3BySubscriberResponseDto>>> GetQuery1_3BySubscriber(int idSubscriber, int year);

        Task<Response<List<GetQuery1_4SubscriberResponseDto>>> GetQuery1_4Subscribers();
        Task<Response<GetQuery1_4ResponseDto>> GetQuery1_4(int idSubscriber, int year);

        Task<Response<List<GetQuery1_5ResponseDto>>> GetQuery1_5(string startDate, string endDate);

        Task<Response<List<GetQuery1_6BySubscriberResponseDto>>> GetQuery1_6BySubscriber();

        Task<Response<List<GetQuery1_7SubscriberResponseDto>>> GetQuery1_7Subscriber();

        Task<Response<List<GetQuery1_8ResponseDto>>> GetQuery1_8(int year, int month);

        Task<Response<List<GetQuery1_9ResponseDto>>> GetQuery1_9(int year, int month);

        Task<Response<List<GetQuery1_10ResponseDto>>> GetQuery1_10(int idSubscriber, string startDate, string endDate);
        Task<Response<List<GetQuery1_11SubscribersResponseDto>>> GetQuery1_11Subscriber(int year);
        Task<Response<List<GetQuery1_11BySubscriberResponseDto>>> GetQuery1_11BySubscriber(int idSubscriber,int year, int month);

    }
}
