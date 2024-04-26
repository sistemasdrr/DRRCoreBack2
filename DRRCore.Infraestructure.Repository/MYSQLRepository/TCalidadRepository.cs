
using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.MYSQLRepository
{
    public class TCalidadRepository : ITCalidadRepository
    {
        public async Task<List<TCalidad>> GetAllTCalidadAsync()
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TCalidads.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TCalidad> GetTCalidadByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TCalidads.FirstOrDefaultAsync(x => x.CalCodigo == codigo);
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
