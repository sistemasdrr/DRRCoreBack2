using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IUserProcessDomain : IBaseDomain<UserProcess>
    {
        Task<List<UserProcess>> GetProcessByIdUser(int id);
        Task<bool> AddProcess(int idUser, int idProcess); 
        Task<bool> DeleteProcess(int idUser, int idProcess);
        Task<bool> AddAllProcess(int idUser);
    }
}
