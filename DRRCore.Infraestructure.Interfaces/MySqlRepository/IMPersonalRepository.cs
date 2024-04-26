using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Infraestructure.Interfaces.MySqlRepository
{
    public interface IMPersonalRepository
    {
        Task<List<MPersonal>> GetAllActivePersonal();
    }
}
