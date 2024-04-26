using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.MYSQLRepository
{
    public class TJuridiRepository : ITJuridiRepository
    {
        public async Task<List<TJuridi>> GetAllTJuridiAsync()
        {
            try
            {
                using(var context = new MySqlContext())
                {
                    return await context.TJuridis.ToListAsync();
                }
            }catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TJuridi> GetTJuridiByCodigoAsync(string codigo)
        {
            try
            {
                using(var context = new MySqlContext())
                {
                    return await context.TJuridis.FirstOrDefaultAsync(x => x.JuCodigo == codigo);
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
