using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.MYSQLRepository
{
    public class TTemporalPersonaRepository : ITTemporalPersonaRepository
    {
        public async Task<List<TTemporalPersona>> GetAllTemporalPersonaAsync()
        {
            try
            {
                using(var context = new MySqlContext()) 
                {
                    return await context.TTemporalPersonas.ToListAsync();
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TTemporalPersona> GetTemporalPersonaByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TTemporalPersonas.FirstOrDefaultAsync(x => x.PeCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
