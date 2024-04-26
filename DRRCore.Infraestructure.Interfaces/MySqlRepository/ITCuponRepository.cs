using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Infraestructure.Interfaces.MySqlRepository
{
    public interface ITCuponRepository
    {
        Task<TCupon> GetTCuponByCodigoAsync(int codigo);
        Task<List<TCupon>> GetAllTCuponAsync();
        Task<List<TCupon>> GetTCuponByPersonaOrEmpresaAsync(string codigo);
        Task<List<TCupon>> GetTCuponExistAsync(string codigo);
        Task<List<TCupon>> GetAllTCuponByRequestedNameAsync(string name);
    }
}
