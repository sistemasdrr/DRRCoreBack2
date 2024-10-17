using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Application.Main.CoreApplication;
using Microsoft.AspNetCore.Mvc;

namespace DRRCore.Services.ApiCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        private readonly IReportApplication _reportApplication;
        public ReportController(IReportApplication reportApplication)
        {
            _reportApplication = reportApplication;
        }


        [HttpGet]
        [Route("DownloadReport6_1_5")]
        public async Task<ActionResult> DownloadReport6_1_5(int idSubscriber, string format)
        {
            var result = await _reportApplication.DownloadReport6_1_5(idSubscriber, format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_1_7")]
        public async Task<ActionResult> DownloadReport6_1_7(string orderBy, string format)
        {
            var result = await _reportApplication.DownloadReport6_1_7(orderBy, format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_1_14")]
        public async Task<ActionResult> DownloadReport6_1_14(string type, string format)
        {
            var result = await _reportApplication.DownloadReport6_1_14(type, format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_1_15")]
        public async Task<ActionResult> DownloadReport6_1_15(int idCountry, string format)
        {
            var result = await _reportApplication.DownloadReport6_1_15(idCountry, format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_1_18")]
        public async Task<ActionResult> DownloadReport6_1_18(int idCountry, int year, string format)
        {
            var result = await _reportApplication.DownloadReport6_1_18(idCountry, year, format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_1_19_1")]
        public async Task<ActionResult> DownloadReport6_1_19_1(int month, int year, string format)
        {
            var result = await _reportApplication.DownloadReport6_1_19_1(month, year, format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_1_19_2")]
        public async Task<ActionResult> DownloadReport6_1_19_2(int month, int year, string format)
        {
            var result = await _reportApplication.DownloadReport6_1_19_2(month, year, format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }

        [HttpGet]
        [Route("DownloadReport6_1_20")]
        public async Task<ActionResult> DownloadReport6_1_20(int month, int year, string format)
        {
            var result = await _reportApplication.DownloadReport6_1_20(month, year, format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_1_21")]
        public async Task<ActionResult> DownloadReport6_1_21(int month, int year, string orderBy, string format)
        {
            var result = await _reportApplication.DownloadReport6_1_21(month, year, orderBy, format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_1_22")]
        public async Task<ActionResult> DownloadReport6_1_21(int year, string orderBy, string format)
        {
            var result = await _reportApplication.DownloadReport6_1_22( year, orderBy, format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_1_25")]
        public async Task<ActionResult> DownloadReport6_1_25(string format)
        {
            var result = await _reportApplication.DownloadReport6_1_25(format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
    }
}
