using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.MYSQLRepository
{
    public class RCupVsAboRepository : IRCupVsAboRepository
    {
        public async Task<List<RCupVsAbo>> GetAllRCupVsAboAsync()
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.RCupVsAbos.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RCupVsAbo> GetRCupVsAboByCodigoAsync(int codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.RCupVsAbos.FirstOrDefaultAsync(x => x.EcCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
