using DRRCore.Domain.Entities.SQLContext;

namespace DRRCore.Infraestructure.Interfaces.Repository
{
    public interface IEmailConfigurationRepository
    {
        Task<bool> AddAsync(EmailConfiguration obj);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(EmailConfiguration obj);
        Task<EmailConfiguration> GetByNameAsync(string name);
        Task<List<EmailConfiguration>> GetAllAsync();
        Task<EmailConfiguration> GetValueByNameAsync(string name);
    }
}
