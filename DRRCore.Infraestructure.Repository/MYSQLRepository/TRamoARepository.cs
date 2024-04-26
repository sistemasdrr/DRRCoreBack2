using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.MYSQLRepository
{
    public class TRamoARepository : ITRamoARepository
    {
        public MySqlContext context = new MySqlContext();
        public async Task<List<TRamoA>> GetAllTRamoAAsync()
        {
            using (context)
            {
                return await context.TRamoAs.ToListAsync();
            }
        }

        public async Task<TRamoA> GetTRamoAByCodigoAsync(string codigo)
        {
            using(var context = new MySqlContext())
            {
                return await context.TRamoAs.FirstOrDefaultAsync(x => x.RamCodigo == codigo);
            }
        }
    }
}
