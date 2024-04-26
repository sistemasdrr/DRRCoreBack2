using DRRCore.Domain.Entities.SqlCoreContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IAgentPriceDomain : IBaseDomain<AgentPrice>
    {
        Task<List<AgentPrice>> GetPricesByIdAsync(int idAgent);
    }
}
