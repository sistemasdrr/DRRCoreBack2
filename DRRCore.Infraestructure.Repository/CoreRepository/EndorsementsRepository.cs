using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class EndorsementsRepository : IEndorsementsRepository
    {
        private readonly ILogger _logger;
        public EndorsementsRepository(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<bool> AddAsync(Endorsement obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                await context.Endorsements.AddAsync(obj);
                await context.SaveChangesAsync();
                return true;
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var endorsement = await context.Endorsements.FindAsync(id);
                if(endorsement != null)
                {
                    endorsement.DeleteDate = DateTime.Now;
                    endorsement.Enable = false;
                    endorsement.LastUpdateUser = 1;
                    context.Endorsements.Update(endorsement);
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
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }

        public Task<List<Endorsement>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Endorsement> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var endorsement = await context.Endorsements.FindAsync(id);
                if (endorsement != null)
                {
                    return endorsement;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public async Task<List<Endorsement>> GetByIdCompany(int idCompany)
        {
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.Endorsements.Where(x => x.IdCompany == idCompany && x.Enable == true).ToListAsync();
                if (list != null)
                {
                    return list;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public Task<List<Endorsement>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Endorsement obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                obj.UpdateDate = DateTime.Now;
                obj.LastUpdateUser = 1;
                context.Endorsements.Update(obj);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }
    }
}
