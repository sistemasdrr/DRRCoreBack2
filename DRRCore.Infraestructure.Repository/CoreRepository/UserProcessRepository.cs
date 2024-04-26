using AspNetCore.ReportingServices.ReportProcessing.ReportObjectModel;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class UserProcessRepository : IUserProcessRepository
    {
        private readonly ILogger _logger;
        public UserProcessRepository(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<bool> AddAllProcess(int idUser)
        {
            try
            {
                using var context = new SqlCoreContext();
                var process = await context.Processes.Where(x => x.Enable == true).ToListAsync();
                if (process != null)
                {
                    foreach (var item in process)
                    {
                        var newProcess = new UserProcess();
                        newProcess.Id = 0;
                        newProcess.IdUser = idUser;
                        newProcess.IdProcess = item.Id;
                        newProcess.Enable = false;
                        await context.UserProcesses.AddAsync(newProcess);
                        await context.SaveChangesAsync();
                    }
                }
                return true;
            }catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return false;
            }
        }

        public async Task<bool> AddAsync(UserProcess obj)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    await context.UserProcesses.AddAsync(obj);
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

        public async Task<bool> AddProcess(int idUser, int idProcess)
        {
            try
            {
                using var context = new SqlCoreContext();

                var existingProcess = await context.UserProcesses.FirstOrDefaultAsync(x => x.IdUser == idUser && x.IdProcess == idProcess);
                if(existingProcess != null)
                {
                    existingProcess.Enable = true; 
                    context.UserProcesses.Update(existingProcess);
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    var newProcess = new UserProcess();
                    newProcess.Id = 0;
                    newProcess.IdUser = idUser;
                    newProcess.IdProcess = idProcess;
                    await context.UserProcesses.AddAsync(newProcess);
                    await context.SaveChangesAsync();
                    return true;
                }
                
            }catch(Exception ex)
            {
                _logger?.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    var obj = await context.UserProcesses.FindAsync(id) ?? throw new Exception("No existe el país solicitado");
                    obj.Enable = false;
                    context.UserProcesses.Update(obj);
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

        public async Task<bool> DeleteProcess(int idUser, int idProcess)
        {
            try
            {
                using var context = new SqlCoreContext();

                var existingProcess = await context.UserProcesses.FirstOrDefaultAsync(x => x.IdUser == idUser && x.IdProcess == idProcess);
                if (existingProcess != null)
                {
                    existingProcess.Enable = false;
                    context.UserProcesses.Update(existingProcess);
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    var newProcess = new UserProcess();
                    newProcess.Id = 0;
                    newProcess.IdUser = idUser;
                    newProcess.IdProcess = idProcess;
                    newProcess.Enable = false;
                    await context.UserProcesses.AddAsync(newProcess);
                    await context.SaveChangesAsync();
                    return true;
                }

            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.Message);
                return false;
            }
        }

        public Task<List<UserProcess>> GetAllAsync()
        {
           throw new NotImplementedException();
        }

        public async Task<UserProcess> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.UserProcesses.FindAsync(id) ?? throw new Exception("No existe el objeto solicitado");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<List<UserProcess>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserProcess>> GetProcessByIdUser(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.UserProcesses.Include(x => x.IdProcessNavigation).Where(x => x.IdUser == id).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> UpdateAsync(UserProcess obj)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    var usrProcess = new UserProcess();
                    usrProcess.Id = obj.Id;
                    usrProcess.IdProcess = obj.IdProcess;
                    usrProcess.IdUser = obj.IdUser;
                    usrProcess.UpdateDate = DateTime.Now;
                    usrProcess.CreationDate = obj.CreationDate;
                    usrProcess.Enable = obj.Enable;
                    context.UserProcesses.Update(usrProcess);
                    context.SaveChanges();
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
