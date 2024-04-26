using DRRCore.Domain.Entities.SQLContext;
using DRRCore.Domain.Interfaces.EmailDomain;
using DRRCore.Infraestructure.Interfaces.Repository;

namespace DRRCore.Domain.Main.EmailDomain
{
    public class EmailConfigurationDomain : IEmailConfigurationDomain
    {
        private readonly IEmailConfigurationRepository _repository;
        public EmailConfigurationDomain(IEmailConfigurationRepository repository)
        {

            _repository = repository;
        }
        public async Task<bool> AddAsync(EmailConfiguration obj)
        {
            return await _repository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<List<EmailConfiguration>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<EmailConfiguration> GetByNameAsync(string name)
        {
            return await _repository.GetByNameAsync(name);
        }

        public async Task<EmailConfiguration> GetValueByName(string name)
        {
            return await _repository.GetValueByNameAsync(name);
        }

        public Task<bool> UpdateAsync(EmailConfiguration obj)
        {
            return _repository.UpdateAsync(obj);
        }
    }
}
