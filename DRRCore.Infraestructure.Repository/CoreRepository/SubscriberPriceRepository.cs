using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class SubscriberPriceRepository : ISubscriberPriceRepository
    {
        private readonly ILogger _logger;
        public SubscriberPriceRepository(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<bool> AddAsync(SubscriberPrice obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                if(obj != null)
                {
                    var existingSubscriber = await context.Subscribers.FindAsync(obj.IdSubscriber);
                    if (existingSubscriber != null)
                    {
                        await context.SubscriberPrices.AddAsync(obj);
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var existingSubcriberPrice = await context.SubscriberPrices.FindAsync(id);
                if(existingSubcriberPrice != null)
                {
                    existingSubcriberPrice.Enable = false;
                    context.SubscriberPrices.Update(existingSubcriberPrice);
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

        public Task<List<SubscriberPrice>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<SubscriberPrice> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var existingSubcriberPrice = await context.SubscriberPrices.FindAsync(id);
                if (existingSubcriberPrice != null)
                {
                    return existingSubcriberPrice;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Task<List<SubscriberPrice>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<SubscriberPrice> GetPriceBySubscriberIds(int idSubscriber, int idContinent, int idCountry)
        {
            try
            {
                using var context = new SqlCoreContext();
                var existingSubcriberPrice = await context.SubscriberPrices.FirstOrDefaultAsync(x => x.IdSubscriber == idSubscriber && x.IdContinent == idContinent && x.IdCountry == idCountry);
                if (existingSubcriberPrice != null)
                {
                    return existingSubcriberPrice;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<List<SubscriberPrice>> GetPricesBySubscriberId(int idSubscriber)
        {
            try
            {
                using var context = new SqlCoreContext();
                var existingSubscriber = await context.Subscribers.FindAsync(idSubscriber);
                if(existingSubscriber != null)
                {
                    var subcriberPrices = await context.SubscriberPrices.Include(x => x.IdContinentNavigation).Include(x => x.IdCountryNavigation).Include(x => x.IdCurrencyNavigation).Where(x => x.IdSubscriber == idSubscriber).ToListAsync();
                    return subcriberPrices;
                }
                else
                {
                    return new List<SubscriberPrice>();
                }
               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<SubscriberPrice>();
            }
        }

        public async Task<bool> UpdateAsync(SubscriberPrice obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                context.SubscriberPrices.Update(obj);
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
