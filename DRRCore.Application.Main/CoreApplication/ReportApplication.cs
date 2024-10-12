using AutoMapper;
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
        public async Task<Response<GetFileResponseDto>> DownloadReport6_1_5(int idSubscriber)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/ABONADOS/REPORTES_ABONADO_6.1.5";
                var reportRenderType = StaticFunctions.GetReportRenderType("pdf");
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

        public async Task<Response<GetFileResponseDto>> DownloadReport6_1_7(string orderBy)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/ABONADOS/REPORTES_ABONADO_6.1.7";
                var reportRenderType = StaticFunctions.GetReportRenderType("pdf");
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
        public async Task<Response<GetFileResponseDto>> DownloadReport6_1_14(string type)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {

                string fileFormat = "{0}_{1}{2}";
                string report = "REPORTES/ABONADOS/REPORTES_ABONADO_6.1.14";
                var reportRenderType = StaticFunctions.GetReportRenderType("pdf");
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
    }
}
