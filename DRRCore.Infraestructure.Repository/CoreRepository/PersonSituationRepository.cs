using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class PersonSituationRepository : IPersonSituationRepository
    {
        private readonly ILogger _logger;
        public PersonSituationRepository(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<bool> AddAsync(PersonSituation obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                await context.PersonSituations.AddAsync(obj);
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
                var personSituation = await context.PersonSituations.FindAsync(id);
                if (personSituation != null)
                {
                    return false;
                }
                else
                {
                    personSituation.DeleteDate = DateTime.Now;
                    personSituation.Enable = false;
                    context.PersonSituations.Update(personSituation);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }

        public async Task<List<PersonSituation>> GetAllAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.PersonSituations.Where(x => x.Enable == true).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public async Task<PersonSituation> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var personSituation = await context.PersonSituations.FindAsync(id);
                if (personSituation != null)
                {
                    return null;
                }
                else
                {
                    return personSituation;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public Task<List<PersonSituation>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(PersonSituation obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                obj.UpdateDate = DateTime.Now;
                context.PersonSituations.Update(obj);
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
