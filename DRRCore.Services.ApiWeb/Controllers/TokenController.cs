using DRRCore.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DRRCore.Services.ApiWeb.Controllers
{
    public class TokenController : Controller
    {
       private readonly ITokenGeneratorApplication _tokenGenerator;
        public TokenController(ITokenGeneratorApplication tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("GetToken")]
        public async Task<ActionResult> getToken()
        {
            return Ok(await _tokenGenerator.GetTokenAsync());
        }
    }
}
