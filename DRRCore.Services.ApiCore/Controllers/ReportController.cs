﻿using DRRCore.Application.Interfaces.CoreApplication;
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
            var result = await _reportApplication.DownloadReport6_1_22(year, orderBy, format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_1_25")]
        public async Task<ActionResult> DownloadReport6_1_25(string format)
        {
            var result = await _reportApplication.DownloadReport6_1_25(format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_2_1")]
        public async Task<ActionResult> DownloadReport6_2_1(string startDate, string endDate, string code, string format)
        {
            var result = await _reportApplication.DownloadReport6_2_1(startDate, endDate, code, format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_2_2")]
        public async Task<ActionResult> DownloadReport6_2_2(string code, string format)
        {
            var result = await _reportApplication.DownloadReport6_2_2(code, format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_2_3")]
        public async Task<ActionResult> DownloadReport6_2_3(string cycle, string code, string format)
        {
            var result = await _reportApplication.DownloadReport6_2_3(cycle, code, format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_2_4")]
        public async Task<ActionResult> DownloadReport6_2_4(int month, int year, string orderBy, string format)
        {
            var result = await _reportApplication.DownloadReport6_2_4(month, year, orderBy, format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport_Realizado_Pendiente")]
        public async Task<ActionResult> DownloadReport_Realizado_Pendiente(int month, int year, string type, string format)
        {
            var result = await _reportApplication.DownloadReport_Realizado_Pendiente(month, year, type, format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_3_1")]
        public async Task<ActionResult> DownloadReport6_3_1(string startDate, string endDate, string code, string format)
        {
            var result = await _reportApplication.DownloadReport6_3_10(startDate, endDate, code, format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_3_2")]
        public async Task<ActionResult> DownloadReport6_3_2(string code, string format)
        {
            var result = await _reportApplication.DownloadReport6_3_20(code, format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_3_3")]
        public async Task<ActionResult> DownloadReport6_3_3(string startDate, string endDate, string code, string format)
        {
            var result = await _reportApplication.DownloadReport6_3_30(startDate, endDate, code, format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_3_4")]
        public async Task<ActionResult> DownloadReport6_3_4(int month, int year, string orderBy, string format)
        {
            var result = await _reportApplication.DownloadReport6_3_40(month, year, orderBy, format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_3_5")]
        public async Task<ActionResult> DownloadReport6_3_5(string format)
        {
            var result = await _reportApplication.DownloadReport6_3_5(format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_3_6")]
        public async Task<ActionResult> DownloadReport6_3_6(string code, int year, string format)
        {
            var result = await _reportApplication.DownloadReport6_3_6(code, year, format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_3_7")]
        public async Task<ActionResult> DownloadReport6_3_7(string code, int month, int year, string format)
        {
            var result = await _reportApplication.DownloadReport6_3_7(code, month, year, format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_3_8")]
        public async Task<ActionResult> DownloadReport6_3_8(string type, int year, string format)
        {
            var result = await _reportApplication.DownloadReport6_3_8(type, year, format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_3_11")]
        public async Task<ActionResult> DownloadReport6_3_11(string code, int year, string format)
        {
            var result = await _reportApplication.DownloadReport6_3_11(code, year, format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_3_0")]
        public async Task<ActionResult> DownloadReport6_3_0(string format)
        {
            var result = await _reportApplication.DownloadReport6_3_1(format);

            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }

        [HttpGet]
        [Route("DownloadReport6_4_1")]
        public async Task<ActionResult> DownloadReport6_4_1(string startDate, string endDate, string code, string format)
        {
            var result = await _reportApplication.DownloadReport6_4_1(startDate, endDate, code, format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_4_2")]
        public async Task<ActionResult> DownloadReport6_4_2(string code, string format)
        {
            var result = await _reportApplication.DownloadReport6_4_2(code, format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_4_3")]
        public async Task<ActionResult> DownloadReport6_4_3(string cycle, string code, string format)
        {
            var result = await _reportApplication.DownloadReport6_4_3(cycle, code, format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_4_4")]
        public async Task<ActionResult> DownloadReport6_4_4(int month, int year, string orderBy, string format)
        {
            var result = await _reportApplication.DownloadReport6_4_4(month, year, orderBy, format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }

        [HttpGet]
        [Route("DownloadReport6_5_1")]
        public async Task<ActionResult> DownloadReport6_5_1(string startDate, string endDate, string code, string format)
        {
            var result = await _reportApplication.DownloadReport6_5_1(startDate, endDate, code, format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_5_2")]
        public async Task<ActionResult> DownloadReport6_5_2(string code, string format)
        {
            var result = await _reportApplication.DownloadReport6_5_2(code, format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_5_3")]
        public async Task<ActionResult> DownloadReport6_5_3(string cycle, string code, string format)
        {
            var result = await _reportApplication.DownloadReport6_5_3(cycle, code, format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_5_4")]
        public async Task<ActionResult> DownloadReport6_5_4(int month, int year, string orderBy, string format)
        {
            var result = await _reportApplication.DownloadReport6_5_4(month, year, orderBy, format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_6_1")]
        public async Task<ActionResult> DownloadReport6_6_1(string code, string format)
        {
            var result = await _reportApplication.DownloadReport6_6_1(code, format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport5_1_2")]
        public async Task<ActionResult> DownloadReport5_1_2(int year, string format)
        {
            var result = await _reportApplication.DownloadReport5_1_2(year, format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_1_7Ger")]
        public async Task<ActionResult> DownloadReport6_1_7(string orderBy, string type, string format)
        {
            var result = await _reportApplication.DownloadReport6_1_7(orderBy, type, format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadListToCollect")]
        public async Task<ActionResult> DownloadListToCollect(string invoiceCode)
        {
            var result = await _reportApplication.DownloadListToCollect(invoiceCode);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport6_3_10")]
        public async Task<ActionResult> DownloadReport6_3_10(string code, int year, string format)
        {
            var result = await _reportApplication.DownloadReport6_3_100(code, year, format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }

        [HttpGet]
        [Route("DownloadReport7_1")]
        public async Task<ActionResult> DownloadReport7_1(int start, int end, string format)
        {
            var result = await _reportApplication.DownloadReport7_1(start, end, format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport7_3")]
        public async Task<ActionResult> DownloadReport7_3(int year, string code, string format)
        {
            var result = await _reportApplication.DownloadReport7_3(year, code, format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport7_4")]
        public async Task<ActionResult> DownloadReport7_4(int year, string format)
        {
            var result = await _reportApplication.DownloadReport7_4(year, format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport7_5_1")]
        public async Task<ActionResult> DownloadReport7_5_1(int month, int year, string format)
        {
            var result = await _reportApplication.DownloadReport7_5_1(month, year, format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport7_5_2")]
        public async Task<ActionResult> DownloadReport7_5_2(int month, int year, string code, string format)
        {
            var result = await _reportApplication.DownloadReport7_5_2(month, year, code, format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport7_5_3")]
        public async Task<ActionResult> DownloadReport7_5_3(int year, string format)
        {
            var result = await _reportApplication.DownloadReport7_5_3(year, format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport7_5_4")]
        public async Task<ActionResult> DownloadReport7_5_4(int year, string format)
        {
            var result = await _reportApplication.DownloadReport7_5_4(year, format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport7_10_1")]
        public async Task<ActionResult> DownloadReport7_10_1(int number, string format)
        {
            var result = await _reportApplication.DownloadReport7_10_1(number, format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("GetReport7_10_1")]
        public async Task<ActionResult> GetReport7_10_1(int number)
        {

            return Ok(await _reportApplication.GetReport7_10_1(number));
        }
        [HttpGet]
        [Route("DownloadReport7_10_2")]
        public async Task<ActionResult> DownloadReport7_10_2(int id, string about, string format)
        {
            var result = await _reportApplication.DownloadReport7_10_2(id, about, format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("GetReport7_10_2")]
        public async Task<ActionResult> GetReport7_10_2(int id, string about)
        {

            return Ok(await _reportApplication.GetReport7_10_2(id, about));
        }
        [HttpGet]
        [Route("DownloadReport7_11")]
        public async Task<ActionResult> DownloadReport7_11(int year, string code, string format)
        {
            var result = await _reportApplication.DownloadReport7_11(year, code, format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport7_12_1")]
        public async Task<ActionResult> DownloadReport7_12_1(int month, int year, string code, string format)
        {
            var result = await _reportApplication.DownloadReport7_12_1(month, year, code, format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport7_12_2")]
        public async Task<ActionResult> DownloadReport7_12_2(int year, string code, string format)
        {
            var result = await _reportApplication.DownloadReport7_12_2(year, code, format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport7_13_1")]
        public async Task<ActionResult> DownloadReport7_13_1(int month, int year, string code, string format)
        {
            var result = await _reportApplication.DownloadReport7_13_1(month, year, code, format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport7_13_2")]
        public async Task<ActionResult> DownloadReport7_13_2(int year, string code, string format)
        {
            var result = await _reportApplication.DownloadReport7_13_2(year, code, format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
        [HttpGet]
        [Route("DownloadReport7_15")]
        public async Task<ActionResult> DownloadReport7_15(string format)
        {
            var result = await _reportApplication.DownloadReport7_15(format);
            return File(result.Data.File, result.Data.ContentType, result.Data.Name);
        }
    }
}
