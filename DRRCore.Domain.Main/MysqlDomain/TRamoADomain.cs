using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Interfaces.MysqlDomain;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;

namespace DRRCore.Domain.Main.MysqlDomain
{
    public class TRamoADomain : ITRamoADomain
    {
        public readonly ITRamoARepository _repository;
        public TRamoADomain(ITRamoARepository repository)
        {
            _repository = repository;
        }
        public async Task<List<TRamoA>> GetAllTRamoAAsync()
        {
            return await _repository.GetAllTRamoAAsync();
        }

        public async Task<TRamoA> GetTRamoAByCodigoAsync(string codigo)
        {
            return await _repository.GetTRamoAByCodigoAsync(codigo);
        }
    }
}
