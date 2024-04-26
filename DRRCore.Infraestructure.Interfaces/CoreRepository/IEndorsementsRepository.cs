using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IEndorsementsRepository : IBaseRepository<Endorsement>
    {
        Task<List<Endorsement>> GetByIdCompany(int idCompany);
    }
}
