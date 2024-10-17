using AutoMapper;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Wordprocessing;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;

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
                string report = "REPORTES/REPORTEROS/REPORT_6.2.3";
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
    }
}
