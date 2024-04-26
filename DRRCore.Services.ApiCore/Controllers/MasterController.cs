using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.Interfaces.CoreApplication;
using Microsoft.AspNetCore.Mvc;

namespace DRRCore.Services.ApiCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MasterController : Controller
    {
        private readonly IEmployeeApplication _employeeApplication;
        private readonly IAnniversaryApplication _anniversaryApplication;
        public MasterController(IEmployeeApplication employeeApplication, IAnniversaryApplication anniversaryApplication) {
           _employeeApplication = employeeApplication;
            _anniversaryApplication= anniversaryApplication;
        }

        [HttpPost()]
        [Route("addEmployee")]
        public async Task<ActionResult> AddEmployee(AddOrUpdateEmployeeRequestDto request)
        {
            return Ok(await _employeeApplication.AddOrUpdateAsync(request));
        }
        [HttpPost()]
        [Route("deleteEmployee")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            return Ok(await _employeeApplication.DeleteAsync(id));
        }
        [HttpPost()]
        [Route("activeEmployee")]
        public async Task<ActionResult> ActiveEmployee(int id)
        {
            return Ok(await _employeeApplication.ActiveAsync(id));
        }
        [HttpGet()]
        [Route("getEmployeeById")]
        public async Task<ActionResult> GetEmployee(int id)
        {
            return Ok(await _employeeApplication.GetByIdAsync(id));
        }
        [HttpGet()]
        [Route("getEmployees")]
        public async Task<ActionResult> GetEmployees()
        {
            return Ok(await _employeeApplication.GetAllAsync());
        }
        [HttpGet()]
        [Route("getEmployeesByName")]
        public async Task<ActionResult> GetEmployeesByName(string name)
        {
            return Ok(await _employeeApplication.GetByNameAsync(name));
        }
        [HttpPost()]
        [Route("addAnniversary")]
        public async Task<ActionResult> AddAnniversary(AddOrUpdateAnniversaryRequestDto request)
        {
            return Ok(await _anniversaryApplication.AddOrUpdateAsync(request));
        }
        [HttpPost()]
        [Route("deleteAnnyversary")]
        public async Task<ActionResult> DeleteAnniversary(int id)
        {
            return Ok(await _anniversaryApplication.DeleteAsync(id));
        }
        [HttpPost()]
        [Route("activeAnnyversary")]
        public async Task<ActionResult> ActiveAnnyversary(int id)
        {
            return Ok(await _anniversaryApplication.ActiveAsync(id));
        }
        [HttpGet()]
        [Route("getAnniversaryById")]
        public async Task<ActionResult> GetAnniversaryById(int id)
        {
            return Ok(await _anniversaryApplication.GetByIdAsync(id));
        }
        [HttpGet()]
        [Route("getAnniversary")]
        public async Task<ActionResult> GetAnniversary()
        {
            return Ok(await _anniversaryApplication.GetAllAsync());
        }
        [HttpGet()]
        [Route("getCurrentAnniversary")]
        public async Task<ActionResult> GetCurrentAnniversary()
        {
            return Ok(await _anniversaryApplication.GetCurrentAnniversary());
        }
    }
}
