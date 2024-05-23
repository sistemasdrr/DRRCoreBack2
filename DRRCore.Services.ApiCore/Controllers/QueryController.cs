using DRRCore.Application.Interfaces.CoreApplication;
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
        public async Task<ActionResult> GetQuery1_1ByMonth(int month, int idSubscriber)
        {
            return Ok(await _queryApplication.GetQuery1_1ByMonth(month, idSubscriber));
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
    }
}
