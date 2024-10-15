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
    }
}
