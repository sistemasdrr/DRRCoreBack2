using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.MYSQLRepository
{
    public class TRamoRepository : ITRamoRepository
    {
        public async Task<List<TRamo>> GetAllTRamoAsync()
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TRamos.ToListAsync();
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TRamo> GetTRamoByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TRamos.FirstOrDefaultAsync(x => x.RamCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
