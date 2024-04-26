

using DRRCore.Domain.Entities.SQLContext;

namespace DRRCore.Domain.Interfaces.EmailDomain
{
    public interface IEmailConfigurationDomain
    {
        Task<bool> AddAsync(EmailConfiguration obj);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(EmailConfiguration obj);
        Task<EmailConfiguration> GetByNameAsync(string name);
        Task<List<EmailConfiguration>> GetAllAsync();
        Task<EmailConfiguration> GetValueByName(string name);
    }
}
