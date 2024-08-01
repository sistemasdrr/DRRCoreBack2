using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Application.Main.CoreApplication;
using Microsoft.AspNetCore.Mvc;

namespace DRRCore.Services.ApiCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChartController : Controller
    {
        private readonly IChartApplication _chartApplication;
        public ChartController(IChartApplication chartApplication)
        {
            _chartApplication = chartApplication;
        }

        [HttpGet]
        [Route("GetChart5_1_1")]
        public async Task<ActionResult> GetChart5_1_1(string startDate, string endDate)
        {
            return Ok(await _chartApplication.GetChart5_1_1(startDate, endDate));
        }
        [HttpGet]
        [Route("GetChart5_1_2")]
        public async Task<ActionResult> GetChart5_1_2(string startDate, string endDate)
        {
            return Ok(await _chartApplication.GetChart5_1_2(startDate, endDate));
        }
        [HttpGet]
        [Route("GetChart5_1_3")]
        public async Task<ActionResult> GetChart5_1_3(int month, int year)
        {
            return Ok(await _chartApplication.GetChart5_1_3(month, year));
        }
        [HttpGet]
        [Route("DownloadReport5_1_3")]
        public async Task<ActionResult> DownloadReport5_1_3(string format, int month, int year)
        {
            var result = await _chartApplication.DownloadReport5_1_3(format, month, year);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("GetChart5_1_4")]
        public async Task<ActionResult> GetChart5_1_4(int month, int year)
        {
            return Ok(await _chartApplication.GetChart5_1_4(month, year));
        }
        [HttpGet]
        [Route("GetChart5_1_5")]
        public async Task<ActionResult> GetChart5_1_5()
        {
            return Ok(await _chartApplication.GetChart5_1_5());
        }
        [HttpGet]
        [Route("DownloadReport5_1_5")]
        public async Task<ActionResult> DownloadReport5_1_5(string format)
        {
            var result = await _chartApplication.DownloadReport5_1_5(format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("GetChart5_1_6")]
        public async Task<ActionResult> GetChart5_1_6(int month, int year)
        {
            return Ok(await _chartApplication.GetChart5_1_6(month, year));
        }
        [HttpGet]
        [Route("DownloadReport5_1_7")]
        public async Task<ActionResult> DownloadReport5_1_7(string format, string orderBy)
        {
            var result = await _chartApplication.DownloadReport5_1_7(format, orderBy);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("GetChart5_1_26")]
        public async Task<ActionResult> GetChart5_1_26(int idCountry)
        {
            return Ok(await _chartApplication.GetChart5_1_26(idCountry));
        }
    }
}
