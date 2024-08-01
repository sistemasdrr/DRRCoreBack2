using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Application.Main.CoreApplication;
using DRRCore.Domain.Entities.SqlCoreContext;
using Microsoft.AspNetCore.Mvc;

namespace DRRCore.Services.ApiCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QueryController : Controller
    {
        private readonly IQueryApplication _queryApplication;
        public QueryController(IQueryApplication queryApplication)
        {
            _queryApplication = queryApplication;
        }

        [HttpGet]
        [Route("GetQuery1_1ByYear")]
        public async Task<ActionResult> GetQuery1_1ByYear(int year)
        {
            return Ok(await _queryApplication.GetQuery1_1ByYear(year));
        }
        [HttpGet]
        [Route("GetQuery1_1ByMonth")]
        public async Task<ActionResult> GetQuery1_1ByMonth(int year, int month, int idSubscriber)
        {
            return Ok(await _queryApplication.GetQuery1_1ByMonth(year, month, idSubscriber));
        }
        [HttpGet]
        [Route("GetQuery1_2ByYear")]
        public async Task<ActionResult> GetQuery1_2ByYear(int year)
        {
            return Ok(await _queryApplication.GetQuery1_2ByYear(year));
        }
        [HttpGet]
        [Route("GetQuery1_3BySubscriber")]
        public async Task<ActionResult> GetQuery1_3BySubscriber(int idSubscriber, int year)
        {
            return Ok(await _queryApplication.GetQuery1_3BySubscriber(idSubscriber,year));
        }
        [HttpGet]
        [Route("GetQuery1_4Subscribers")] 
        public async Task<ActionResult> GetQuery1_4Subscribers()
        {
            return Ok(await _queryApplication.GetQuery1_4Subscribers());
        }
        [HttpGet]
        [Route("GetQuery1_4")] 
        public async Task<ActionResult> GetQuery1_4(int idSubscriber, int year)
        {
            return Ok(await _queryApplication.GetQuery1_4(idSubscriber, year));
        }
        [HttpGet]
        [Route("GetQuery1_5")]
        public async Task<ActionResult> GetQuery1_5(string startDate, string endDate)
        {
            return Ok(await _queryApplication.GetQuery1_5(startDate, endDate));
        }
        [HttpGet]
        [Route("GetQuery1_6")]
        public async Task<ActionResult> GetQuery1_6()
        {
            return Ok(await _queryApplication.GetQuery1_6());
        }
        [HttpGet]
        [Route("GetQuery1_6BySubscriber")]
        public async Task<ActionResult> GetQuery1_6BySubscriber()
        {
            return Ok(await _queryApplication.GetQuery1_6BySubscriber());
        }
        [HttpGet]
        [Route("GetQuery1_7Subscriber")]
        public async Task<ActionResult> GetQuery1_7Subscriber()
        {
            return Ok(await _queryApplication.GetQuery1_7Subscriber());
        }
        [HttpGet]
        [Route("GetQuery1_7Tickets")]
        public async Task<ActionResult> GetQuery1_7Tickets(int year, int month, int idSubscriber)
        {
            return Ok(await _queryApplication.GetQuery1_7Tickets(year, month, idSubscriber));
        }
        [HttpGet]
        [Route("GetQuery1_8")]
        public async Task<ActionResult> GetQuery1_8(int year, int month)
        {
            return Ok(await _queryApplication.GetQuery1_8(year, month));
        }
        [HttpGet]
        [Route("GetQuery1_9")]
        public async Task<ActionResult> GetQuery1_9(int year, int month)
        {
            return Ok(await _queryApplication.GetQuery1_9(year, month));
        }
        [HttpGet]
        [Route("GetQuery1_10")]
        public async Task<ActionResult> GetQuery1_10(int idSubscriber, string startDate, string endDate)
        {
            return Ok(await _queryApplication.GetQuery1_10(idSubscriber, startDate, endDate));
        }
        [HttpGet]
        [Route("GetQuery1_11Subscriber")]
        public async Task<ActionResult> GetQuery1_11Subscriber(int year)
        {
            return Ok(await _queryApplication.GetQuery1_11Subscriber(year));
        }
        [HttpGet]
        [Route("GetQuery1_11BySubscriber")] 
        public async Task<ActionResult> GetQuery1_11BySubscriber(int idSubscriber, int year, int month)
        {
            return Ok(await _queryApplication.GetQuery1_11BySubscriber(idSubscriber, year, month));
        }
        [HttpGet]
        [Route("GetReporters")] 
        public async Task<ActionResult> GetReporters()
        {
            return Ok(await _queryApplication.GetReporters());
        }
        [HttpGet]
        [Route("GetQuery2_1ByYear")] 
        public async Task<ActionResult> GetQuery2_1ByYear(int year)
        {
            return Ok(await _queryApplication.GetQuery2_1ByYear(year));
        }
        [HttpGet]
        [Route("GetQuery2_1ByMonth")] 
        public async Task<ActionResult> GetQuery2_1ByMonth(int year, int month, string asignedTo)
        {
            return Ok(await _queryApplication.GetQuery2_1ByMonth(year, month, asignedTo));
        }
        [HttpGet]
        [Route("GetQuery2_2ByYear")]
        public async Task<ActionResult> GetQuery2_2ByYear(int year, string asignedTo)
        {
            return Ok(await _queryApplication.GetQuery2_2ByYear(year, asignedTo));
        }
        [HttpGet]
        [Route("GetQuery3_1ByYear")]
        public async Task<ActionResult> GetQuery3_1ByYear(int year)
        {
            return Ok(await _queryApplication.GetQuery3_1ByYear(year));
        }
        [HttpGet]
        [Route("GetQuery3_1ByMonth")] 
        public async Task<ActionResult> GetQuery3_1ByMonth(string asignedTo, int year, int month)
        {
            return Ok(await _queryApplication.GetQuery3_1ByMonth(asignedTo, year, month));
        }
        [HttpGet]
        [Route("GetQuery4_1_1")] 
        public async Task<ActionResult> GetQuery4_1_1()
        {
            return Ok(await _queryApplication.GetQuery4_1_1());
        }
        [HttpGet]
        [Route("SendMailQuery4_1_1_Fact_ByBill")]
        public async Task<ActionResult> SendMailQuery4_1_1_Fact_ByBill(string to, int idSubscriber, int idUser)
        {
            return Ok(await _queryApplication.SendMailQuery4_1_1_Fact_ByBill(to, idSubscriber, idUser));
        }
        [HttpGet]
        [Route("DownloadQuery_Fact_4_1_1")]
        public async Task<ActionResult> DownloadQuery_Fact_4_1_1(string format)
        {
            var result = await _queryApplication.DownloadQuery_Fact_4_1_1(format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("GetQuery4_1_2")]
        public async Task<ActionResult> GetQuery4_1_2()
        {
            return Ok(await _queryApplication.GetQuery4_1_2());
        }
        [HttpGet]
        [Route("DownloadQuery_Fact_4_1_2")]
        public async Task<ActionResult> DownloadQuery_Fact_4_1_2(string format)
        {
            var result = await _queryApplication.DownloadQuery_Fact_4_1_2(format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }

        [HttpGet]
        [Route("GetQuery4_1_3")]
        public async Task<ActionResult> GetQuery4_1_3(string startDate, string endDate)
        {
            return Ok(await _queryApplication.GetQuery4_1_3(startDate, endDate));
        }
        [HttpGet]
        [Route("DownloadQuery_Fact_4_1_3")]
        public async Task<ActionResult> DownloadQuery_Fact_4_1_3(string format, string startDate, string endDate)
        {
            var result = await _queryApplication.DownloadQuery_Fact_4_1_3(format, startDate, endDate);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("GetQuery4_1_4")]
        public async Task<ActionResult> GetQuery4_1_4(int month, int year)
        {
            return Ok(await _queryApplication.GetQuery4_1_4(month, year));
        }
        [HttpGet]
        [Route("DownloadQuery_Fact_4_1_4")]
        public async Task<ActionResult> DownloadQuery_Fact_4_1_4(string format, int month, int year)
        {
            var result = await _queryApplication.DownloadQuery_Fact_4_1_4(format, month, year);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadQuery_Fact_4_1_5")]
        public async Task<ActionResult> DownloadQuery_Fact_4_1_5(string format, string orderBy,int month, int year)
        {
            var result = await _queryApplication.DownloadQuery_Fact_4_1_5(format, orderBy, month, year);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("GetQuery4_2_1")]
        public async Task<ActionResult> GetQuery4_2_1()
        {
            return Ok(await _queryApplication.GetQuery4_2_1());
        }
        [HttpGet]
        [Route("DownloadQuery_Fact_4_2_1")]
        public async Task<ActionResult> DownloadQuery_Fact_4_2_1(string format)
        {
            var result = await _queryApplication.DownloadQuery_Fact_4_2_1(format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("GetQuery4_2_2")]
        public async Task<ActionResult> GetQuery4_2_2(string startDate, string endDate)
        {
            return Ok(await _queryApplication.GetQuery4_2_2(startDate,endDate));
        }
        [HttpGet]
        [Route("DownloadQuery_Fact_4_2_2")]
        public async Task<ActionResult> DownloadQuery_Fact_4_2_2(string format, string startDate, string endDate)
        {
            var result = await _queryApplication.DownloadQuery_Fact_4_2_2(format, startDate, endDate);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("GetQuery5_1_1")]
        public async Task<ActionResult> GetQuery5_1_1()
        {
            return Ok(await _queryApplication.GetQuery5_1_1());
        }

        [HttpGet]
        [Route("SendTicketAlert")]
        public async Task<ActionResult> SendTicketAlert(int idTicket, int idUser)
        {
            return Ok(await _queryApplication.SendTicketAlert(idTicket, idUser));
        }
        [HttpGet]
        [Route("GetQuery5_1_2")]
        public async Task<ActionResult> GetQuery5_1_2(string idUser)
        {
            return Ok(await _queryApplication.GetQuery5_1_2(idUser));
        }
        [HttpGet]
        [Route("GetQuery5_1_2Daily")]
        public async Task<ActionResult> GetQuery5_1_2Daily(string idUser)
        {
            return Ok(await _queryApplication.GetQuery5_1_2Daily(idUser));
        }
        [HttpGet]
        [Route("GetQuery5_1_2Monthly")]
        public async Task<ActionResult> GetQuery5_1_2Monthly(string idUser, int month)
        {
            return Ok(await _queryApplication.GetQuery5_1_2Monthly(idUser, month));
        }
    }
}
