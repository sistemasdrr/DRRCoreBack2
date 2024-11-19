using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Application.Main.CoreApplication;
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
        [Route("GetInvoiceSubscriberCCListByBill")]
        public async Task<ActionResult> GetInvoiceSubscriberCCListByBill(int month, int year)
        {
            return Ok(await _invoiceApplication.GetInvoiceSubscriberCCListByBill(month, year));
        }
        [HttpGet()]
        [Route("GetInvoiceSubscriberListToCollect")]
        public async Task<ActionResult> GetInvoiceSubscriberListToCollect(int month, int year)
        {
            return Ok(await _invoiceApplication.GetInvoiceSubscriberListToCollect(month, year));
        }
        [HttpGet()]
        [Route("GetInvoiceSubscriberCCListToCollect")]
        public async Task<ActionResult> GetInvoiceSubscriberCCListToCollect(int month, int year)
        {
            return Ok(await _invoiceApplication.GetInvoiceSubscriberCCListToCollect(month, year));
        }
        [HttpGet()]
        [Route("GetInvoiceSubscriberListPaids")]
        public async Task<ActionResult> GetInvoiceSubscriberListPaids(int month, int year)
        {
            return Ok(await _invoiceApplication.GetInvoiceSubscriberListPaids(month, year));
        }
        [HttpGet()]
        [Route("GetInvoiceSubscriberCCListPaids")]
        public async Task<ActionResult> GetInvoiceSubscriberCCListPaids(int month, int year)
        {
            return Ok(await _invoiceApplication.GetInvoiceSubscriberCCListPaids(month, year));
        }
        [HttpPost()]
        [Route("UpdateSubscriberTicket")]
        public async Task<ActionResult> UpdateSubscriberTicket(int idTicket, string requestedName, string procedureType, string dispatchDate, decimal price)
        {
            return Ok(await _invoiceApplication.UpdateSubscriberTicket(idTicket, requestedName, procedureType, dispatchDate,price));
        }
        [HttpPost()]
        [Route("SaveSubscriberInvoiceCC")]
        public async Task<ActionResult> SaveSubscriberInvoiceCC(AddOrUpdateSubscriberInvoiceCCRequestDto obj)
        {
            return Ok(await _invoiceApplication.SaveSubscriberInvoiceCC(obj));
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
        [HttpPost()]
        [Route("CancelSubscriberInvoiceCCToCollect")]
        public async Task<ActionResult> CancelSubscriberInvoiceCCToCollect(int idSubscriberInvoice, string cancelDate)
        {
            return Ok(await _invoiceApplication.CancelSubscriberInvoiceCCToCollect(idSubscriberInvoice, cancelDate));
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
        public async Task<ActionResult> UpdateAgentTicket(int idTicketHistory, string requestedName, string procedureType, string shippingDate, string quality, bool hasBalance, int? idSpecialPrice)
        {
            return Ok(await _invoiceApplication.UpdateAgentTicket(idTicketHistory, requestedName, procedureType, shippingDate, quality,hasBalance, idSpecialPrice));
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
        [HttpGet()]
        [Route("GetPersonalToInvoice")]
        public async Task<ActionResult> GetPersonalToInvoice()
        {
            return Ok(await _invoiceApplication.GetPersonalToInvoice());
        }
        [HttpPost()]
        [Route("SaveInternalInvoice")]
        public async Task<ActionResult> SaveInternalInvoice(string type, string code, string currentCycle, decimal totalPrice, List<GetQueryTicket5_1_2ResponseDto>? tickets)
        {
            return Ok(await _invoiceApplication.SaveInternalInvoice(type,code, currentCycle,totalPrice, tickets));
        }
        [HttpGet()]
        [Route("ReportEmployee")]
        public async Task<IActionResult> ReportEmployee(int idUser, string code, string type, string cycle)
        {
            return Ok(await _invoiceApplication.ReportEmployee(idUser, code, type, cycle));
        }
        [HttpGet()]
        [Route("GetAgentInvoice")]
        public async Task<IActionResult> GetAgentInvoice(string code, string startDate, string endDate)
        {
            return Ok(await _invoiceApplication.GetAgentInvoice(code, startDate, endDate));
        }
        [HttpGet()]
        [Route("GetAgentPrice")]
        public async Task<IActionResult> GetAgentPrice(int idCountry,string asignedTo, string quality, string procedureType, bool hasBalance, int? idSpecialPrice)
        {
            return Ok(await _invoiceApplication.GetAgentPrice(idCountry,asignedTo,quality,procedureType, hasBalance,idSpecialPrice));
        }
        [HttpGet()]
        [Route("GetExcelAgentInvoice")]
        public async Task<IActionResult> GetExcelAgentInvoice(string code, string startDate, string endDate)
        {
            var result = await _invoiceApplication.GetExcelAgentInvoice(code, startDate, endDate);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }

        [HttpPost()]
        [Route("GetTramo")]
        public async Task<IActionResult> GetTramo(AddOrUpdateSubscriberInvoiceRequestDto obj)
        {
            return Ok(await _invoiceApplication.GetTramo(obj));
        }
    }
}
