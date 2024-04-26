using DRRCore.Application.DTO.API;
using DRRCore.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DRRCore.Services.ApiWeb.Controllers
{
    public class PruebasController : Controller
    {
        private readonly ITokenValidationApplication _tokenValidation;
        private readonly IApiUserApplication _apiUserApplication;

        public PruebasController(ITokenValidationApplication tokenValidation, IApiUserApplication apiUserApplication)
        {
            _tokenValidation = tokenValidation;
            _apiUserApplication = apiUserApplication;
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("validarToken")]
        public async Task<ActionResult> ValidationTokenAsync()
        {
            var response = await _tokenValidation.ValidationTokenAsync();
            if (!response.IsSuccess)
            {
                return Unauthorized();
            }
            return Ok(await _tokenValidation.ValidationTokenAsync());
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("encriptarToken")]
        public async Task<ActionResult> EncryptTokenAsync(string token)
        {
            return Ok(await _tokenValidation.EncryptTokenAsync(token));
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("desencriptarToken")]
        public async Task<ActionResult> DecryptTokenAsync(string tokenEncriptado)
        {
            return Ok(await _tokenValidation.decryptTokenAsync(tokenEncriptado));
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("insertarUser")]
        public async Task<ActionResult> InsertUserAsync(ApiUserDto dto)
        {
            return Ok(await _apiUserApplication.AddApiUserAsync(dto));
        }
    }
}
