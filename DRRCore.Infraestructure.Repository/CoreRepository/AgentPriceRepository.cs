using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class AgentPriceRepository : IAgentPriceRepository
    {
        private readonly ILogger _logger;
        public AgentPriceRepository(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<bool> AddAsync(AgentPrice obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                if(obj != null)
                {
                    await context.AgentPrices.AddAsync(obj);
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }catch (Exception ex)
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
                var existingAgentPrice = await context.AgentPrices.FindAsync(id);
                if (existingAgentPrice != null)
                {
                    existingAgentPrice.Enable = false;
                    existingAgentPrice.UpdateDate = DateTime.Now;
                    existingAgentPrice.DeleteDate = DateTime.Now;
                    context.AgentPrices.Update(existingAgentPrice);
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public Task<List<AgentPrice>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<AgentPrice> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var agentPrice = await context.AgentPrices.FindAsync(id);
                return agentPrice;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new AgentPrice();
            }
        }

        public Task<List<AgentPrice>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AgentPrice>> GetPricesByIdAsync(int idAgent)
        {
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.AgentPrices.Include(x => x.IdCountryNavigation).Include(x => x.IdCurrencyNavigation).Where(x => x.IdAgent == idAgent).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<AgentPrice>();
            }
        }

        public async Task<bool> UpdateAsync(AgentPrice obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                if (obj != null)
                {
                    context.AgentPrices.Update(obj);
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
