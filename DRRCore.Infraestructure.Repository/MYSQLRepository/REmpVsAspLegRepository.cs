using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.MYSQLRepository
{
    public class REmpVsAspLegRepository : IREmpVsAspLegRepository
    {
        public async Task<List<REmpVsAspLeg>> GetAllREmpVsAspLegAsync()
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.REmpVsAspLegs.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<REmpVsAspLeg> GetREmpVsAspLegByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.REmpVsAspLegs.FirstOrDefaultAsync(x => x.EmCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
