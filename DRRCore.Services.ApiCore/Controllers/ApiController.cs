using DRRCore.Application.DTO.API;
using DRRCore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DRRCore.Services.ApiCore.Controllers
{
    [ApiController]
    [Route("[controller]")]  
    public class ApiController : Controller
    {
        private readonly IApiApplication _apiApplication;
        private readonly ITokenValidationApplication _tokenValidation;
        public ApiController(IApiApplication apiApplication, ITokenValidationApplication tokenValidationApplication)
        {
            _apiApplication = apiApplication;
            _tokenValidation = tokenValidationApplication;
        }
        [HttpPost()]
        [Route("search")]
        public async Task<ActionResult> SearchByParamAndCountry(SearchRequestDto request)
        {
            var response = await _tokenValidation.ValidationTokenAndEnvironmentAsync(Transversal.Common.Constants.ProductionEnvironment);
            if (!response.IsSuccess)
            {
                return Unauthorized();
            }
            return Ok(await _apiApplication.Search(request, Transversal.Common.Constants.ProductionEnvironment));
        }
        [HttpPost()]
        [Route("qa/search")]
        public async Task<ActionResult> SearchByParamAndCountryQuality(SearchRequestDto request)
        {
            var response = await _tokenValidation.ValidationTokenAndEnvironmentAsync(Transversal.Common.Constants.QualityEnvironment);
            if (!response.IsSuccess)
            {
                return Unauthorized();
            }
            return Ok(await _apiApplication.Search(request, Transversal.Common.Constants.QualityEnvironment));
        }
        [HttpPost()]
        [Route("dev/search")]
        public async Task<ActionResult> SearchByParamAndCountryDevelop(SearchRequestDto request)
        {
            var response = await _tokenValidation.ValidationTokenAndEnvironmentAsync(Transversal.Common.Constants.DevelopmenteEnvironment);
            if (!response.IsSuccess)
            {
                return Unauthorized();
            }
            return Ok(await _apiApplication.Search(request, Transversal.Common.Constants.DevelopmenteEnvironment));
        }
        [HttpPost()]
        [Route("dev/get")]
        public async Task<ActionResult> GetCodeByDevelopmentEnvironment(GetRequestDto requestDto)
        {
            var response = await _tokenValidation.ValidationTokenAndEnvironmentAsync(Transversal.Common.Constants.DevelopmenteEnvironment);
            if (!response.IsSuccess)
            {
                return Unauthorized();
            }
            
            return Ok(await _apiApplication.GetDummyReportAsync(requestDto));
        }
        [HttpPost()]
        [Route("qa/get")]
        public async Task<ActionResult> GetCodeByQualityEnvironment(GetRequestDto requestDto)
        {
            var response = await _tokenValidation.ValidationTokenAndEnvironmentAsync(Transversal.Common.Constants.QualityEnvironment);
            if (!response.IsSuccess)
            {
                return Unauthorized();
            }
            return Ok(await _apiApplication.GetDummyReportAsync(requestDto));
        }
        [HttpPost()]
        [Route("get")]
        public async Task<ActionResult> GetCodeByProductionEnvironment(GetRequestDto requestDto)
        {
            var response = await _tokenValidation.ValidationTokenAndEnvironmentAsync(Transversal.Common.Constants.ProductionEnvironment);
            if (!response.IsSuccess)
            {
                return Unauthorized();
            }
            return Ok(await _apiApplication.GetDummyReportAsync(requestDto));
        }
        [HttpGet()]
       
        [Route("dummy")]
        public async Task<ActionResult> DummyReport()
        {
            return Ok(await _apiApplication.GetReportByCodeAndEnvironmentAsync("",""));
        }
    }
}
