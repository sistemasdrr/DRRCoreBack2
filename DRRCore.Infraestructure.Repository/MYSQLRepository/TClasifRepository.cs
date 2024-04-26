using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.MYSQLRepository
{
    public class TClasifRepository : ITClasifRepository
    {
        public async Task<List<TClasif>> GetAllClasifAsync()
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TClasifs.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TClasif> GetClasifByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TClasifs.FirstOrDefaultAsync(x => x.CrCodigo == codigo);
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
