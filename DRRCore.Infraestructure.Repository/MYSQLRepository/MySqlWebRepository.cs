using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.MYSQLRepository
{
    public class MySqlWebRepository : IMySqlWebRepository
    {
        public async Task<int> Count()
        {
            using var mysqlContext = new MySqlContext();
            return await mysqlContext.ViewConsultaWebs.CountAsync();
        }

        public async Task<List<ViewConsultaWeb>> Get()
        {           
            using var mysqlContext = new MySqlContext();     
            return await mysqlContext.ViewConsultaWebs.ToListAsync();           
        }
    }
}


