using DRRCore.Domain.Entities.SqlContext;
using DRRCore.Domain.Entities.SQLContext;
using DRRCore.Infraestructure.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.SQLRepository
{
    public class AttachmentsNotSendRepository : IAttachmentsNotSendRepository
    {
        public async Task<bool> AddAsync(AttachmentsNotSend obj)
        {
            try
            {
                using (var context = new SqlContext())
                {
                    await context.AttachmentsNotSends.AddAsync(obj);
                    await context.SaveChangesAsync();
                    return true;
                }
            } catch
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
                    var obj= await context.AttachmentsNotSends.FindAsync(id);
                    if (obj != null)
                    {                        
                        context.AttachmentsNotSends.Remove(obj);
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

        public async Task<List<AttachmentsNotSend>> GetAllAsync()
        {
            using (var context = new SqlContext())
                {
                    return await context.AttachmentsNotSends.ToListAsync();                   
                }
        }

        public async Task<List<AttachmentsNotSend>> GetByEmailHistoryIdAsync(int id)
        {
            using (var context = new SqlContext())
            {
                var response= await context.AttachmentsNotSends.Where(e=>e.IdEmailHistory==id).ToListAsync();
                if(response != null)
                {
                    return response;
                }
            }
            return new List<AttachmentsNotSend>();
        }

        public async Task<bool> UpdateAsync(AttachmentsNotSend obj)
        {
            try
            {
                using (var context = new SqlContext())
                {
                    context.AttachmentsNotSends.Update(obj);
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
