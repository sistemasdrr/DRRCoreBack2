using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.MYSQLRepository
{
    public class TRepComRepository : ITRepComRepository
    {
        public async Task<List<TRepCom>> GetAllTRepComAsync()
        {
            try
            {
                using(var context = new MySqlContext()) 
                {
                    return await context.TRepComs.ToListAsync();
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TRepCom> GetTRepComByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TRepComs.FirstOrDefaultAsync(x => x.RcCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
