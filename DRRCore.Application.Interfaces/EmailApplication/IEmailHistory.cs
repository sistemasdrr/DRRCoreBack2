using DRRCore.Domain.Entities.SQLContext;
using DRRCore.Transversal.Common;

namespace DRRCore.Application.Interfaces.EmailApplication
{
    public interface IEmailHistory
    {
        Response<bool> AddAsync(EmailHistory obj);
        Response<bool> DeleteAsync(int id);
        Response<bool> UpdateAsync(EmailHistory obj);
        Response<List<EmailHistory>> GetAllAsync();
        Response<List<EmailHistory>> GetByUser(string user);
        Response<List<EmailHistory>> GetEmailNotSend();
    }
}
