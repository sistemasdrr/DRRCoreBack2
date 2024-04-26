using DRRCore.Application.DTO.Core.Response;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly ILogger _logger;
        public ProviderRepository(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<bool> AddAsync(Provider obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                await context.Providers.AddAsync(obj);
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
                var provider = await context.Providers.FindAsync(id);
                if(provider != null)
                {
                    provider.Enable = false;
                    provider.DeleteDate = DateTime.Now; 
                    context.Providers.Update(provider);
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

        public Task<List<Provider>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Provider> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var provider = await context.Providers.FindAsync(id);
                if (provider != null)
                {
                    return provider;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public Task<List<Provider>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Provider>> GetProviderByIdCompany(int idCompany)
        {
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.Providers.Include(x => x.IdCountryNavigation).Where(x => x.IdCompany == idCompany && x.Enable == true && x.Flag == true).ToListAsync();
                return list;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<List<Provider>> GetProviderByIdPerson(int idPerson)
        {
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.Providers.Include(x => x.IdCountryNavigation).Where(x => x.IdPerson == idPerson && x.Enable == true).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<List<GetProviderHistoryResponseDto>> GetProvidersHistoryByIdCompany(int idCompany)
        {
            var list = new List<GetProviderHistoryResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var providers = await context.Providers
                    .Where(x => x.IdCompany == idCompany)
                    .Select(x => new GetProviderHistoryResponseDto
                    {
                        Ticket = x.Ticket,
                        NumReferences = context.Providers.Count(p => p.IdTicket == x.IdTicket && p.IdCompany == idCompany),
                        ReferentName = x.ReferentName,
                        Date = StaticFunctions.DateTimeToString(x.DateReferent)
                    })                               
                    .ToListAsync();

                foreach (var item in providers)
                {
                    if (!list.Any(x => x.Ticket == item.Ticket))
                    {                       
                        list.Add(item);
                    }
                }
              

                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }


        public async Task<List<GetProviderHistoryResponseDto>> GetProvidersHistoryByIdPerson(int idPerson)
        {
            try
            {
                using var context = new SqlCoreContext();
                var providers = await context.Providers
                    .Where(x => x.IdPerson == idPerson)
                    .Select(x => new GetProviderHistoryResponseDto
                    {
                        Ticket = x.Ticket,
                        NumReferences = context.Providers.Count(p => p.IdTicket == x.IdTicket),
                        ReferentName = x.ReferentName,
                        Date = StaticFunctions.DateTimeToString(x.DateReferent)
                    })
                    .Distinct()
                    .ToListAsync();

                return providers;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }
    

        public async Task<bool> UpdateAsync(Provider obj)
        {
            try
            {
                using var context = new SqlCoreContext();
                obj.UpdateDate = DateTime.Now;
                obj.LastUpdateUser = 1;
                context.Providers.Update(obj);
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
