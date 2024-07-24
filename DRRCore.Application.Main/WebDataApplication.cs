using AspNetCore.Reporting;
using AutoMapper;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.ExtendedProperties;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.DTO.Web;
using DRRCore.Application.Interfaces;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using Google.Protobuf;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Application.Main
{
    public class WebDataApplication : IWebDataApplication
    {
        private readonly IWebDataDomain _webDataDomain;
        private readonly IReportingDownload _reportingDownload;

        private readonly ILogger _logger;
        private IMapper Mapper { get; }
        public WebDataApplication(IWebDataDomain webDataDomain, ILogger logger, IMapper mapper, IReportingDownload reportingDownload)
        {

            _webDataDomain = webDataDomain;
            _logger = logger;
            Mapper = mapper;
            _reportingDownload = reportingDownload;
        }
        public async Task<Response<bool>> AddOrUpdateWebDataAsync()
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _webDataDomain.AddOrUpdateWebDataAsync();

            }
            catch (Exception exception)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, exception);
            }
            return response;
        }

        public async Task<Response<WebDataDto>> GetByCodeAsync(string code)
        {
            var response = new Response<WebDataDto>();

            try
            {
                var data = await _webDataDomain.GetByCodeAsync(code);
                if (data != null)
                {
                    response.Data = Mapper.Map<WebDataDto>(data);
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }


            }
            catch (Exception exception)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, exception);
            }
            return response;
        }

        public async Task<Response<List<WebDataDto>>> GetByParamAsync(string param, int page = 1)
        {
            var response = new Response<List<WebDataDto>>();
            if (string.IsNullOrEmpty(param))
            {
                response.IsSuccess = false;
                response.Message = Messages.WrongParameter;
                _logger.LogAdvertencia(response.Message);
                return response;

            }
            if (param.Trim().Length < 3)
            {
                response.IsSuccess = false;
                response.Message = Messages.ParameterIsNotTooLonger;
                _logger.LogAdvertencia(response.Message);
                return response;

            }
            try
            {
                var data = await _webDataDomain.GetByParamAsync(param.ToUpper(), page);
                response.Data = Mapper.Map<List<WebDataDto>>(data);

            }
            catch (Exception exception)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, exception);
            }
            return response;
        }

        public async Task<Response<List<WebDataDto>>> GetByCountryAndBranchAsync(int country, string branch, int page)
        {
            var response = new Response<List<WebDataDto>>();
            try
            {
                if (country > 0 && !string.IsNullOrEmpty(branch) && page > 0)
                {
                    var data = await _webDataDomain.GetByCountryAndBranchAsync(country, branch, page);
                    response.Data = Mapper.Map<List<WebDataDto>>(data);                   
                }
                else
                {
                    response.IsSuccess = false;
                    response.IsWarning = true;
                    response.Message = "Error al listar: parametros invalidos";
                    _logger.LogError(response.Message);
                }
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.IsWarning = true;
                response.Message = "Error al listar: " + ex.Message;
                _logger.LogError(response.Message, ex);
                return response;
            }
        }

        public async Task<Response<List<WebDataDto>>> GetSimilarBrunchAsync(string code)
        {
            var response = new Response<List<WebDataDto>>();
            try
            {
                if (!string.IsNullOrEmpty(code))
                {
                    var data = await _webDataDomain.GetSimilarBrunchAsync(code);
                    response.Data = Mapper.Map<List<WebDataDto>>(data);                  
                }
                else
                {
                    response.IsSuccess = false;
                    response.IsWarning = true;
                    response.Message = "Error al listar: parametros invalidos";
                    _logger.LogError(response.Message);
                }
                return response;
            }catch (Exception ex)
            {
                response.IsSuccess = false;
                response.IsWarning = true;
                response.Message = "Error al listar: " + ex.Message;
                _logger.LogError(response.Message, ex);
                return response;
            }
        }

        public async Task<Response<string>> GetOldCodeAsync(string code)
        {

            var response = new Response<string>();
            try
            {
                if (!string.IsNullOrEmpty(code) && code.Length==11)
                {
                    response.Data = await _webDataDomain.GetOldCodeAsync(code);                
                }
                else
                {
                    response.IsSuccess = false;
                    response.IsWarning = true;
                    response.Message = "Error al listar: parametro inválido";
                    _logger.LogError(response.Message);
                }
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.IsWarning = true;
                response.Message = "Error al listar: " + ex.Message;
                _logger.LogError(response.Message, ex);
                return response;
            }
        }

        public async Task<Response<GetFileResponseDto>> DispatchPDF(WebDTO obj)
        {
            var response = new Response<GetFileResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var company = await context.Companies.Where(x => x.OldCode.Contains(obj.OldCode.Trim())).FirstOrDefaultAsync();

                var reportName = "";
                var language = obj.Language == "C" ? "E" : "I";

                if(obj.Language.Trim() == "C")
                {
                    if(obj.Quality.Trim() == "A")
                    {
                        reportName = "EMPRESAS/F8-EMPRESAS-A-ES";
                    }
                    else if (obj.Quality.Trim() == "B")
                    {
                        reportName = "EMPRESAS/F8-EMPRESAS-B-ES";
                    }
                    else if (obj.Quality.Trim() == "C")
                    {
                        reportName = "EMPRESAS/F8-EMPRESAS-C-ES";
                    }
                }
                else if(obj.Language.Trim() == "I")
                {
                    if (obj.Quality.Trim() == "A")
                    {
                        reportName = "EMPRESAS/F8-EMPRESAS-A-EN";
                    }
                    else if (obj.Quality.Trim() == "B")
                    {
                        reportName = "EMPRESAS/F8-EMPRESAS-B-EN";
                    }
                    else if (obj.Quality.Trim() == "C")
                    {
                        reportName = "EMPRESAS/F8-EMPRESAS-C-EN";
                    }
                }
                string fileFormat = "{0}_{1}{2}";
                var reportRenderType = StaticFunctions.GetReportRenderType("pdf");
                var extension = StaticFunctions.FileExtension(reportRenderType);
                var contentType = StaticFunctions.GetContentType(reportRenderType);

                var dictionary = new Dictionary<string, string>
                {
                    { "idCompany", company.Id.ToString() },
                    { "language", language }
                };

                var file = await _reportingDownload.GenerateReportAsync(reportName, reportRenderType, dictionary);
                response.Data = new GetFileResponseDto
                {
                    File = file,
                    ContentType = contentType,
                    Name = string.Format(fileFormat, company.OldCode, language, extension)
                };

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.IsWarning = true;
                response.Message = ex.Message;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
    }
}
