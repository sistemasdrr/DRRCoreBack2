using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.MYSQLRepository
{
    public class TSituacionRepository : ITSituacionRepository
    {
        public async Task<List<TSituacion>> GetAllTSituacionAsync()
        {
            try
            {
                using(var context = new MySqlContext())
                {
                    return await context.TSituacions.ToListAsync();
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TSituacion> GetTSituacionByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TSituacions.FirstOrDefaultAsync(x => x.SitCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
