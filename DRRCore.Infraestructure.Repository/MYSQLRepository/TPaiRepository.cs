using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.MYSQLRepository
{
    public class TPaiRepository : ITPaiRepository
    {
        public async Task<List<TPai>> GetAllTPaisAsync()
        {
            try 
            {
                using(var context = new MySqlContext())
                {
                    return await context.TPais.ToListAsync();
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<TPai> GetTPaiByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TPais.FirstOrDefaultAsync(x => x.PaiCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
