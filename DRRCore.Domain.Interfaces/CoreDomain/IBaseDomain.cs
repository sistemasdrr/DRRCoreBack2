namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IBaseDomain<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetByNameAsync(string name);
        Task<bool> AddAsync(T obj);
        Task<bool> UpdateAsync(T obj);
        Task<bool> DeleteAsync(int id);
    }
}
