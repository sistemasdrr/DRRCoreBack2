using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class JobRepository : IJobRepository
    {
        private readonly ILogger _logger;
        public JobRepository(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<bool> AddAsync(Job obj)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    await context.Jobs.AddAsync(obj);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    var obj = await context.Jobs.FindAsync(id) ?? throw new Exception("No existe el país solicitado");
                    obj.Enable = false;
                    context.Jobs.Update(obj);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<List<Job>> GetAllAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.Jobs.Where(x => x.Enable == true).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<Job>();
            }
        }

        public async Task<Job> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.Jobs.FindAsync(id) ?? throw new Exception("No existe el objeto solicitado");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<List<Job>> GetByNameAsync(string name)
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.Jobs.Where(x => x.Name.Contains(name)).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<Job>();
            }
        }

        public async Task<List<Job>> GetJobByDepartment(int idDepartment)
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.Jobs.Where(x=>x.IdJobDepartment==idDepartment).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<Job>();
            }
        }

        public async Task<bool> UpdateAsync(Job obj)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    context.Jobs.Update(obj);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
