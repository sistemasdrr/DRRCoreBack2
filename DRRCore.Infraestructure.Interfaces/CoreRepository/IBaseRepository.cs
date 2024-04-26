using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetByNameAsync(string name);
        Task<bool> AddAsync(T obj);
        Task<bool> UpdateAsync(T obj);
        Task<bool> DeleteAsync(int id);
    }
}
