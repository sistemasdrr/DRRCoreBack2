using DRRCore.Application.DTO.Core.Response;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Transversal.Common;

namespace DRRCore.Application.Interfaces.CoreApplication
{
    public interface IDashboardApplication 
    {
        Task<Response<List<PendingTaskResponseDto>>> PendingTask(string userTo);
        Task<Response<int?>> DailyProduction(string userTo);
        Task<Response<int?>> MonthlyProduction(string userTo);
        Task<Response<List<ObservedTickets?>>> ObservedTickets(int idEmployee);
        Task<Response<object>> TicketsInCurrentMonth();
        Task<Response<List<PendingTaskSupervisorResponseDto>>> GetPendingTaskByUser(string userTo);
    }
}
