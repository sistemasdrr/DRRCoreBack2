using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;

namespace DRRCore.Domain.Main.MysqlDomain
{
    public class TCuponDomain : ITCuponDomain
    {
        public readonly ITCuponRepository _repository;
        public TCuponDomain(ITCuponRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<TCupon>> GetAllTCuponAsync()
        {
            return await _repository.GetAllTCuponAsync();
        }

        public async Task<List<TCupon>> GetAllTCuponByRequestedNameAsync(string name)
        {
            return await _repository.GetAllTCuponByRequestedNameAsync(name);
        }

        public async Task<TCupon> GetTCuponByCodigoAsync(int codigo)
        {
            return await _repository.GetTCuponByCodigoAsync(codigo);
        }

        public async Task<List<TCupon>> GetTCuponByPersonaOrEmpresaAsync(string codigo)
        {
            return await _repository.GetTCuponByPersonaOrEmpresaAsync(codigo);
        }

        public async Task<List<TCupon>> GetTCuponExistAsync(string codigo)
        {
            return await _repository.GetTCuponExistAsync(codigo);
        }
    }
}
