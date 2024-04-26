using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.MYSQLRepository
{
    public class REmpVsBaRepository : IREmpVsBaRepository
    {
        public async Task<List<REmpVsBa>> GetAllREmpVsBaAsync()
        {
            try
            {
                using(var context = new MySqlContext())
                {
                    return await context.REmpVsBas.ToListAsync();
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<REmpVsBa> GetREmpVsBaByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.REmpVsBas.FirstOrDefaultAsync(x => x.EmCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
