using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IUserLoginRepository : IBaseRepository<UserLogin>
    {
        Task<UserLogin> UserLogin(string username, string password);
        Task<int?> GetIdUserByIdEmployee(int idEmployee);
        Task<List<UserLogin>> GetUserLoginEmails();
    }
}
