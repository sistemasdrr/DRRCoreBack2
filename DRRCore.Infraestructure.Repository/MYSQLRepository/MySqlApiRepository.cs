using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Entities.SqlContext;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.MYSQLRepository
{
    public class MySqlApiRepository : IMySqlApiRepository
    {
        public async Task<MEmpresa> GetmEmpresaByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.MEmpresas.FirstOrDefaultAsync(x => x.EmCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
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

        public async Task<bool> DeleteRepComercialEmpresaAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    var obj = await context.REmpVsReps.FindAsync(codigo);
                    if (obj != null)
                    {
                        context.REmpVsReps.Remove(obj);
                        await context.SaveChangesAsync();
                    }
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<TClasif>> GetAllClasifAsync()
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TClasifs.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        public async Task<List<RCupVsAbo>> GetAllRCupVsAboAsync()
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.RCupVsAbos.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<REmpVsInfFin>> GetAllREmpVsInfAsync()
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.REmpVsInfFins.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<REmpVsRamNeg>> GetAllREmpVsRamNegAsync()
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.REmpVsRamNegs.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<RPerVsEr>> GetAllRPerVsErAsync()
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.RPerVsErs.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TCalidad>> GetAllTCalidadAsync()
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TCalidads.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TContinente>> GetAllTContinenteAsync()
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TContinentes.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TCupon>> GetAllTCuponAsync()
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TCupons.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TTemporalPersona>> GetAllTemporalPersonaAsync()
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TTemporalPersonas.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TJuridi>> GetAllTJuridiAsync()
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TJuridis.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TPago>> GetAllTPagoAsync()
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TPagos.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TPai>> GetAllTPaisAsync()
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TPais.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TRepCom>> GetAllTRepComAsync()
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TRepComs.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TSituacion>> GetAllTSituacionAsync()
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TSituacions.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TTipoTramite>> GetAllTTipoTramiteAsync()
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TTipoTramites.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TClasif> GetClasifByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TClasifs.FirstOrDefaultAsync(x => x.CrCodigo == codigo);
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
                using(var context = new MySqlContext())
                {
                    return await context.MPersonas.FirstOrDefaultAsync(x => x.PeCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RCupVsAbo> GetRCupVsAboByCodigoAsync(int codigo)
        {
            try
            {
                using(var context = new MySqlContext())
                {
                    return await context.RCupVsAbos.FirstOrDefaultAsync(x => x.EcCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<REmpVsAspLeg> GetRempByCodigoAsync(string codigo)
        {
            try
            {
                using(var context = new MySqlContext())
                {
                    return await context.REmpVsAspLegs.FirstOrDefaultAsync(x => x.EmCodigo == codigo);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<REmpVsInfFin> GetREmpVsInfByCodigoAsync(string codigo)
        {
            try
            {
                using(var context = new MySqlContext())
                {
                    return await context.REmpVsInfFins.FirstOrDefaultAsync(x => x.EmCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<REmpVsRamNeg> GetREmpVsRamNegByCodigoAsync(string codigo)
        {
            try
            {
                using(var context = new MySqlContext())
                {
                    return await context.REmpVsRamNegs.FirstOrDefaultAsync(x => x.EmCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RPerVsEr> GetRPerVsErByCodigoAsync(string codigo)
        {
            try
            {
                using(var context = new MySqlContext())
                {
                    return await context.RPerVsErs.FirstOrDefaultAsync(x => x.PeCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TCalidad> GetTCalidadByCodigoAsync(string codigo)
        {
            try
            {
                using(var context = new MySqlContext())
                {
                    return await context.TCalidads.FirstOrDefaultAsync(x => x.CalCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TContinente> GetTContinenteByCodigoAsync(string codigo)
        {
            try
            {
                using(var context = new MySqlContext())
                {
                    return await context.TContinentes.FirstOrDefaultAsync(x => x.ConCodigo == codigo);
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
                using(var context = new MySqlContext())
                {
                    return await context.TCupons.FirstOrDefaultAsync(x => x.CupCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TTemporalPersona> GetTemporalPersonaByCodigoAsync(string codigo)
        {
            try
            {
                using(var context = new MySqlContext())
                {
                    return await context.TTemporalPersonas.FirstOrDefaultAsync(x => x.PeCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<TJuridi> GetTJuridiByCodigoAsync(string codigo)
        {
            try
            {
                using(var context = new MySqlContext())
                {
                    return await context.TJuridis.FirstOrDefaultAsync(x => x.JuCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TPago> GetTPagoByCodigoAsync(string codigo)
        {
            try
            {
                using(var context = new MySqlContext())
                {
                    return await context.TPagos.FirstOrDefaultAsync(x => x.PaCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TPai> GetTPaiByCodigoAsync(string codigo)
        {
            try
            {
                using(var context = new MySqlContext())
                {
                    return await context.TPais.FirstOrDefaultAsync(x => x.PaiCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TRepCom> GetTRepComByCodigoAsync(string codigo)
        {
            try
            {
                using(var context = new MySqlContext())
                {
                    return await context.TRepComs.FirstOrDefaultAsync(x => x.RcCodigo == codigo);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TSituacion> GetTSituacionByCodigoAsync(string codigo)
        {
            try
            {
                using(var context = new MySqlContext())
                {
                    return await context.TSituacions.FirstOrDefaultAsync(x => x.SitCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TTipoTramite> GetTTipoTramiteByCodigoAsync(string codigo)
        {
            try
            {
                using(var context = new MySqlContext())
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
