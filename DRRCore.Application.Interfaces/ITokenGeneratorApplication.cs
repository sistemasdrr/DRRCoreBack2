using DRRCore.Transversal.Common;

namespace DRRCore.Application.Interfaces
{
    public interface ITokenGeneratorApplication
    {
        Task<Response<string>> GetTokenAsync();
    }
}
