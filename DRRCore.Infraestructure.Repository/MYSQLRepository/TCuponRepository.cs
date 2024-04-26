using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.MYSQLRepository
{
    public class TCuponRepository : ITCuponRepository
    {
        public async Task<List<TCupon>> GetAllTCuponAsync()
        {
            try
            {
                using(var context = new MySqlContext())
                {
                    return await context.TCupons.ToListAsync();
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<TCupon>> GetAllTCuponByRequestedNameAsync(string name)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TCupons.Where(x=>x.CupNomsol.Contains(name)).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TCupon> GetTCuponByCodigoAsync(int codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TCupons.FirstOrDefaultAsync(x => x.CupCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TCupon>> GetTCuponByPersonaOrEmpresaAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TCupons.Where(x => x.EpCodigo == codigo).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<TCupon>> GetTCuponExistAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TCupons.Where(x => x.EpCodigo == codigo).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
