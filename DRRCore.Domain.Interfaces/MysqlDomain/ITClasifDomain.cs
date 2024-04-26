using DRRCore.Domain.Entities.MYSQLContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRCore.Domain.Interfaces.MysqlDomain
{
    public interface ITClasifDomain
    {
        Task<TClasif> GetClasifByCodigoAsync(string codigo);
        Task<List<TClasif>> GetAllClasifAsync();
    }
}
