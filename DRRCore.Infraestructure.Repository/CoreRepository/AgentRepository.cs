using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class AgentRepository : IAgentRepository
    {
        private readonly ILogger _logger;
        public AgentRepository(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<int> AddAgent(Agent agent)
        {
            try
            {
                using var context = new SqlCoreContext();
                await context.AddAsync(agent);
                await context.SaveChangesAsync();
                return agent.Id;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return 0;
            }
        }

        public async Task<bool> AddAsync(Agent obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                await context.AddAsync(obj);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var agent = await context.Agents.FindAsync(id);
                agent.Enable = false;
                context.Update(agent);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<List<Agent>> GetAllAgentsAsync(string code, string name, string state)
        {
            var list = new List<Agent>();
            try
            {
                using var context = new SqlCoreContext();
                if(state == "A")
                {
                    list = await context.Agents.Include(x => x.IdCountryNavigation).Where(x => x.Code.Contains(code) && x.Name.Contains(name) && x.State == true).ToListAsync();
                }
                else
                {
                    list = await context.Agents.Include(x => x.IdCountryNavigation).Where(x => x.Code.Contains(code) && x.Name.Contains(name)).ToListAsync();
                }
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<Agent>();
            }
        }

        public async Task<List<Agent>> GetAllAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.Agents.ToListAsync();
                return list;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<Agent>();
            }
        }

        public async Task<Agent> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var agent = await context.Agents.FindAsync(id);
                return agent;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Agent();
            }
        }

        public async Task<List<Agent>> GetByNameAsync(string name)
        {
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.Agents.Where(x => x.Name.Contains(name)).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<Agent>();
            }
        }

        public async Task<bool> UpdateAsync(Agent obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                context.Update(obj);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
