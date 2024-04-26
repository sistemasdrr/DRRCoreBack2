using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IAgentPriceRepository : IBaseRepository<AgentPrice>
    {
        Task<List<AgentPrice>> GetPricesByIdAsync(int idAgent);
    }
}
