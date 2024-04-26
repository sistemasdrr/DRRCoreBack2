using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Infraestructure.Interfaces.MySqlRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DRRCore.Infraestructure.Repository.MYSQLRepository
{
    public class MEmpresaRepository : IMEmpresaRepository
    {
        public async Task<string> GetActividadesByCodigo(string codigo)
        {
            string actividades = "";
            try
            {
                using (var context = new MySqlContext())
                {
                    var list = await context.REmpVsActs.Where(x => x.EmCodigo == codigo).ToListAsync();
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (i == list.Count - 1)
                        {
                            var actividad = await context.TRamoBs.Where(x => x.RamBCodigo == list[i].RamBCodigo).FirstOrDefaultAsync();
                            if(actividad != null)
                            {
                                actividades += actividad.RamBNombre;
                            }
                        }
                        else
                        {
                            var actividad = await context.TRamoBs.Where(x => x.RamBCodigo == list[i].RamBCodigo).FirstOrDefaultAsync();
                            if (actividad != null)
                            {
                                actividades += actividad.RamBNombre + " - ";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return actividades;
        }

        public async Task<REmpVsAspLeg> GetmEmpresaAspLegByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.REmpVsAspLegs.FirstOrDefaultAsync(x => x.EmCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TCabEmpAval> GetmEmpresaAvalByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.TCabEmpAvals.FirstOrDefaultAsync(x => x.EmCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<REmpVsBa> GetmEmpresaBalanceByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.REmpVsBas.FirstOrDefaultAsync(x => x.EmCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<REmpVsB> GetmEmpresaBalanceSitByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.REmpVsBs.FirstOrDefaultAsync(x => x.EmCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

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

        public async Task<List<REmpVsSbd>> GetmEmpresaEndBancByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.REmpVsSbds.Where(x => x.EmCodigo == codigo).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<REmpVsExp>> GetmEmpresaExpByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.REmpVsExps.Where(x => x.EmCodigo == codigo).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<REmpVsInfFin> GetmEmpresaFinanzasByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.REmpVsInfFins.FirstOrDefaultAsync(x => x.EmCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<REmpVsVenta>> GetmEmpresaHistVentByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.REmpVsVentas.Where(x => x.EmCodigo == codigo).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<REmpVsImp>> GetmEmpresaImpByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.REmpVsImps.Where(x => x.EmCodigo == codigo).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<REmpVsProAcep>> GetmEmpresaMorComByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.REmpVsProAceps.Where(x => x.EmCodigo == codigo).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<REmpVsProv>> GetmEmpresaProvByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.REmpVsProvs.Where(x => x.EmCodigo == codigo).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<REmpVsRamNeg> GetmEmpresaRamoByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.REmpVsRamNegs.FirstOrDefaultAsync(x => x.EmCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<REmpVsRep> GetmEmpresaReputacionByCodigoAsync(string codigo)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    return await context.REmpVsReps.FirstOrDefaultAsync(x => x.EmCodigo == codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<MEmpresa>> GetNotMigratedEmpresa()
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    var empresas = await context.MEmpresas
                        .Where(x => x.EmCodigo== "E0001003807").ToListAsync();

                    empresas = empresas.Where(x => !x.EmCodigo.StartsWith('Z')).ToList();

                    return empresas;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<MEmpresa>> GetNotMigratedEmpresa(int migra)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    var empresas = await context.MEmpresas
                        .Where(x => x.Migra == migra && x.EmActivo == 1 && x.EmNombre != null).Take(100)
                        .ToListAsync();

                    empresas = empresas.Where(x => !x.EmCodigo.StartsWith('Z')).ToList();

                    return empresas;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<bool> MigrateEmpresa(string code)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    var empresa =await  GetmEmpresaByCodigoAsync(code);
                    if (empresa==null)
                    {
                        throw new Exception("No se encuentra la empresa");
                    }
                    empresa.Migra = 1;
                    context.MEmpresas.Update(empresa);
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
        public async Task<bool> MigrateEmpresaAspLeg(string code)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    var empresa = await GetmEmpresaAspLegByCodigoAsync(code);
                    if (empresa == null)
                    {
                        throw new Exception("No se encuentra la empresa");
                    }
                    empresa.Migra = 1;
                    context.REmpVsAspLegs.Update(empresa);
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

        public async Task<bool> MigrateEmpresaFinanzas(string code)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    var empresa = await GetmEmpresaFinanzasByCodigoAsync(code);
                    if (empresa == null)
                    {
                        throw new Exception("No se encuentra la empresa");
                    }
                    empresa.Migra = 1;
                    context.REmpVsInfFins.Update(empresa);
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

        public async Task<bool> MigrateEmpresaRamo(string code)
        {
            try
            {
                using (var context = new MySqlContext())
                {
                    var empresa = await GetmEmpresaRamoByCodigoAsync(code);
                    if (empresa == null)
                    {
                        throw new Exception("No se encuentra la empresa");
                    }
                    empresa.Migra = 1;
                    context.REmpVsRamNegs.Update(empresa);
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
