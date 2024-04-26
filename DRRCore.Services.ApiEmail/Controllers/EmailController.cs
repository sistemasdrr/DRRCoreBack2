using DRRCore.Application.DTO.Email;
using DRRCore.Application.Interfaces.EmailApplication;
using Microsoft.AspNetCore.Mvc;

namespace DRRCore.Services.ApiEmail.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly IEmailApplication _emailApplication;
        public EmailController(IEmailApplication emailApplication)
        {
            _emailApplication=emailApplication;
        }

        [HttpPost()]
        [Route("sendMail")]
        public async Task<ActionResult> SendMail(EmailDataDTO dataDTO)
        {
            return Ok(await _emailApplication.SendMailAsync(dataDTO));
        }
        [HttpGet()]
        [Route("reSendMail")]
        public async Task<ActionResult> ReSendMail()
        {
            return Ok(await _emailApplication.ReSendMailAsync());
        }
        [HttpGet()]
        [Route("FileToBase64")]
        public async Task<ActionResult> FileToBase64(string path)
        {
            return Ok(await _emailApplication.ConvertFileToBase64(path));
        }
    }
}
