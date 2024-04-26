using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class AgentPriceDomain : IAgentPriceDomain
    {
        private IAgentPriceRepository _agentPriceRepository;
        public AgentPriceDomain(IAgentPriceRepository agentPriceRepository)
        {
            _agentPriceRepository = agentPriceRepository;
        }

        public async Task<bool> AddAsync(AgentPrice obj)
        {
            return await _agentPriceRepository.AddAsync(obj);    
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _agentPriceRepository.DeleteAsync(id);
        }

        public Task<List<AgentPrice>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<AgentPrice> GetByIdAsync(int id)
        {
            return await _agentPriceRepository.GetByIdAsync(id);
        }

        public Task<List<AgentPrice>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AgentPrice>> GetPricesByIdAsync(int idAgent)
        {
            return await _agentPriceRepository.GetPricesByIdAsync(idAgent);
        }

        public async Task<bool> UpdateAsync(AgentPrice obj)
        {
            return await _agentPriceRepository.UpdateAsync(obj);
        }
    }
}
