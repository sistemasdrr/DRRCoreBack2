using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.MYSQLRepository
{
    public class TTipoTramiteRepository : ITTipoTramiteRepository
    {
        public async Task<List<TTipoTramite>> GetAllTTipoTramiteAsync()
        {
            try
            {
                using(var context = new MySqlContext())
                {
                    return await context.TTipoTramites.ToListAsync();
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TTipoTramite> GetTTipoTramiteByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TTipoTramites.FirstOrDefaultAsync(x => x.TramCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
