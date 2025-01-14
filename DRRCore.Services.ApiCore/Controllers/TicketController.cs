using AspNetCore.ReportingServices.ReportProcessing.ReportObjectModel;
using DocumentFormat.OpenXml.Office2010.Excel;
using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Application.Main.CoreApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Reflection.Emit;

namespace DRRCore.Services.ApiCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : Controller
    {
        public readonly ITicketApplication _ticketApplication;
        public TicketController(ITicketApplication ticketApplication)
        {
            _ticketApplication = ticketApplication;
        }

        [HttpGet()]
        [Route("numberticket")]
        public async Task<ActionResult> GetNumberTicket()
        {
            return Ok(await _ticketApplication.GetTicketNumberAsync());
        }
        [HttpGet()]
        [Route("getNumTicketById")]
        public async Task<ActionResult> getNumTicketById(int idTicket)
        {
            return Ok(await _ticketApplication.GetNumCuponById(idTicket));
        }
        [HttpGet()]
        [Route("getTicketsBySubscriber")]
        public async Task<ActionResult> getTicketsBySubscriber(int idSubscriber, string? company, DateTime from, DateTime until, int idCountry)
        {
            return Ok(await _ticketApplication.GetTicketsByIdSubscriber(idSubscriber, company, from, until, idCountry));
        }
        
        [HttpPost()]
        [Route("add")] 
        public async Task<ActionResult> AddTicket(AddOrUpdateTicketRequestDto request)
        {
            return Ok(await _ticketApplication.AddTicketAsync(request));
        }
        [HttpGet()]
        [Route("SaveTicketAsignations")] 
        public async Task<ActionResult> SaveTicketAsignations(int idTicket, string commentary)
        {
            return Ok(await _ticketApplication.SaveTicketAsignations(idTicket, commentary));
        }
        [HttpPost()]
        [Route("downloadAndUploadF1")]
        public async Task<ActionResult> DownloadAndUploadF1(int idTicket)
        {
            return Ok(await _ticketApplication.DownloadAndUploadF1(idTicket));
        }
        [HttpPost()]
        [Route("addByWeb")]
        public async Task<ActionResult> AddTicketByWeb(AddOrUpdateTicketRequestDto request)
        {
            return Ok(await _ticketApplication.AddTicketByWeb(request));
        }
        [HttpPost()]
        [Route("addOnline")]
        public async Task<ActionResult> AddTicketOnline(AddOrUpdateTicketRequestDto request, string rubro, string sendTo)
        {
            rubro ??= string.Empty;
            sendTo ??= string.Empty;
            return Ok(await _ticketApplication.AddTicketOnline(request,rubro, sendTo));
        }
        [HttpGet()]
        [Route("getTicketHistorySubscriber")]
        public async Task<ActionResult> getTicketHistorySubscriber(int idSubscriber, string? name, DateTime? from, DateTime? until, int? idCountry)
        {
            name ??= string.Empty;
            from ??= null;
            until ??= null;
            return Ok(await _ticketApplication.GetTicketHistoryByIdSubscriber(idSubscriber, name, from, until, idCountry));
        }
        [HttpGet()]
        [Route("getSearchSituation")]
        public async Task<ActionResult> getSearchSituation(string about, string typeSearch, string? search, int? idCountry)
        {
            about ??= string.Empty;
            typeSearch ??= string.Empty;
            search ??= string.Empty;
            return Ok(await _ticketApplication.GetSearchSituation(about, typeSearch, search, idCountry));
        }
        [HttpGet()]
        [Route("GetNewSearchSituation")]
        public async Task<ActionResult> GetNewSearchSituation(string about, string? name, string form, int idCountry, bool haveReport, string filterBy)
        {
            about ??= string.Empty;
            filterBy ??= string.Empty;
            name ??= string.Empty;
            return Ok(await _ticketApplication.GetNewSearchSituation(about, name, form, idCountry, haveReport, filterBy));
        }
        [HttpGet()]
        [Route("getListTicketSituation")]
        public async Task<ActionResult> getListTicketSituation(string about, int id, string oldCode)
        {
            about ??= string.Empty;
            oldCode ??= string.Empty;
            return Ok(await _ticketApplication.GetTicketsByCompanyOrPerson(about, id, oldCode));
        }
        [HttpGet()]
        [Route("getTimeLine")]
        public async Task<ActionResult> getTimeLine(int idTicket)
        {
            return Ok(await _ticketApplication.GetTimeLineTicketHistory(idTicket));
        }
        [HttpGet()]
        [Route("getreporttype")]
        public async Task<ActionResult> GetReportType(int id, string type)
        {
            return Ok(await _ticketApplication.GetReportType(id, type));
        }
        [HttpGet()]
        [Route("getTicketById")]
        public async Task<ActionResult> getTicketById(int id)
        {
            return Ok(await _ticketApplication.GetTicketRequestAsync(id));
        }
        [HttpGet()]
        [Route("getList")]
        public async Task<ActionResult> getList()
        {
            return Ok(await _ticketApplication.GetTicketListAsync());
        }
        [HttpGet()]
        [Route("getListToDispatch")]
        public async Task<ActionResult> getListToDispatch()
        {
            return Ok(await _ticketApplication.GetTicketListToDispatchAsync());
        }
        [HttpGet()]
        [Route("GetUsersInTicket")]
        public async Task<ActionResult> GetUsersInTicket(int idTicket)
        {
            return Ok(await _ticketApplication.GetUsersInTicket(idTicket));
        }
        [HttpPost()]
        [Route("TicketToDispatch")]
        public async Task<ActionResult> TicketToDispatch(int idTicketHistory, int idTicket, string quality, string qualityTranslator, string qualityTypist, List<UserCode> otherUsers)
        {
            return Ok(await _ticketApplication.TicketToDispatch(idTicketHistory, idTicket,quality,qualityTranslator,qualityTypist, otherUsers));
        }
        [HttpPost()]
        [Route("DispatchTicket")]
        public async Task<ActionResult> DispatchTicekt(int idTicket, int idUser, List<int> idTicketFiles)
        {
            return Ok(await _ticketApplication.DispatchTicket(idTicket, idUser, idTicketFiles));
        }
        [HttpPost()]
        [Route("GetExcel")]
        public async Task<ActionResult> GetExcel(int idTicket)
        {
            var result = await _ticketApplication.GetExcel(idTicket);

            if (result != null && result.Data != null)
            {
                return File(result.Data.File?.ToArray(), result.Data.ContentType, result.Data.Name);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet()]
        [Route("getListby")]
        public async Task<ActionResult> getListBy(string? ticket, string? name, string? subscriber, string? type, string? procedure)
        {
            return Ok(await _ticketApplication.GetTicketListByAsync(ticket ?? string.Empty, name ?? string.Empty, subscriber ?? string.Empty, type ?? string.Empty, procedure ?? string.Empty));
        }
        [HttpPost()]
        [Route("deleteTicket")]
        public async Task<ActionResult> deleteTicket(int id)
        {
            return Ok(await _ticketApplication.DeleteTicket(id));
        }
        [HttpGet()]
        [Route("getListPending")]
        public async Task<ActionResult> getListPending()
        {
            return Ok(await _ticketApplication.GetTicketListPendingAsync());

        }
        [HttpGet()]
        [Route("getTicketQuery")]
        public async Task<ActionResult> getTicketQuery(int idTicket)
        {
            return Ok(await _ticketApplication.GetTicketQuery(idTicket));

        }
        [HttpPost()]
        [Route("answeredTicketQuery")]
        public async Task<ActionResult> answeredTicketQuery(int idTicket, string response)
        {
            return Ok(await _ticketApplication.AnswerTicket(idTicket, response));
        }
        [HttpPost()]
        [Route("sendQuery")]
        public async Task<ActionResult> sendQuery(SendTicketQueryRequestDto request)
        {
            return Ok(await _ticketApplication.SendTicketQuery(request));
        }
        [HttpGet()]
        [Route("report")]
        public async Task<IActionResult> Report()
        {
            var result = await _ticketApplication.DownloadReport();
            return File(result.Data, "application/vnd.ms-excel", "ReporteTickets" + DateTime.Now.ToString("ddMMyyyy") + ".xls");
        }

        [HttpPost()]
        [Route("saveTicketPreassignations")]
        public async Task<ActionResult> saveTicketAssignations(List<SavePreAsignTicketDto> list)
        {
            return Ok(await _ticketApplication.SavePreAsignTicket(list));
        }
        [HttpPost()]
        [Route("sendTicketPreassignations")]
        public async Task<ActionResult> sendTicketPreassignations(List<SavePreAsignTicketDto> list)
        {
            return Ok(await _ticketApplication.SendPreAsignTicket(list));
        }
        [HttpGet()]
        [Route("getTicketPreassignToUser")]
        public async Task<ActionResult> getTicketPreassignToUser(string userTo)
        {
            return Ok(await _ticketApplication.GetTicketsToUser(userTo));
        }
        [HttpPost()]
        [Route("deleteTicketComplement")]
        public async Task<ActionResult> deleteTicketComplement(int idTicket)
        {
            return Ok(await _ticketApplication.deleteTicketComplement(idTicket));
        }
        [HttpGet()]
        [Route("deleteTicketHistory")]
        public async Task<ActionResult> deleteTicketHistory(int idTicket, string? assignedTo, int? numberAssign, string? returnMessage)
        {
            return Ok(await _ticketApplication.DeleteTicketHistory(idTicket,assignedTo,numberAssign, returnMessage));
        }
        [HttpGet()]
        [Route("getPersonalAssignation")]
        public async Task<ActionResult> GetPersonalAssignation()
        {
            return Ok(await _ticketApplication.GetPersonalAssignation());
        }
        [HttpGet()]
        [Route("getCountAsignation")]
        public async Task<ActionResult> getCountAsignation()
        {
            return Ok(await _ticketApplication.getCountAsignation());
        }
        [HttpGet()]
        [Route("getAgentAssignation")]
        public async Task<ActionResult> getAgentAssignation()
        {
            return Ok(await _ticketApplication.GetAgentAssignation());
        }
        [HttpGet()]
        [Route("getTicketObservations")]
        public async Task<ActionResult> GetTicketObservations(int idTicket)
        {
            return Ok(await _ticketApplication.GetTicketObservations(idTicket));
        }
        [HttpPost()]
        [Route("addTicketObservations")]
        public async Task<ActionResult> addTicketObservations(int idTicket, string indications, string userFrom)
        {
            indications ??= string.Empty;
            userFrom ??= string.Empty;
            return Ok(await _ticketApplication.AddTicketObservations(idTicket,indications,userFrom));
        }
        [HttpPost()]
        [Route("uploadFile")]
        public async Task<ActionResult> uploadFile(int idTicket, string numCupon, IFormFile file)
        {
            return Ok(await _ticketApplication.UploadFile(idTicket, numCupon, file));
        }
        [HttpGet()]
        [Route("getFilesByIdTicket")]
        public async Task<ActionResult> getFilesByIdTicket(int idTicket)
        {
            return Ok(await _ticketApplication.GetTicketFilesByIdTicket(idTicket));
        }
        [HttpGet()]
        [Route("DownloadFileById")]
        public async Task<ActionResult> getFileByPath(int id)
        {
            var result = await _ticketApplication.DownloadFileById(id);

            if (result != null && result.Data != null)
            {
                return File(result.Data.File?.ToArray(), result.Data.ContentType, result.Data.FileName);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet()]
        [Route("DeleteFile")]
        public async Task<ActionResult> DeleteFile(int id)
        {
            return Ok(await _ticketApplication.DeleteFile(id));
        }
        [HttpPost()]
        [Route("assignTicket")]
        public async Task<ActionResult> AssignTicket(NewAsignationDto obj)
        {
            return Ok(await _ticketApplication.AssignTicket(obj));
        }
        [HttpGet()]
        [Route("providerByIdTicket")]
        public async Task<ActionResult> providerByIdTicket(int idTicket)
        {
            return Ok(await _ticketApplication.GetProvidersByIdTicket(idTicket));
        }
        [HttpGet()]
        [Route("providerHistoryByIdTicket")]
        public async Task<ActionResult> providerHistoryByIdTicket(int idTicket)
        {
            return Ok(await _ticketApplication.GetProvidersHistoryByIdTicket(idTicket));
        }
        [HttpPost()]
        [Route("finishWork")]
        public async Task<ActionResult> FinishWork(AssignTicketRequestDto obj)
        {
            return Ok(await _ticketApplication.FinishWork(obj));
        }
        [HttpPost()]
        [Route("FinishWorkById")]
        public async Task<ActionResult> FinishWorkById(int idTicketHistory)
        {
            return Ok(await _ticketApplication.FinishWorkById(idTicketHistory));
        }
        [HttpGet()]
        [Route("GetEmployeesAssignated")]
        public async Task<ActionResult> GetEmployeesAssignatedToTicket(int idTicket)
        {
            return Ok(await _ticketApplication.GetEmployeesAssignatedToTicket(idTicket));
        }
        
        [HttpGet()]
        [Route("GetTicketPendingObservations")]
        public async Task<ActionResult> GetTicketPendingObservations(int idTicket)
        {
            return Ok(await _ticketApplication.GetTicketPendingObservations(idTicket));
        }
        [HttpPost()]
        [Route("AddOrUpdateTicketPendingObservations")]
        public async Task<ActionResult> AddOrUpdateTicketPendingObservations(AddOrUpdateTicketPendingObservationsResponseDto obj)
        {
            return Ok(await _ticketApplication.AddOrUpdateTicketPendingObservations(obj));
        }
        
        [HttpPost()]
        [Route("FinishTicketObservation")]
        public async Task<ActionResult> FinishTicketObservation(int idTicketObservation, string? conclusion, bool dr, bool ag, bool cl)
        {
            return Ok(await _ticketApplication.FinishTicketObservation(idTicketObservation,conclusion,dr,ag,cl));
        }

        [HttpGet()]
        [Route("GetOtherUserCode")]
        public async Task<ActionResult> GetOtherUserCode(int idUser)
        {
            return Ok(await _ticketApplication.GetOtherUserCode(idUser));
        }
        [HttpGet()]
        [Route("GetSupervisorTicket")]
        public async Task<ActionResult> GetSupervisorTicket(int idTicket)
        {
            return Ok(await _ticketApplication.GetSupervisorTicket(idTicket));
        }
        [HttpGet()]
        [Route("GetSupervisorCodeTicket")]
        public async Task<ActionResult> GetSupervisorCodeTicket(int idTicket)
        {
            return Ok(await _ticketApplication.GetSupervisorCodeTicket(idTicket));
        }
        [HttpGet()]
        [Route("DownloadZipByIdTicket")]
        public async Task<ActionResult> DownloadZipByIdTicket(int idTicket)
        {
            var result = await _ticketApplication.DownloadZipByIdTicket(idTicket);

            if (result != null && result.Data != null)
            {
                return File(result.Data.File?.ToArray(), result.Data.ContentType, result.Data.FileName);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet()]
        [Route("SendComplement")]
        public async Task<ActionResult> SendComplement(int idTicket, int idUser, bool digited, bool file, string observations, string asignedTo)
        {
            return Ok(await _ticketApplication.SendComplement(idTicket, idUser , digited, file, observations, asignedTo));
        }
        [HttpPost()]
        [Route("SaveTicketCommentary")]
        public async Task<ActionResult> SaveTicketCommentary(int idTicket, string commentary)
        {
            return Ok(await _ticketApplication.SaveTicketCommentary(idTicket, commentary));
        }
        [HttpGet()]
        [Route("DownloadF8ByIdTicket")]
        public async Task<IActionResult> DownloadF8ByIdTicket(int idTicket, string language, string format)
        {
            var result = await _ticketApplication.DownloadF8ByIdTicket(idTicket, language, format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet()]
        [Route("GetNumerationRefCom")]
        public async Task<IActionResult> GetNumerationRefCom()
        {
            return Ok(await _ticketApplication.GetNumerationRefCom());
        }

        [HttpPost()]
        [Route("SendComplementRefCom")]
        public async Task<IActionResult> SendComplementRefCom(int idUser, int idTicket, string asignedTo, string numOrder, string message)
        {
            return Ok(await _ticketApplication.SendComplementRefCom(idUser, idTicket, asignedTo, numOrder, message));
        }
        [HttpPost()]
        [Route("ConfirmAgentHistory")]
        public async Task<IActionResult> ConfirmAgentHistory( int idTicketHistory)
        {
            return Ok(await _ticketApplication.ConfirmAgentHistory(idTicketHistory));
        }
        [HttpGet()]
        [Route("GetTicketAssignedValidation")]
        public async Task<IActionResult> GetTicketAssignedValidation(int idTicket)
        {
            return Ok(await _ticketApplication.GetTicketAssignedValidation(idTicket));
        }
        [HttpPost()]
        [Route("ValidateQuality")]
        public async Task<IActionResult> ValidateQuality(int idTicket)
        {
            return Ok(await _ticketApplication.ValidateQuality(idTicket));
        }
        [HttpGet()]
        [Route("GetTicketObservedByIdEmployee")]
        public async Task<IActionResult> GetTicketObservedByIdEmployee(int idEmployee)
        {
            return Ok(await _ticketApplication.GetTicketObservedByIdEmployee(idEmployee));
        }
        [HttpPost()]
        [Route("TicketToDispatchById")]
        public async Task<IActionResult> TicketToDispatchById(int idTicket, bool hasObs)
        {
            return Ok(await _ticketApplication.TicketToDispatchById(idTicket, hasObs));
        }
        [HttpGet()]
        [Route("GetTicketToDelete")]
        public async Task<IActionResult> GetTicketToDelete(int? cupon,string? name)
        {
            return Ok(await _ticketApplication.GetTicketToDelete(cupon??0,name??string.Empty));
        }
        [HttpGet()]
        [Route("GetTicketHistoryToDelete")]
        public async Task<IActionResult> GetTicketHistoryToDelete(int idTicket)
        {
            return Ok(await _ticketApplication.GetTicketHistoryToDelete(idTicket));
        }
        [HttpPost()]
        [Route("AnluarTicketHistory")]
        public async Task<IActionResult> DeleteTicketHistory(int idTicketHistory)
        {
            return Ok(await _ticketApplication.DeleteTicketHistory(idTicketHistory));
        }
        [HttpPost()]
        [Route("AnularTicket")]
        public async Task<IActionResult> DeleteTicketHistory(int idTicket,int reason)
        {
            return Ok(await _ticketApplication.DeleteTicketHistory(idTicket,reason));
        }
    }
}
