using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.Interfaces.CoreApplication;
using Microsoft.AspNetCore.Mvc;

namespace DRRCore.Services.ApiCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserApplication _userApplication;
        public UserController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }
        [HttpGet()]
        [Route("GetProcess")]
        public async Task<ActionResult> GetProcess()
        {
            return Ok(await _userApplication.GetProcessAsync());
        }
        [HttpGet()]
        [Route("Login")]
        public async Task<ActionResult> LoginUser(string? username, string? password)
        {
            username ??= string.Empty;
            password ??= string.Empty;
            return Ok(await _userApplication.LoginUser(username, password));
        }
        [HttpGet()]
        [Route("User")]
        public async Task<ActionResult> UserById(int id)
        {
            return Ok(await _userApplication.getUserById(id));
        }
        [HttpGet()]
        [Route("UserProcess")]
        public async Task<ActionResult> UserProcess(int idEmployee)
        {
            return Ok(await _userApplication.getProcessByIdEmployee(idEmployee));
        }
        [HttpPost()]
        [Route("UpdateProcess")]
        public async Task<ActionResult> UpdateProcess(AddOrUpdateUserProcessRequestDto obj)
        {
            return Ok(await _userApplication.UpdateProcess(obj));
        }
    }
}
