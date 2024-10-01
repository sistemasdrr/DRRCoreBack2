using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Application.Main.CoreApplication;
using Microsoft.AspNetCore.Mvc;

namespace DRRCore.Services.ApiCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : Controller
    {
        public readonly IDashboardApplication _dashboardApplication;
        public DashboardController(IDashboardApplication dashboardApplication)
        {
            _dashboardApplication = dashboardApplication;
        }
        [HttpGet()]
        [Route("PendingTask")]
        public async Task<ActionResult> PendingTask(string userTo)
        {
            return Ok(await _dashboardApplication.PendingTask(userTo));
        }
        [HttpGet()]
        [Route("DailyProduction")]
        public async Task<ActionResult> DailyProduction(string userTo)
        {
            return Ok(await _dashboardApplication.DailyProduction(userTo));
        }
        [HttpGet()]
        [Route("MonthlyProduction")]
        public async Task<ActionResult> MonthlyProduction(string userTo)
        {
            return Ok(await _dashboardApplication.MonthlyProduction(userTo));
        }
        [HttpGet()]
        [Route("ObservedTickets")]
        public async Task<ActionResult> ObservedTickets(int idEmployee)
        {
            return Ok(await _dashboardApplication.ObservedTickets(idEmployee));
        }
        [HttpGet()]
        [Route("TicketsInCurrentMonth")]
        public async Task<ActionResult> TicketsInCurrentMonth()
        {
            return Ok(await _dashboardApplication.TicketsInCurrentMonth());
        }
        [HttpGet()]
        [Route("GetPendingTaskByUser")]
        public async Task<ActionResult> GetPendingTaskByUser(string userTo)
        {
            return Ok(await _dashboardApplication.GetPendingTaskByUser(userTo));
        }
        [HttpGet()]
        [Route("GetStaticsByCountryDto")]
        public async Task<ActionResult> GetStaticsByCountry(int idCountry)
        {
            return Ok(await _dashboardApplication.GetStaticsByCountry(idCountry));
        }

    }
}
