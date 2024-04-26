using DRRCore.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DRRCore.Services.ApiWeb.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WebController : Controller
    {
        private readonly IWebDataApplication _webDataApplication;
        public WebController(IWebDataApplication webDataApplication)
        {         
            _webDataApplication = webDataApplication;
        }

        [HttpGet()]
        [Route("post/uploadData")]
        public async Task<ActionResult> AddOrUpdateWebData()
        {
            return Ok(await _webDataApplication.AddOrUpdateWebDataAsync());
        }
        [HttpGet()]        
        [Route("get/param/{param}/{page}")]
        public async Task<ActionResult> GetByParamPaging(string param,int page=1)
        {           
            return Ok(await _webDataApplication.GetByParamAsync(param,page));
        }
        [HttpGet()]
        [Route("get/code/{code}")]
        public async Task<ActionResult> GetByCode(string code)
        {
            return Ok(await _webDataApplication.GetByCodeAsync(code));
        }
        [HttpGet()]
        [Route("get/countryandbranch/{country}/{branch}/{page}")]
        public async Task<ActionResult> GetByCountryAndBranch(int country, string branch, int page = 1)
        {
            return Ok(await _webDataApplication.GetByCountryAndBranchAsync(country, branch, page));
        }
        [HttpGet()]
        [Route("get/similar/{code}")]
        public async Task<ActionResult> GetByCountryAndBranch(string code)
        {
            return Ok(await _webDataApplication.GetSimilarBrunchAsync(code));
        }
        [HttpGet()]
        [Route("get/oldcode/{code}")]
        public async Task<ActionResult> GetOldCode(string code)
        {
            return Ok(await _webDataApplication.GetOldCodeAsync(code));
        }


    }
}
