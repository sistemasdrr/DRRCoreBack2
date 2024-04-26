using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Domain.Interfaces.MysqlDomain
{
    public interface ITCuponDomain
    {
        Task<TCupon> GetTCuponByCodigoAsync(int codigo);
        Task<List<TCupon>> GetAllTCuponAsync();
        Task<List<TCupon>> GetTCuponByPersonaOrEmpresaAsync(string codigo);
        Task<List<TCupon>> GetTCuponExistAsync(string codigo);
        Task<List<TCupon>> GetAllTCuponByRequestedNameAsync(string name);
    }
}
