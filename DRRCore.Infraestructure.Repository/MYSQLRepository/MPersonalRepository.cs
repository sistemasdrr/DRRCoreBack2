using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.MYSQLRepository
{
    public class MPersonalRepository : IMPersonalRepository
    {
        public async Task<List<MPersonal>> GetAllActivePersonal()
        {
            using (var context = new MySqlContext())
            {
                return await context.MPersonals.Where(x => x.PerActivo == 1).ToListAsync();
            }
        }
    }
}
