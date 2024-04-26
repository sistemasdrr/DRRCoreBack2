using DRRCore.Domain.Entities.SQLContext;
using DRRCore.Domain.Interfaces.EmailDomain;
using DRRCore.Infraestructure.Interfaces.Repository;

namespace DRRCore.Domain.Main.EmailDomain
{
    public class EmailHistoryDomain : IEmailHistoryDomain
    {
        private readonly IEmailHistoryRepository _emailHistoryRepository;
        public EmailHistoryDomain(IEmailHistoryRepository emailHistoryRepository)
        {
            _emailHistoryRepository = emailHistoryRepository;
        }

        public async Task<bool> AddAsync(EmailHistory obj)
        {
            return await _emailHistoryRepository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _emailHistoryRepository.DeleteAsync(id);
        }

        public async Task<List<EmailHistory>> GetAllAsync()
        {
            return await _emailHistoryRepository.GetAllAsync();
        }

        public async Task<EmailHistory> GetByIdAsync(int id)
        {
            return await _emailHistoryRepository.GetByIdAsync(id);
        }

        public async Task<List<EmailHistory>> GetByUserAsync(string user)
        {
            return await _emailHistoryRepository.GetByUserAsync(user);
        }

        public async Task<List<EmailHistory>> GetEmailNotSendAsync()
        {
            return await _emailHistoryRepository.GetEmailNotSendAsync();
        }

        public async Task<bool> UpdateAsync(EmailHistory obj)
        {
            return await _emailHistoryRepository.UpdateAsync(obj);
        }
    }
}
