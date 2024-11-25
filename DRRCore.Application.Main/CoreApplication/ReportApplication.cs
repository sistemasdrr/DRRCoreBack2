using AutoMapper;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Wordprocessing;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509;

namespace DRRCore.Application.Main.CoreApplication
{
    public class ReportApplication : IReportApplication
    {
        private readonly ILogger _logger;
        private IMapper _mapper;
        private readonly IReportingDownload _reportingDownload;
        public ReportApplication(ILogger logger, IMapper mapper, IReportingDownload reportingDownload)
        {
            _logger = logger;
            _mapper = mapper;
            _reportingDownload = reportingDownload;

        }
        public async Task<Response<GetFileResponseDto>> DownloadReport6_1_5(int idSubscriber, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/ABONADOS/REPORTES_ABONADO_6.1.5";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "idSubscriber", idSubscriber.ToString() }
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_ABONADO_6.1.5", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetFileResponseDto>> DownloadReport6_1_7(string orderBy, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/ABONADOS/REPORTES_ABONADO_6.1.7";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "orderBy", orderBy.ToString() }
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_ABONADO_6.1.7", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport6_1_14(string type, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/ABONADOS/REPORTES_ABONADO_6.1.14";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "type", type }
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_ABONADO_6.1.14", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetFileResponseDto>> DownloadReport6_1_15(int idCountry, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/ABONADOS/REPORTES_ABONADO_6.1.15";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "idCountry", idCountry.ToString() }
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_ABONADO_6.1.15", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport6_1_18(int idCountry, int year, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/ABONADOS/REPORTES_ABONADO_6.1.18";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "idCountry", idCountry.ToString() },
                    { "year", year.ToString() }
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_ABONADO_6.1.18", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport6_1_19_1(int month, int year, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/ABONADOS/REPORTES_ABONADO_6.1.19.1";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "month", month.ToString() },
                    { "year", year.ToString() }
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_ABONADO_6.1.19.1", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport6_1_19_2(int month, int year, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/ABONADOS/REPORTES_ABONADO_6.1.19.2";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "month", month.ToString() },
                    { "year", year.ToString() }
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_ABONADO_6.1.19.2", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport6_1_20(int month, int year, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/ABONADOS/REPORTES_ABONADO_6.1.20";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "month", month.ToString() },
                    { "year", year.ToString() }
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_ABONADO_6.1.20", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport6_1_21(int month, int year, string orderBy, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/ABONADOS/REPORTES_ABONADO_6.1.21";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "month", month.ToString() },
                    { "year", year.ToString() },
                    { "orderBy", orderBy }
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_ABONADO_6.1.21", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport6_1_22(int year, string orderBy, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/ABONADOS/REPORTES_ABONADO_6.1.22";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "year", year.ToString() },
                    { "orderBy", orderBy }
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_ABONADO_6.1.22", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport6_1_25(string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/ABONADOS/REPORTES_ABONADO_6.1.25";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_ABONADO_6.1.25", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetFileResponseDto>> DownloadReport6_2_1(string startDate, string endDate, string code, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/REPORTEROS/REPORT_6.2.1";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "desde", startDate },
                    { "hasta", endDate },
                    { "code", code },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_6.2.1", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetFileResponseDto>> DownloadReport6_2_2(string code, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/REPORTEROS/REPORT_6.2.2";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "code", code },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_6.2.2", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetFileResponseDto>> DownloadReport6_2_3(string startDate, string endDate, string code, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                //string report = "REPORTES/REPORTEROS/REPORT_6.2.3";
                string report = "REPORTES/REPORTEROS/REPORT_6.2.3_NEW";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "desde", startDate },
                    { "hasta", endDate },
                    { "code", code },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_6.2.3", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetFileResponseDto>> DownloadReport6_2_4(int month, int year, string orderBy, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/REPORTEROS/REPORT_6.2.4";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "month", month.ToString() },
                    { "year", year.ToString() },
                    { "orderBy", orderBy },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_6.2.4", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport6_3_1(
           string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/AGENTES/REPORTES_AGENTES_1";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_6.3.1", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport6_3_5(string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/AGENTES/REPORT_6.3.5";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_6.3.5", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport6_3_6(string code, int year, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/AGENTES/REPORT_6.3.6";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "code", code },
                    { "year", year.ToString() },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_6.3.6", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport6_3_7(string code, int month, int year, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/AGENTES/REPORT_6.3.7";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "code", code },
                    { "month", month.ToString() },
                    { "year", year.ToString() },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_6.3.7", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport6_3_8(string type, int year, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/AGENTES/REPORT_6.3.8";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "type", type },
                    { "year", year.ToString() },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_6.3.8", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport6_3_11(string code, int year, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/AGENTES/REPORT_6.3.11";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "code", code },
                    { "year", year.ToString() },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_6.3.11", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport6_3_10(string startDate, string endDate, string code, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/AGENTES/REPORT_6.3.1";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "desde", startDate },
                    { "hasta", endDate },
                    { "code", code },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_6.3.1", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetFileResponseDto>> DownloadReport6_3_20(string code, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/AGENTES/REPORT_6.3.2";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "code", code },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_6.3.2", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetFileResponseDto>> DownloadReport6_3_30(string startDate, string endDate, string code, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/AGENTES/REPORT_6.3.3";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "desde", startDate },
                    { "hasta", endDate },
                    { "code", code },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_6.3.3", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetFileResponseDto>> DownloadReport6_3_40(int month, int year, string orderBy, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/AGENTES/REPORT_6.3.4";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "month", month.ToString() },
                    { "year", year.ToString() },
                    { "orderBy", orderBy },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_6.3.4", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport6_4_1(string startDate, string endDate, string code, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/DIGITADORES/REPORT_6.4.1";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "desde", startDate },
                    { "hasta", endDate },
                    { "code", code },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_6.4.1", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetFileResponseDto>> DownloadReport6_4_2(string code, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/DIGITADORES/REPORT_6.4.2";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "code", code },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_6.4.2", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetFileResponseDto>> DownloadReport6_4_3(string startDate, string endDate, string code, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                //string report = "REPORTES/DIGITADORES/REPORT_6.4.3";
                string report = "REPORTES/DIGITADORES/REPORT_6.4.3_NEW";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "desde", startDate },
                    { "hasta", endDate },
                    { "code", code },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_6.4.3", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetFileResponseDto>> DownloadReport6_4_4(int month, int year, string orderBy, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/DIGITADORES/REPORT_6.4.4";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "month", month.ToString() },
                    { "year", year.ToString() },
                    { "orderBy", orderBy },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_6.4.4", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetFileResponseDto>> DownloadReport6_5_1(string startDate, string endDate, string code, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/TRADUCTORES/REPORT_6.5.1";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "desde", startDate },
                    { "hasta", endDate },
                    { "code", code },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_6.5.1", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetFileResponseDto>> DownloadReport6_5_2(string code, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/TRADUCTORES/REPORT_6.5.2";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "code", code },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_6.5.2", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetFileResponseDto>> DownloadReport6_5_3(string startDate, string endDate, string code, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                //string report = "REPORTES/TRADUCTORES/REPORT_6.5.3";
                string report = "REPORTES/TRADUCTORES/REPORT_6.5.3_NEW";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "desde", startDate },
                    { "hasta", endDate },
                    { "code", code },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_6.5.3", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetFileResponseDto>> DownloadReport6_5_4(int month, int year, string orderBy, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/TRADUCTORES/REPORT_6.5.4";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "month", month.ToString() },
                    { "year", year.ToString() },
                    { "orderBy", orderBy },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_6.5.4", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport6_6_1(string code, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/SUPERVISOR/REPORT_6.6.1";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "code", code },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_6.6.1", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }


        public async Task<Response<GetFileResponseDto>> DownloadReport5_1_2(int year, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/GERENCIA/REPORT_5.1.2";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "year", year.ToString() },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_5.1.2", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetFileResponseDto>> DownloadReport6_1_7(string orderBy, string type, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/GERENCIA/REPORT_6.1.7";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "orderBy", orderBy },
                    { "type", type },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_6.1.7", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport6_3_100(string code, int year, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/GERENCIA/REPORT_6.3.10";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "code", code },
                    { "year", year.ToString() },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_6.3.10", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport7_1(int start, int end, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/GERENCIA/REPORT_7.1";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "start", start.ToString() },
                    { "end", end.ToString() },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_7.1", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport7_3(int year, string code, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/GERENCIA/REPORT_7.3";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "code", code },
                    { "year", year.ToString() },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_7.3", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport7_4(int year, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/GERENCIA/REPORT_7.4";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "year", year.ToString() },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_7.4", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport7_5_1(int month, int year, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/GERENCIA/REPORT_7.5.1";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "month", month.ToString() },
                    { "year", year.ToString() },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_7.5.1", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport7_5_2(int month, int year, string code, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/GERENCIA/REPORT_7.5.2";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "month", month.ToString() },
                    { "year", year.ToString() },
                    { "code", code },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_7.5.2", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport7_5_3(int year, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/GERENCIA/REPORT_7.5.3";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "year", year.ToString() },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_7.5.3", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetFileResponseDto>> DownloadReport7_5_4(int year, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/GERENCIA/REPORT_7.5.4";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "year", year.ToString() },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_7.5.4", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<List<Report7_10_1>>> GetReport7_10_1(int number)
        {
            var response = new Response<List<Report7_10_1>>();
            response.Data = new List<Report7_10_1>();
            try
            {
                using var context = new SqlCoreContext();
                var list = context.Set<Report7_10_1>().FromSqlRaw("EXECUTE SP_REPORTES_7_10_1 @number = " + number).ToList();
                response.Data = list;
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport7_10_1(int number, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/GERENCIA/REPORT_7.10";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "number", number.ToString() },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_7.10", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<Report7_10_2>> GetReport7_10_2(int id, string about)
        {
            var response = new Response<Report7_10_2>();
            response.Data = new Report7_10_2();
            try
            {
                using var context = new SqlCoreContext();
                var main = context.Set<Report7_10_2_Main>().FromSqlRaw("EXECUTE SP_REPORTES_7_10_2 @id = " + id + ", @about = '" + about + "'").ToList();
                var details = context.Set<Report7_10_2_Details>().FromSqlRaw("EXECUTE SP_REPORTES_7_10_2_Details @id = " + id + ", @about = '" + about + "'").ToList();
                response.Data.Main = main;
                response.Data.Details = details;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport7_10_2(int id, string about, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/GERENCIA/REPORT_7.10_Details";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "id", id.ToString() },
                    { "about", about },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_7.10_DET", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport7_11(int year, string code, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/GERENCIA/REPORT_7.11";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "year", year.ToString() },
                    { "code", code },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_7.11", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport7_12_1(int month, int year, string code, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/GERENCIA/REPORT_7.12.1";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "month", month.ToString() },
                    { "year", year.ToString() },
                    { "code", code },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_7.12.1", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport7_12_2(int year, string code, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/GERENCIA/REPORT_7.12.2";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "year", year.ToString() },
                    { "code", code },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_7.12.2", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport7_13_1(int month, int year, string code, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/GERENCIA/REPORT_7.13.1";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "month", month.ToString() },
                    { "year", year.ToString() },
                    { "code", code },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_7.13.1", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport7_13_2(int year, string code, string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/GERENCIA/REPORT_7.13.2";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "year", year.ToString() },
                    { "code", code },
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_7.13.2", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<GetFileResponseDto>> DownloadReport7_15(string format)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/GERENCIA/REPORT_7.15";
                var reportRenderType = StaticFunctions.GetReportRenderType(format);
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                };

                response.Data = new GetFileResponseDto
                {
                    File = await _reportingDownload.GenerateReportAsync(report, reportRenderType, dictionary),
                    ContentType = contentType,
                    Name = string.Format(fileFormat, "REPORTE_7.15", "", extension)
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
    }
}
