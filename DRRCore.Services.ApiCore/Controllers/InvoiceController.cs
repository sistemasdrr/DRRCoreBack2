using DRRCore.Application.DTO.Core.Request;
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
        [Route("GetInvoiceSubscriberListByBill")] 
        public async Task<ActionResult> GetInvoiceSubscriberListByBill(string startDate, string endDate)
        {
            return Ok(await _invoiceApplication.GetInvoiceSubscriberListByBill(startDate, endDate));
        }
        [HttpGet()]
        [Route("GetInvoiceSubscriberListToCollect")] 
        public async Task<ActionResult> GetInvoiceSubscriberListToCollect(int month, int year)
        {
            return Ok(await _invoiceApplication.GetInvoiceSubscriberListToCollect(month, year));
        }
        [HttpGet()]
        [Route("GetInvoiceSubscriberListPaids")]
        public async Task<ActionResult> GetInvoiceSubscriberListPaids(int month, int year)
        {
            return Ok(await _invoiceApplication.GetInvoiceSubscriberListPaids(month, year));
        }
        [HttpPost()]
        [Route("UpdateSubscriberTicket")]
        public async Task<ActionResult> UpdateSubscriberTicket(int idTicket, string requestedName, string procedureType, string dispatchDate, decimal price)
        {
            return Ok(await _invoiceApplication.UpdateSubscriberTicket(idTicket, requestedName, procedureType, dispatchDate,price));
        }
        [HttpPost()]
        [Route("SaveSubscriberInvoice")]
        public async Task<ActionResult> SaveSubscriberInvoice(AddOrUpdateSubscriberInvoiceRequestDto obj)
        {
            return Ok(await _invoiceApplication.SaveSubscriberInvoice(obj));
        }
        [HttpPost()]
        [Route("UpdateSubscriberInvoiceToCollect")]
        public async Task<ActionResult> UpdateSubscriberInvoiceToCollect(int idSubscriberInvoice, int idSubscriberInvoiceDetails, string requestedName, string procedureType, string dispatchDate, decimal price)
        {
            return Ok(await _invoiceApplication.UpdateSubscriberInvoiceToCollect(idSubscriberInvoice, idSubscriberInvoiceDetails, requestedName, procedureType, dispatchDate, price));
        }
        [HttpPost()]
        [Route("CancelSubscriberInvoiceToCollect")]
        public async Task<ActionResult> CancelSubscriberInvoiceToCollect(int idSubscriberInvoice, string cancelDate)
        {
            return Ok(await _invoiceApplication.CancelSubscriberInvoiceToCollect(idSubscriberInvoice, cancelDate));
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
        [Route("SaveAgentInvoice")]
        public async Task<ActionResult> SaveAgentInvoice(AddOrUpdateAgentInvoiceRequestDto obj)
        {
            return Ok(await _invoiceApplication.SaveAgentInvoice(obj));
        }
        [HttpPost()]
        [Route("UpdateInvoiceToCollect")]
        public async Task<ActionResult> UpdateInvoiceToCollect(int idAgentInvoice, int idAgentInvoiceDetails, string requestedName, string procedureType, string shippingDate, decimal price)
        {
            return Ok(await _invoiceApplication.UpdateInvoiceToCollect(idAgentInvoice, idAgentInvoiceDetails, requestedName, procedureType, shippingDate, price));
        }
        [HttpPost()]
        [Route("CancelAgentInvoiceToCollect")]
        public async Task<ActionResult> CancelInvoiceToCollect(int idAgentInvoice, string cancelDate)
        {
            return Ok(await _invoiceApplication.CancelAgentInvoiceToCollect(idAgentInvoice, cancelDate));
        }
        
    }
}
