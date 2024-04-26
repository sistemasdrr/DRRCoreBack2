using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.MYSQLRepository
{
    public class RPerVsErRepository : IRPerVsErRepository
    {
        public async Task<List<RPerVsEr>> GetAllRPerVsErAsync()
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.RPerVsErs.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RPerVsEr> GetRPerVsErByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.RPerVsErs.FirstOrDefaultAsync(x => x.PeCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
