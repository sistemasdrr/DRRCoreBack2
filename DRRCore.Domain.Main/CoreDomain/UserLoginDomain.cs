using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class UserLoginDomain : IUserLoginDomain
    {
        private readonly IUserLoginRepository _repository;
        public UserLoginDomain(IUserLoginRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddAsync(UserLogin obj)
        {
            return await _repository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<List<UserLogin>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<UserLogin> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<UserLogin>> GetByNameAsync(string name)
        {
            return await _repository.GetByNameAsync(name);
        }

        public async Task<int?> GetIdUserByIdEmployee(int idEmployee)
        {
            return await _repository.GetIdUserByIdEmployee(idEmployee);
        }

        public async Task<List<UserLogin>> GetUserLoginEmails()
        {
            return await _repository.GetUserLoginEmails();
        }

        public async Task<bool> UpdateAsync(UserLogin obj)
        {
            return await _repository.UpdateAsync(obj);
        }

        public async Task<UserLogin> UserLogin(string username, string password)
        {
            return await _repository.UserLogin(username, password);
        }
    }
}
