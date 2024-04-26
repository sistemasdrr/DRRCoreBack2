using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ILogger _logger;
        public EmployeeRepository(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<bool> ActiveEmployeeAsync(int id)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    var obj = await context.Employees.FindAsync(id) ?? throw new Exception("No existe el empleado solicitado");
                    obj.Enable = true;
                    obj.DeleteDate = null;
                    context.Employees.Update(obj);
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

        public async Task<bool> AddAsync(Employee obj)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {                   
                    await context.Employees.AddAsync(obj);
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
                    var obj = await context.Employees.FindAsync(id) ?? throw new Exception("No existe el empleado solicitado");
                    obj.Enable = false;
                    obj.DeleteDate = DateTime.Now;
                    context.Employees.Update(obj);
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

        public async Task<Employee> FindByPersonalCode(string code)
        {
            try
            {
                using var context = new SqlCoreContext();
                var personal = await context.Personals.Where(x => x.Code == code).FirstOrDefaultAsync();
                if(personal != null)
                {
                    var employee = await context.Employees.Where(x => x.Id == personal.IdEmployee).FirstOrDefaultAsync();
                    if (employee != null)
                    {
                        return employee;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
                
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.Employees.Include(x=>x.IdJobDepartmentNavigation)
                    .Include(x => x.IdJobNavigation).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<Employee>();
            }
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.Employees.Include(x => x.IdJobNavigation).Include(x => x.IdJobDepartmentNavigation).Where(x=>x.Id==id).Include(x=>x.HealthInsurances).FirstOrDefaultAsync() ?? throw new Exception("No existe el empleado solicitado");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<List<Employee>> GetByNameAsync(string name)
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.Employees.Where(x => x.FirstName.Contains(name) || x.LastName.Contains(name)).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<Employee>();
            }
        }

        

        public async Task<bool> UpdateAsync(Employee obj)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    var healthInsurances = await context.HealthInsurances.Where(x => x.IdEmployee == obj.Id).ToListAsync();
                    if (healthInsurances.Any())
                    {
                        context.HealthInsurances.RemoveRange(healthInsurances);
                    }
                    obj.UpdateDate = DateTime.Now;
                    context.Employees.Update(obj);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
