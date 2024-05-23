using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Transversal.Common;

namespace DRRCore.Application.Interfaces.CoreApplication
{
    public interface IInvoiceApplication
    {
        Task<Response<List<GetInvoiceSubscriberListByBillResponseDto>>> GetInvoiceSubscriberListByBill(string startDate, string endDate);
        Task<Response<List<GetInvoiceSubscriberListToCollectResponseDto>>> GetInvoiceSubscriberListToCollect(int month, int year);
        Task<Response<List<GetInvoiceSubscriberListPaidsResponseDto>>> GetInvoiceSubscriberListPaids(int month, int year);

        Task<Response<bool>> UpdateSubscriberTicket(int idTicket, string requestedName, string procedureType, string dispatchDate, decimal price);
        Task<Response<bool>> SaveSubscriberInvoice(AddOrUpdateSubscriberInvoiceRequestDto obj);
        Task<Response<bool>> UpdateSubscriberInvoiceToCollect(int idSubscriberInvoice, int idSubscriberInvoiceDetails, string requestedName, string procedureType, string dispatchDate, decimal price);
        Task<Response<bool>> CancelSubscriberInvoiceToCollect(int idSubscriberInvoice, string cancelDate);


        Task<Response<List<GetInvoiceAgentListResponseDto>>> GetByBillInvoiceAgentList(string startDate, string endDate);
        Task<Response<List<GetAgentInvoiceListResponseDto>>> GetPaidsInvoiceAgentList(string startDate, string endDate);
        Task<Response<List<GetAgentInvoiceListResponseDto>>> GetToCollectInvoiceAgentList(string startDate, string endDate);
        Task<Response<bool>> UpdateAgentTicket(int idTicketHistory, string requestedName, string procedureType, string shippingDate);

        Task<Response<bool>> SaveAgentInvoice(AddOrUpdateAgentInvoiceRequestDto obj);
        Task<Response<bool>> UpdateInvoiceToCollect(int idAgentInvoice, int idAgentInvoiceDetails, string requestedName, string procedureType, string shippingDate, decimal price);
        Task<Response<bool>> CancelAgentInvoiceToCollect(int idAgentInvoice, string cancelDate);


    }
}
