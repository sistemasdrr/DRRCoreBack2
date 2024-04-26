
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class AgentDomain : IAgentDomain
    {
        private readonly IAgentRepository _agentRepository;
        public AgentDomain(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        public async Task<int> AddAgent(Agent agent)
        {
            return await _agentRepository.AddAgent(agent);
        }

        public async Task<bool> AddAsync(Agent obj)
        {
            return await _agentRepository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _agentRepository.DeleteAsync(id);
        }

        public async Task<List<Agent>> GetAllAgentsAsync(string code, string name, string state)
        {
            return await _agentRepository.GetAllAgentsAsync(code, name, state);
        }

        public async Task<List<Agent>> GetAllAsync()
        {
            return await _agentRepository.GetAllAsync();
        }

        public async Task<Agent> GetByIdAsync(int id)
        {
            return await _agentRepository.GetByIdAsync(id);
        }

        public async Task<List<Agent>> GetByNameAsync(string name)
        {
            return await _agentRepository.GetByNameAsync(name);
        }

        public async Task<bool> UpdateAsync(Agent obj)
        {
            return await _agentRepository.UpdateAsync(obj);
        }
    }
}
