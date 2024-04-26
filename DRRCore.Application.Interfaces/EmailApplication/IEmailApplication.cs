using DRRCore.Application.DTO.Email;
using DRRCore.Transversal.Common;

namespace DRRCore.Application.Interfaces.EmailApplication
{
    public interface IEmailApplication
    {
        Task<Response<bool>> SendMailAsync(EmailDataDTO emailDataDto);
        Task<Response<bool>> ReSendMailAsync();
        Task<Response<string>> ConvertFileToBase64(string path);
    }
}
