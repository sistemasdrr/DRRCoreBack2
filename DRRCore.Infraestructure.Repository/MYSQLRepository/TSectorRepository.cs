using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.MYSQLRepository
{
    public class TSectorRepository : ITSectorRepository
    {
        public async Task<List<TSector>> GetAllTSectorAsync()
        {
            try
            {
                using(var context = new MySqlContext())
                {
                    return await context.TSectors.ToListAsync();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TSector> GetTSectorByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TSectors.FirstOrDefaultAsync(x => x.SecCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
