using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.Interfaces.CoreApplication;
using Microsoft.AspNetCore.Mvc;

namespace DRRCore.Services.ApiCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : Controller
    {
        public readonly IInvoiceApplication _invoiceApplication;
        public InvoiceController(IInvoiceApplication invoiceApplication)
        {
            _invoiceApplication = invoiceApplication; 
        }
        [HttpGet()]
        [Route("GetInvoiceSubscriberList")]
        public async Task<ActionResult> GetInvoiceSubscriberList(string startDate, string endDate, int month, int year, int idInvoiceStatus)
        {
            return Ok(await _invoiceApplication.GetInvoiceSubscriberList(startDate, endDate, month, year, idInvoiceStatus));
        }
        
        [HttpGet()]
        [Route("GetByBillInvoiceAgentList")]
        public async Task<ActionResult> GetByBillInvoiceAgentList(string startDate, string endDate)
        {
            return Ok(await _invoiceApplication.GetByBillInvoiceAgentList(startDate, endDate));
        }
        [HttpGet()]
        [Route("GetToCollectInvoiceAgentList")] 
        public async Task<ActionResult> GetToCollectInvoiceAgentList(string startDate, string endDate)
        {
            return Ok(await _invoiceApplication.GetToCollectInvoiceAgentList(startDate, endDate));
        }
        [HttpGet()]
        [Route("GetPaidsInvoiceAgentList")] 
        public async Task<ActionResult> GetPaidsInvoiceAgentList(string startDate, string endDate)
        {
            return Ok(await _invoiceApplication.GetPaidsInvoiceAgentList(startDate, endDate));
        }
        [HttpPost()]
        [Route("UpdateAgentTicket")]
        public async Task<ActionResult> UpdateAgentTicket(int idTicketHistory, string requestedName, string procedureType, string shippingDate)
        {
            return Ok(await _invoiceApplication.UpdateAgentTicket(idTicketHistory, requestedName, procedureType, shippingDate));
        }
        [HttpPost()]
        [Route("SaveInvoice")]
        public async Task<ActionResult> SaveInvoice(AddOrUpdateAgentInvoiceRequestDto obj)
        {
            return Ok(await _invoiceApplication.SaveInvoice(obj));
        }
        [HttpPost()]
        [Route("UpdateInvoiceToCollect")]
        public async Task<ActionResult> UpdateInvoiceToCollect(int idAgentInvoice, int idAgentInvoiceDetails, string requestedName, string procedureType, string shippingDate, decimal price)
        {
            return Ok(await _invoiceApplication.UpdateInvoiceToCollect(idAgentInvoice, idAgentInvoiceDetails, requestedName, procedureType, shippingDate, price));
        }
        [HttpPost()]
        [Route("CancelInvoiceToCollect")]
        public async Task<ActionResult> CancelInvoiceToCollect(int idAgentInvoice, string cancelDate)
        {
            return Ok(await _invoiceApplication.CancelInvoiceToCollect(idAgentInvoice, cancelDate));
        }
    }
}
