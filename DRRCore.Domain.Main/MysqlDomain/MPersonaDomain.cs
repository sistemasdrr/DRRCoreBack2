using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;

namespace DRRCore.Domain.Main.MysqlDomain
{
    public class MPersonaDomain : IMPersonaDomain
    {
        public readonly IMPersonaRepository _repository;
        public MPersonaDomain(IMPersonaRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<MPersona>> GetAllMPersonaAsync()
        {
            return await _repository.GetAllMPersonaAsync();
        }

        public async Task<MPersona> GetMPersonaByCodigoAsync(string codigo)
        {
            return await _repository.GetMPersonaByCodigoAsync(codigo);
        }

        public async Task<MPersona> GetmPersonaByCodigoAsync(string codigo)
        {
            return await _repository.GetmPersonaByCodigoAsync(codigo);
        }

        public async Task<List<RPerVsSbd>> GetmPersonaEndBancByCodigoAsync(string codigo)
        {
            return await _repository.GetmPersonaEndBancByCodigoAsync(codigo);
        }

        public async Task<List<RPerVsProAcep>> GetmPersonaMorComByCodigoAsync(string codigo)
        {
            return await _repository.GetmPersonaMorComByCodigoAsync(codigo);
        }

        public async Task<List<RPerVsProv>> GetmPersonaProvByCodigoAsync(string codigo)
        {
            return await _repository.GetmPersonaProvByCodigoAsync(codigo);
        }

        public async Task<RPerVsRep> GetmPersonaReputacionByCodigoAsync(string codigo)
        {
            return await _repository.GetmPersonaReputacionByCodigoAsync(codigo);
        }

        public async Task<RPerVsTrab> GetmPersonaTrabajoByCodigoAsync(string codigo)
        {
            return await _repository.GetmPersonaTrabajoByCodigoAsync(codigo);
        }

        public async Task<List<MPersona>> GetNotMigratedPersona()
        {
            return await _repository.GetNotMigratedPersona();
        }

        public async Task<bool> MigratePersona(string codigo)
        {
            return await _repository.MigratePersona(codigo);
        }
    }
}
