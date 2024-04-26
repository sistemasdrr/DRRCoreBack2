using DRRCore.Transversal.Common;

namespace DRRCore.Application.Interfaces
{
    public interface ITokenValidationApplication
    {
        Task<Response<bool>> ValidationTokenAsync();
        Task<Response<bool>> ValidationTokenAndEnvironmentAsync(string environment);
        Task<Response<string>> EncryptTokenAsync(string token);
        Task<Response<string>> decryptTokenAsync(string token);
      
    }
}
