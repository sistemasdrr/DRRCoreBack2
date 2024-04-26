using DRRCore.Domain.Entities.SQLContext;
using DRRCore.Transversal.Common;

namespace DRRCore.Application.Interfaces.EmailApplication
{
    public interface IEmailConfiguration
    {
        Task<Response<bool>> AddAsync(EmailConfiguration obj);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<bool>> UpdateAsync(EmailConfiguration obj);
        Task<Response<List<EmailConfiguration>>> GetByNameAsync(string name);
        Task<Response<List<EmailConfiguration>>> GetAllAsync();
    }
}