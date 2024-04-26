using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Infraestructure.Interfaces.MySqlRepository
{
    public interface IMySqlWebRepository
    {
        Task<int> Count();
        Task<List<ViewConsultaWeb>> Get();       

    }
}
