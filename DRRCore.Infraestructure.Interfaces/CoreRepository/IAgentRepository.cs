using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IAgentRepository : IBaseRepository<Agent>
    {
        Task<List<Agent>> GetAllAgentsAsync(string code, string name, string state);
        Task<int> AddAgent(Agent agent);
    }
}
