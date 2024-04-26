using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.MYSQLRepository
{
    public class REmpVsRamNegRepository : IREmpVsRamNegRepository
    {
        public async Task<List<REmpVsRamNeg>> GetAllREmpVsRamNegAsync()
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.REmpVsRamNegs.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<REmpVsRamNeg> GetREmpVsRamNegByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.REmpVsRamNegs.FirstOrDefaultAsync(x => x.EmCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
