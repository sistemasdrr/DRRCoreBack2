using AutoMapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Application.Main.CoreApplication
{
    public class BillingPersonalApplication : IBillingPersonalApplication
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public BillingPersonalApplication(IMapper mapper, ILogger logger) 
        {
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<bool>> AddOrUpdateBillingPersonal(AddOrUpdateBillingPersonal obj)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                if(obj.Id == 0)
                {
                    var newBillingPersonal = _mapper.Map<BillinPersonal>(obj);
                    await context.BillinPersonals.AddAsync(newBillingPersonal);
                    await context.SaveChangesAsync();
                }
                else
                {
                    var existingBillingPersonal = await context.BillinPersonals.Where(x => x.Id == obj.Id).FirstOrDefaultAsync();
                    if (existingBillingPersonal == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataFound;
                        _logger.LogError(response.Message);
                    }
                    existingBillingPersonal = _mapper.Map(obj, existingBillingPersonal);
                    existingBillingPersonal.UpdateDate = DateTime.Now;
                    context.BillinPersonals.Update(existingBillingPersonal);
                    await context.SaveChangesAsync();
                }
            }catch(Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> DeleteBillingPersonal(int id)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                var existingBillingPersonal = await context.BillinPersonals.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (existingBillingPersonal == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                }
                existingBillingPersonal.DeleteDate = DateTime.Now;
                existingBillingPersonal.Enable = false;
                context.BillinPersonals.Update(existingBillingPersonal);
                await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetBillingPersonalResponseDto>> GetBillingPersonalById(int id)
        {
            var response = new Response<GetBillingPersonalResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var existingBillingPersonal = await context.BillinPersonals.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (existingBillingPersonal == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                }
                response.Data = _mapper.Map<GetBillingPersonalResponseDto>(existingBillingPersonal);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetBillingPersonalResponseDto>>> GetBillingPersonalsByCode(string code)
        {
            var response = new Response<List<GetBillingPersonalResponseDto>>();
            response.Data = new List<GetBillingPersonalResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var billingPersonal = await context.BillinPersonals.Where(x => x.Code.Contains(code.Trim()) && x.Enable == true).ToListAsync();
                if (billingPersonal.Count == 0)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                }
                response.Data = _mapper.Map<List<GetBillingPersonalResponseDto>>(billingPersonal);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<List<GetBillingPersonalResponseDto>>> GetBillingPersonalsByIdEmployee(int idEmployee)
        {
            var response = new Response<List<GetBillingPersonalResponseDto>>();
            response.Data = new List<GetBillingPersonalResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var billingPersonal = await context.BillinPersonals.Where(x => x.IdEmployee == idEmployee && x.Enable == true).ToListAsync();
                if (billingPersonal.Count == 0)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                }
                response.Data = _mapper.Map<List<GetBillingPersonalResponseDto>>(billingPersonal);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<string>>> GetOtherUserCode(int idEmployee)
        {
            var response = new Response<List<string>>();
            response.Data = new List<string>();
            try
            {
                using var context = new SqlCoreContext();
                var personal = await context.Personals.Where(x => x.IdEmployee == idEmployee && (x.Type == "RP" || x.Type == "DI" || x.Type == "TR")).ToListAsync();
                foreach (var item in personal)
                {
                    response.Data.Add(item.Code);
                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
    }
}
