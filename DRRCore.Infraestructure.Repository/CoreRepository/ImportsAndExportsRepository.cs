using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class ImportsAndExportsRepository : IImportsAndExportsRepository
    {
        private readonly ILogger _logger;
        public ImportsAndExportsRepository(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<bool> AddAsync(ImportsAndExport obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                await context.AddAsync(obj);
                await context.SaveChangesAsync();
                return true;
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var importAndExport = await context.ImportsAndExports.FindAsync(id);
                if(importAndExport != null)
                {
                    importAndExport.Enable = false;
                    importAndExport.DeleteDate = DateTime.Now;
                    context.Update(importAndExport);
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }

        public Task<List<ImportsAndExport>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ImportsAndExport> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var importAndExport = await context.ImportsAndExports.FindAsync(id);
                return importAndExport;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public Task<List<ImportsAndExport>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ImportsAndExport>> GetExports(int idCompany)
        {
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.ImportsAndExports.Where(x => x.Enable == true && x.Type == "E" && x.IdCompany == idCompany).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public async Task<List<ImportsAndExport>> GetImports(int idCompany)
        {

            try
            {
                using var context = new SqlCoreContext();
                var list = await context.ImportsAndExports.Where(x => x.Enable == true && x.Type == "I" && x.IdCompany == idCompany).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public async Task<bool> UpdateAsync(ImportsAndExport obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                obj.UpdateDate = DateTime.Now;
                obj.LastUpdateUser = 1;
                context.Update(obj);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }
    }
}
