using DRRCore.Domain.Entities.SqlCoreContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IAgentDomain : IBaseDomain<Agent>
    {
        Task<List<Agent>> GetAllAgentsAsync(string code, string name, string state);
        Task<int> AddAgent(Agent agent);
    }
}
