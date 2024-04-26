using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class JobDepartmentRepository:IJobDepartmentRepository
    {
        private readonly ILogger _logger;
        public JobDepartmentRepository(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<bool> AddAsync(JobDepartment obj)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    await context.JobDepartments.AddAsync(obj);
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
                    var obj = await context.JobDepartments.FindAsync(id) ?? throw new Exception("No existe el país solicitado");
                    obj.Enable = false;
                    context.JobDepartments.Update(obj);
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

        public async Task<List<JobDepartment>> GetAllAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.JobDepartments.Where(x => x.Enable == true).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<JobDepartment>();
            }
        }

        public async Task<JobDepartment> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.JobDepartments.FindAsync(id) ?? throw new Exception("No existe el país solicitado");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new JobDepartment();
            }
        }

        public Task<List<JobDepartment>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(JobDepartment obj)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    context.JobDepartments.Update(obj);
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
