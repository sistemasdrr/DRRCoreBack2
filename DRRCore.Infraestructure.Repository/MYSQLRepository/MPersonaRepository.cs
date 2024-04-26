using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.MYSQLRepository
{
    public class MPersonaRepository : IMPersonaRepository
    {
        public async Task<List<MPersona>> GetAllMPersonaAsync()
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.MPersonas.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MPersona> GetMPersonaByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.MPersonas.FirstOrDefaultAsync(x => x.PeCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MPersona> GetmPersonaByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.MPersonas.FirstOrDefaultAsync(x => x.PeCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<RPerVsSbd>> GetmPersonaEndBancByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.RPerVsSbds.Where(x => x.PeCodigo == codigo && x.Migra == 0).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<RPerVsProAcep>> GetmPersonaMorComByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.RPerVsProAceps.Where(x => x.PeCodigo == codigo && x.Migra == 0).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<RPerVsProv>> GetmPersonaProvByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.RPerVsProvs.Where(x => x.PeCodigo == codigo && x.Migra == 0).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RPerVsRep> GetmPersonaReputacionByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.RPerVsReps.FirstOrDefaultAsync(x => x.PeCodigo == codigo && x.Migra == 0 && x.RcCodigo != "");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RPerVsTrab> GetmPersonaTrabajoByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.RPerVsTrabs.FirstOrDefaultAsync(x => x.PeCodigo == codigo && x.Migra == 0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<MPersona>> GetNotMigratedPersona()
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.MPersonas.Where(x => x.Migra == 0).Take(100).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> MigratePersona(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    var persona = await GetmPersonaByCodigoAsync(codigo);
                    if (persona == null)
                    {
                        throw new Exception("No se encuentra la persona");
                    }
                    persona.Migra = 1;
                    context.MPersonas.Update(persona);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }
        }
    }
}
