using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.MYSQLRepository
{
    public class TPagoRepository : ITPagoRepository
    {
        public async Task<List<TPago>> GetAllTPagoAsync()
        {
            try
            {
                using(var context = new MySqlContext())
                {
                    return await context.TPagos.ToListAsync();
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TPago> GetTPagoByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TPagos.FirstOrDefaultAsync(x => x.PaCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
