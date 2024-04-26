using DRRCore.Domain.Entities.SqlContext;
using DRRCore.Domain.Entities.SQLContext;
using DRRCore.Infraestructure.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.SQLRepository
{
    public class EmailHistoryRepository : IEmailHistoryRepository
    {
        public async Task<bool> AddAsync(EmailHistory obj)
        {
            try { 
            using( var context = new SqlContext())
            {
                await context.AddAsync(obj);
                context.SaveChanges();
                return true;
            }
            }catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using (var context = new SqlContext())
                {
                    var obj = await context.EmailHistories.FindAsync(id);
                    if (obj != null)
                    {
                        obj.Enable = false;
                        context.EmailHistories.Update(obj);
                        await context.SaveChangesAsync();
                    }
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<EmailHistory>> GetAllAsync()
        {
            using (var context = new SqlContext())
            {
                return await context.EmailHistories.Where(e=>e.Enable.Value).ToListAsync();
            }
        }

        public async Task<EmailHistory> GetById(int id)
        {
            using (var context = new SqlContext())
            {
                var response = await context.EmailHistories.FindAsync(id);
                if(response != null)
                {
                    return response;
                }
                return new EmailHistory();
            }
        }

        public Task<EmailHistory> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmailHistory>> GetByUserAsync(string user)
        {
            using (var context = new SqlContext())
            {
                return await context.EmailHistories.Where(e => e.Subject == user && e.Enable.Value).ToListAsync();
            }
        }

        public async Task<List<EmailHistory>> GetEmailNotSendAsync()
        {
            using (var context = new SqlContext())
            {
                return await context.EmailHistories.Where(e => !e.Success.Value && e.IdEmailHistory>=1410).ToListAsync();
            }
        }
        public async Task<bool> UpdateAsync(EmailHistory obj)
        {
            try
            {
                using(var context = new SqlContext()) 
                {
                    context.EmailHistories.Update(obj);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
