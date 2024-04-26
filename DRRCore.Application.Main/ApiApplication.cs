using AutoMapper;
using DRRCore.Application.DTO;
using DRRCore.Application.DTO.API;
using DRRCore.Application.Interfaces;
using DRRCore.Domain.Interfaces;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;

namespace DRRCore.Application.Main
{
    public class ApiApplication : IApiApplication
    {
        private readonly IWebDataDomain _webDataDomain;
        private readonly ILogger _logger;       
        private readonly IMapper _mapper;
        public ApiApplication(IWebDataDomain webDataDomain,ILogger logger,IMapper mapper)
        {
            _webDataDomain = webDataDomain;
            _logger = logger;
         
            _mapper = mapper;
        }
        public async Task<Response<ReportDto>> GetDummyReportAsync(GetRequestDto request)
        {
            var response = new Response<ReportDto>();
            if (string.IsNullOrEmpty(request.Code) || request.Code.Length != 17)
            {
                response.IsSuccess = false;
                response.Message =string.Format(Messages.WrongParameterId, "DRR_CODEID");
                response.IsWarning = true;
                _logger.LogError(response.Message);
                return response;
            }
            if (string.IsNullOrEmpty(request.Language) || request.Language.Length != 3)
            {
                response.IsSuccess = false;
                response.IsWarning = true;
                response.Message = string.Format(Messages.WrongParameterId, "DRR_LANGUA");
                _logger.LogError(response.Message);
                return response;
            }
            
            var data = await ApiDummy.Report(1); 
            
            response.Data= data;
           
            return response;
        }
        public async Task<Response<ReportDto>> GetReportByCodeAndEnvironmentAsync(string code, string environment)
        {
            var response = new Response<ReportDto>();
            try
            {
                response.Data = await ApiDummy.Report(1);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return response;
        }
       
        public async Task<Response<SearchResponseDto>> Search(SearchRequestDto request,string environment)
        {
            var response = new Response<SearchResponseDto>();
            
            try
            {
                var requestClient = new RequestClientDto()
                {
                    Environment = Dictionary.EnvironmentDictionary[environment],
                    RequestDate = DateTime.Now.ToString(Constants.DateFormatEnglish),
                    Priority = GetPriority(request.Priority),
                    Request = request.SearchText
                };
                if (string.IsNullOrEmpty(request.SearchText) || request.SearchText.Length<=3)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.WrongParameter;
                    _logger.LogError(response.Message);
                    return response;
                }
                if (!string.IsNullOrEmpty(request.IsoCountry))
                {
                    if(request.IsoCountry.Length != 3)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.ParameterIsNotTooLonger;
                        _logger.LogError(response.Message);
                    }
                    else
                    {
                        var data = await _webDataDomain.GetByParamAndCountryAsync(request.SearchText,request.IsoCountry);
                        if (data != null)
                        {                          
                            var reportData = _mapper.Map<List<ReportDataDto>>(data);
                            
                            response.Data = new SearchResponseDto
                            {
                                Data = reportData,
                                RequestClient = requestClient
                            };
                            
                        }
                        else
                        {
                            response.IsSuccess = false;
                            response.Message = Messages.MessageNoDataFound;
                            _logger.LogError(response.Message);
                        }
                    }
                }
                else
                {
                    var data = await _webDataDomain.GetByParamAsync(request.SearchText, 1);
                    if (data != null)
                    {
                        var reportData = _mapper.Map<List<ReportDataDto>>(data);
                        response.Data = new SearchResponseDto
                        {
                            Data = reportData,
                            RequestClient = requestClient
                        };
                       
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataFound;
                        _logger.LogError(response.Message);
                    }

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
        private static string GetPriority(string key)
        {
            if(string.IsNullOrEmpty(key) || !Dictionary.PriorityDictionary.ContainsKey(key)) return Dictionary.PriorityDictionary[Constants.PriorityLow];
            return Dictionary.PriorityDictionary[key];   
        }

      
    }
}
