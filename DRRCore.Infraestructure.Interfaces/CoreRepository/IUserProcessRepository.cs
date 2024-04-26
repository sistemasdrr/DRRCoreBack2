using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IUserProcessRepository : IBaseRepository<UserProcess>
    {
        Task<List<UserProcess>> GetProcessByIdUser(int id);
        Task<bool> AddProcess(int idUser, int idProcess);
        Task<bool> DeleteProcess(int idUser, int idProcess);
        Task<bool> AddAllProcess(int idUser);
    }
}
