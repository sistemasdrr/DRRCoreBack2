using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.MYSQLRepository
{
    public class TContinenteRepository : ITContinenteRepository
    {
        public async Task<List<TContinente>> GetAllTContinenteAsync()
        {
            try
            {
                using( var context = new MySqlContext() )
                {
                    return await context.TContinentes.ToListAsync();
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TContinente> GetTContinenteByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TContinentes.FirstOrDefaultAsync(x => x.ConCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
