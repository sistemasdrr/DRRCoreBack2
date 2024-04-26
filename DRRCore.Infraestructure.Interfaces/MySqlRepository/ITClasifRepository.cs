using DRRCore.Domain.Entities.MYSQLContext;

namespace DRRCore.Infraestructure.Interfaces.MySqlRepository
{
    public interface ITClasifRepository
    {//Usp_ListarCalificacionEmpresa (BOTON RIESGO CREDITICIO)
        Task<TClasif> GetClasifByCodigoAsync(string codigo);
        Task<List<TClasif>> GetAllClasifAsync();
    }
}
