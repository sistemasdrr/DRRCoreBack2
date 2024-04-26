using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Entities.SqlContext;
using DRRCore.Domain.Entities.SQLContext;
using DRRCore.Infraestructure.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.SQLRepository
{
    public class EmailConfigurationRepository : IEmailConfigurationRepository
    {
        public async Task<bool> AddAsync(EmailConfiguration obj)
        {
            try
            {
                using (var context = new SqlContext())
                {
                    await context.AddAsync(obj);
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
                    var obj = await context.EmailConfigurations.FindAsync(id);
                    if (obj != null)
                    {
                        context.EmailConfigurations.Remove(obj);
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

        public async Task<List<EmailConfiguration>> GetAllAsync()
        {
            using (var context = new SqlContext())
            {
                return await context.EmailConfigurations.ToListAsync();
            }
        }

        public async Task<EmailConfiguration> GetByNameAsync(string name)
        {
            using (var context = new SqlContext())
            {
                return await context.EmailConfigurations.Where(e => e.Name == name && e.Enable.Value).FirstOrDefaultAsync();
                
            }
        }

        public async Task<EmailConfiguration> GetValueByNameAsync(string name)
        {
            using (var context = new SqlContext())
            {
                return await context.EmailConfigurations.FirstOrDefaultAsync(x => x.Name == name);
            }; 
        }
    
        public async Task<bool> UpdateAsync(EmailConfiguration obj)
        {
            try
            {
                using(var context = new SqlContext())
                {
                    context.EmailConfigurations.Update(obj);
                    await context.SaveChangesAsync();
                    return true;
                }
            }catch
            {
                return false;
            }   
        }

    }
}
