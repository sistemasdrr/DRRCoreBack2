using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Domain.Interfaces.MysqlDomain
{
    public interface IMPersonalDomain
    {
        Task<List<MPersonal>> GetAllActivePersonal();
    }
}
