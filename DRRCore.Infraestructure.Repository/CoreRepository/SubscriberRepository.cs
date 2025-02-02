using DRRCore.Application.DTO.Enum;
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
                    var couponBilling = new CouponBillingSubscriber();
                    couponBilling.NumCoupon = 0;
                    couponBilling.PriceT1 = 1;
                    couponBilling.PriceT2 = (decimal)1.5;
                    couponBilling.PriceT3 = 2;
                    subscriber.CouponBillingSubscribers.Add(couponBilling);
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
                    return await context.Subscribers.Include(x => x.IdCountryNavigation).Where(x => x.Code.Contains(code) && x.Name.Contains(name) && x.Enable == true).OrderBy(x => x.Code).ToListAsync();

                }
                else
                {
                    return await context.Subscribers.Include(x => x.IdCountryNavigation).Where(x => x.Code.Contains(code) && x.Name.Contains(name)).OrderBy(x => x.Code).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<Subscriber>();
            }
        }
        public async Task<List<Subscriber>> GetSolicitados()
        {
            try
            {
                using var context = new SqlCoreContext();
                var subscribers = await context.Tickets.Include(x => x.IdSubscriberNavigation)
                     .Where(x => x.IdStatusTicket != (int?)TicketStatusEnum.Despachado_con_Observacion && x.Enable == true
                    && x.IdStatusTicket != (int?)TicketStatusEnum.Rechazado
                    && x.IdStatusTicket != (int?)TicketStatusEnum.Anulado_Por_Abonado
                    && x.IdStatusTicket != (int?)TicketStatusEnum.Por_Despachar_Con_Observaciones
                    && x.IdStatusTicket != (int?)TicketStatusEnum.Anulado_Por_DRR
                    && x.IdStatusTicket != (int?)TicketStatusEnum.Anulado_Por_FaltaDatos
                    && x.IdStatusTicket != (int?)TicketStatusEnum.Anulado_Por_Supervisor
                    && x.IsComplement == false)
                    .Select(x => x.IdSubscriberNavigation).Distinct().OrderBy(x=>x.Code).ToListAsync();
                return subscribers;
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
