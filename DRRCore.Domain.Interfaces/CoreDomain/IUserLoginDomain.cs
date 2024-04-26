using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IUserLoginDomain : IBaseDomain<UserLogin>
    {
        Task<UserLogin> UserLogin(string username, string password);
        Task<int?> GetIdUserByIdEmployee(int idEmployee);
        Task<List<UserLogin>> GetUserLoginEmails();
    }
}
