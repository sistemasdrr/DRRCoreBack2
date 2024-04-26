using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class UserProcessDomain : IUserProcessDomain
    {
        private readonly IUserProcessRepository _repository;
        public UserProcessDomain(IUserProcessRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddAllProcess(int idUser)
        {
            return await _repository.AddAllProcess(idUser);
        }

        public async Task<bool> AddAsync(UserProcess obj)
        {
            return await _repository.AddAsync(obj);
        }

        public async Task<bool> AddProcess(int idUser, int idProcess)
        {
            return await _repository.AddProcess(idUser, idProcess);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<bool> DeleteProcess(int idUser, int idProcess)
        {
            return await _repository.DeleteProcess(idUser, idProcess);
        }

        public async Task<List<UserProcess>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<UserProcess> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<UserProcess>> GetByNameAsync(string name)
        {
            return await _repository.GetByNameAsync(name);
        }

        public async Task<List<UserProcess>> GetProcessByIdUser(int id)
        {
            return await _repository.GetProcessByIdUser(id);
        }

        public async Task<bool> UpdateAsync(UserProcess obj)
        {
            return await _repository.UpdateAsync(obj);
        }
    }
}
