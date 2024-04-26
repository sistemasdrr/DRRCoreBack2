using DRRCore.Domain.Entities.SQLContext;

namespace DRRCore.Infraestructure.Interfaces.Repository
{
    public interface IAttachmentsNotSendRepository
    {
        Task<bool> AddAsync(AttachmentsNotSend obj);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(AttachmentsNotSend obj);
        Task<List<AttachmentsNotSend>> GetByEmailHistoryIdAsync(int id);
        Task<List<AttachmentsNotSend>> GetAllAsync();
    }
}
