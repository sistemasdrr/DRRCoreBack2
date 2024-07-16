using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Transversal.Common;
using Microsoft.AspNetCore.Http;

namespace DRRCore.Application.Interfaces.CoreApplication
{
    public interface ITicketApplication
    {
        Task<Response<List<GetTicketFileResponseDto>>> GetTicketFilesByIdTicket(int idTicket);
        Task<Response<int?>> AddTicketAsync(AddOrUpdateTicketRequestDto request);
        Task<Response<bool>> DownloadAndUploadF1(int idTicket);
        Task<Response<bool>> SaveTicketAsignations(int idTicket, string commentary);
        Task<Response<bool>> AddTicketByWeb(AddOrUpdateTicketRequestDto request);
        Task<Response<bool>> AddTicketOnline(AddOrUpdateTicketRequestDto request, string rubro, string sendTo);
        Task<Response<GetExistingTicketResponseDto>> GetReportType(int id, string type);
        Task<Response<GetNumerationResponseDto>> GetTicketNumberAsync();
        Task<Response<GetTicketRequestDto>> GetTicketRequestAsync(int id);
        Task<Response<List<GetListTicketResponseDto>>> GetTicketListAsync();
        Task<Response<List<GetListTicketResponseDto>>> GetTicketListToDispatchAsync();
        Task<Response<bool>> DispatchTicket(int idTicket, int idUser);
        Task<Response<bool>> DeleteTicketHistory(int idTicket, string? assignedTo, int? numberAssign, string? returnMessage);
        Task<Response<List<GetTicketHistorySubscriberResponseDto>>> GetTicketHistoryByIdSubscriber(int idSubscriber, string? name, DateTime? from, DateTime? until, int? idCountry);
        Task<Response<bool>> DeleteTicket(int id);
        Task<Response<List<GetListTicketResponseDto>>> GetTicketListPendingAsync();
        Task<Response<List<GetListTicketResponseDto>>> GetTicketListByAsync(string ticket, string name, string subscriber, string type, string procedure);
        Task<Response<GetTicketQueryResponseDto>> GetTicketQuery(int idTicket);
        Task<Response<bool>> AnswerTicket(int idTicket, string subscriberResponse);
        Task<Response<bool>> SendTicketQuery(SendTicketQueryRequestDto request);
        Task<Response<byte[]>> DownloadReport();
        Task<Response<bool>> SavePreAsignTicket(List<SavePreAsignTicketDto> lista);
        Task<Response<bool>> SendPreAsignTicket(List<SavePreAsignTicketDto> lista);
        Task<Response<List<GetListTicketResponseDto2>>> GetTicketsToUser(string userTo);
        Task<Response<List<GetPersonalAssignationResponseDto>>> GetPersonalAssignation();
        Task<Response<List<GetPersonalAssignationResponseDto>>> GetAgentAssignation();
        Task<Response<bool>> AddTicketHistory(List<AddOrUpdateAssignationsRequestDto> obj);

        Task<Response<bool>> UploadFile(int idTicket, string numCupon, IFormFile file);
        Task<Response<GetFileDto>> DownloadFileById(int id);
        Task<Response<bool?>> DeleteFile(int id);
        Task<Response<string?>> GetNumCuponById(int idTicket);

        Task<Response<List<GetListTicketResponseDto>>> GetTicketsByIdSubscriber(int idSubscriber, string? company, DateTime from, DateTime until, int idCountry);
        Task<Response<List<GetSearchSituationResponseDto>>> GetSearchSituation(string about, string typeSearch, string? search, int? idCountry);
        Task<Response<List<GetTicketsByCompanyOrPersonResponseDto>>> GetTicketsByCompanyOrPerson(string about, int id, string oldCode);
        Task<Response<List<GetTimeLineTicketHistoryResponseDto>>> GetTimeLineTicketHistory(int idTicket);
        Task<Response<GetTicketObservationsResponseDto>> GetTicketObservations(int idTicket);
        Task<Response<bool>> AddTicketObservations(int idTicket, string observations, string userFrom);

        Task<Response<bool?>> AssignTicket(NewAsignationDto obj);
        Task<Response<bool>> FinishWork(AssignTicketRequestDto obj);
        Task<Response<List<GetShortProviderByTicket>>> GetProvidersByIdTicket(int idTicket);
        Task<Response<bool>> TicketToDispacth(int idTicket);
        Task<Response<List<GetTicketPendingObservationsResponseDto>>> GetTicketPendingObservations(int idTicket);
        Task<Response<bool>> AddOrUpdateTicketPendingObservations(AddOrUpdateTicketPendingObservationsResponseDto obj);
        Task<Response<List<GetEmployeeAssignated>>> GetEmployeesAssignatedToTicket(int idTicket);
        Task<Response<bool>> FinishTicketObservation(int idTicketObservation, string? conclusion, bool dr, bool ag, bool cl);
        Task<Response<List<string>>> GetOtherUserCode(int idUser);
        Task<Response<List<GetTicketHistoryResponseDto>>> getCountAsignation();
        Task<Response<bool>> TicketToDispatch(int idTicketHistory,int idTicket);
        Task<Response<string>> GetSupervisorTicket(int idTicket);
        Task<Response<bool>> DeleteTicketHistoryById(int idTicket);
        Task<Response<GetFileDto>> DownloadZipByIdTicket(int idTicket);

    }
}
