using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.Interfaces.CoreApplication;
using Microsoft.AspNetCore.Mvc;

namespace DRRCore.Services.ApiCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnniversaryController : Controller
    {
        private readonly IAnniversaryApplication _anniversaryApplication;
        public AnniversaryController(IAnniversaryApplication anniversaryApplication)
        {
            _anniversaryApplication = anniversaryApplication;
        }

        [HttpGet]
        [Route("GetCalendarAniversary")]
        public async Task<ActionResult> GetCalendarAniversary()
        {
            return Ok(await _anniversaryApplication.GetCalendarAniversary());
        }
        [HttpPost]
        [Route("AddOrUpdateAsync")]
        public async Task<ActionResult> AddOrUpdateAsync(AddOrUpdateAnniversaryDto obj)
        {
            return Ok(await _anniversaryApplication.AddOrUpdateAsync(obj));
        }
    }
}
