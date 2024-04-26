using DRRCore.Domain.Entities.SQLContext;
using DRRCore.Domain.Interfaces.EmailDomain;
using DRRCore.Infraestructure.Interfaces.Repository;

namespace DRRCore.Domain.Main.EmailDomain
{
    public class AttachmentsNotSendDomain : IAttachmentsNotSendDomain
    {
        private readonly IAttachmentsNotSendRepository _attachmentsNotSendRepository;
        public AttachmentsNotSendDomain(IAttachmentsNotSendRepository attachmentsNotSendRepository)
        {
            _attachmentsNotSendRepository = attachmentsNotSendRepository;
        }
        public async Task<bool> AddAsync(AttachmentsNotSend obj)
        {
            return await _attachmentsNotSendRepository.AddAsync(obj);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _attachmentsNotSendRepository.DeleteAsync(id);
        }
        public async Task<bool> UpdateAsync(AttachmentsNotSend obj)
        {
            return await _attachmentsNotSendRepository.UpdateAsync(obj);
        }
        public async Task<List<AttachmentsNotSend>> GetByIdAsync(int id)
        {
            return await _attachmentsNotSendRepository.GetByEmailHistoryIdAsync(id);
        }

        public async Task<List<AttachmentsNotSend>> GetAllAsync()
        {
            return await _attachmentsNotSendRepository.GetAllAsync();
        }

        public async Task<List<AttachmentsNotSend>> GetByEmailHistoryIdAsync(int id)
        {
            return await _attachmentsNotSendRepository.GetByEmailHistoryIdAsync(id);
        }
    }
}
