using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class SubscriberRepository : ISubscriberRepository
    {
        private readonly ILogger _logger;
        public SubscriberRepository(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<bool> ActiveSubscriberAsync(int id)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    var subscriber = await context.Subscribers.FindAsync(id);
                    if(subscriber != null)
                    {
                        subscriber.Enable = true;
                        context.Subscribers.Update(subscriber);
                        await context.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;

            }
        }

        public async Task<int> AddSubscriberAsync(Subscriber subscriber)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    await context.Subscribers.AddAsync(subscriber);
                    await context.SaveChangesAsync();
                    return subscriber.Id;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return 0;

            }
        }

        public async Task<bool> DeleteSubscriberAsync(int id)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    var subscriber = await context.Subscribers.FindAsync(id);
                    if (subscriber != null)
                    {
                        subscriber.Enable = false;
                        context.Subscribers.Update(subscriber);
                        await context.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;

            }
        }

        public async Task<List<Subscriber>> GetSubscriber(string code, string name, string enable)
        {
            try
            {
                using var context = new SqlCoreContext();
                if (enable.Equals("A"))
                {
                    return await context.Subscribers.Include(x => x.IdCountryNavigation).Where(x => x.Code.Contains(code) && x.Name.Contains(name) && x.Enable == true).ToListAsync();

                }
                else
                {
                    return await context.Subscribers.Include(x => x.IdCountryNavigation).Where(x => x.Code.Contains(code) && x.Name.Contains(name)).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<Subscriber>();
            }
        }

        public async Task<Subscriber> GetSubscriberByCode(string code)
        {
            try
            {
                using var context = new SqlCoreContext();

                return await context.Subscribers.Include(x=>x.CouponBillingSubscribers).FirstOrDefaultAsync(x => x.Code == code);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<Subscriber> GetSubscriberById(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
               
                return await context.Subscribers.Include(x=>x.CouponBillingSubscribers).FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<Subscriber> LoginSubscriber(string usr, string psw)
        {
            try
            {
                using var context = new SqlCoreContext();
                var abonado = await context.Subscribers.Where(x => x.Usr == usr && x.Psw == psw).FirstOrDefaultAsync();
                if(abonado != null)
                {
                    return abonado;
                }
                else
                {
                    return null;
                }
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> UpdateSubscriberAsync(Subscriber subscriber)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    subscriber.UpdateDate = DateTime.Now;
                    context.Subscribers.Update(subscriber);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
