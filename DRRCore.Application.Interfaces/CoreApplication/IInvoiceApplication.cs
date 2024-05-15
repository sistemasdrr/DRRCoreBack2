using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Transversal.Common;

namespace DRRCore.Application.Interfaces.CoreApplication
{
    public interface IInvoiceApplication
    {
        Task<Response<List<GetInvoiceSubscriberListResponseDto>>> GetInvoiceSubscriberList(string startDate, string endDate, int month, int year, int idInvoiceStatus);
        Task<Response<List<GetInvoiceAgentListResponseDto>>> GetByBillInvoiceAgentList(string startDate, string endDate);
        Task<Response<List<GetAgentInvoiceListResponseDto>>> GetPaidsInvoiceAgentList(string startDate, string endDate);
        Task<Response<List<GetAgentInvoiceListResponseDto>>> GetToCollectInvoiceAgentList(string startDate, string endDate);
        Task<Response<bool>> UpdateAgentTicket(int idTicketHistory, string requestedName, string procedureType, string shippingDate);

        Task<Response<bool>> SaveInvoice(AddOrUpdateAgentInvoiceRequestDto obj);
        Task<Response<bool>> UpdateInvoiceToCollect(int idAgentInvoice, int idAgentInvoiceDetails, string requestedName, string procedureType, string shippingDate, decimal price);
        Task<Response<bool>> CancelInvoiceToCollect(int idAgentInvoice, string cancelDate);
    }
}
