using AutoMapper;
using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace DRRCore.Application.Main.CoreApplication
{
    public class AnniversayApplication : IAnniversaryApplication
    {
        private readonly IAnniversaryDomain _anniversaryDomain;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AnniversayApplication(IAnniversaryDomain anniversaryDomain, IMapper mapper, ILogger logger)
        {
            _anniversaryDomain = anniversaryDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<bool>> ActiveAsync(int id)
        {
            var response = new Response<bool>();
            try
            {
                if (id == 0)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.WrongParameter;
                    _logger.LogError(response.Message);
                }
                response.Data = await _anniversaryDomain.ActiveAnniversaryAsync(id);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> AddOrUpdateAsync(AddOrUpdateAnniversaryRequestDto obj)
        {
            var response = new Response<bool>();
            try
            {
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.WrongParameter;
                    _logger.LogError(response.Message);
                    return response;
                }
                if (obj.Id == 0)
                {
                    var newAnniversary = _mapper.Map<Anniversary>(obj);
                    response.Data = await _anniversaryDomain.AddAsync(newAnniversary);
                }
                else
                {
                    var existingAnniversary = await _anniversaryDomain.GetByIdAsync(obj.Id);
                    if (existingAnniversary == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataFoundEmployee;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    existingAnniversary = _mapper.Map(obj, existingAnniversary);
                    existingAnniversary.UpdateDate = DateTime.Now;
                    response.Data = await _anniversaryDomain.UpdateAsync(existingAnniversary);
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> AddOrUpdateAsync(AddOrUpdateAnniversaryDto obj)
        {
            var response = new Response<bool>();
            try
            {
                using var context = new SqlCoreContext();
                if(obj.Id > 0)
                {
                    if(obj.GroupId == "FI")
                    {
                        var anniversary = await context.Anniversaries.Where(x => x.Id == obj.Id).FirstOrDefaultAsync();
                        if(anniversary != null)
                        {
                            anniversary.Name = obj.Title;
                            anniversary.StartDate = (DateTime)obj.StartDate.Value.ToUniversalTime();
                            anniversary.EndDate = (DateTime)obj.EndDate.Value.ToUniversalTime();
                            anniversary.ClassName = obj.ClassName;
                            anniversary.Observations = obj.Details;
                            context.Anniversaries.Update(anniversary);
                        }
                    }
                    else
                    {
                        var productionClosure = await context.ProductionClosures.Where(x => x.Id == obj.Id).FirstOrDefaultAsync();
                        if(productionClosure != null)
                        {
                            productionClosure.Title = obj.Title;
                            productionClosure.Observations = obj.Details;
                            productionClosure.EndDate = (DateTime)obj.EndDate;
                        }
                    }
                }
                else
                {
                    if (obj.GroupId == "FI")
                    {
                        await context.Anniversaries.AddAsync(new Anniversary
                        {
                            Name = obj.Title,
                            StartDate = (DateTime)obj.StartDate,
                            EndDate = (DateTime)obj.EndDate,
                            ClassName = obj.ClassName,
                            Observations = obj.Details
                        });
                    }
                }
                await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsync(int id)
        {
            var response = new Response<bool>();
            try
            {
                if (id == 0)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.WrongParameter;
                    _logger.LogError(response.Message);
                }
                response.Data = await _anniversaryDomain.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetAnniversaryResponseDto>>> GetAllAsync()
        {
            var response = new Response<List<GetAnniversaryResponseDto>>();
            try
            {
                var anniversaries = await _anniversaryDomain.GetAllAsync();
                if (anniversaries == null)
                {

                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                }
                response.Data = _mapper.Map<List<GetAnniversaryResponseDto>>(anniversaries);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<GetAnniversaryResponseDto>> GetByIdAsync(int id)
        {
            var response = new Response<GetAnniversaryResponseDto>();
            try
            {
                var employee = await _anniversaryDomain.GetByIdAsync(id);
                if (employee == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetAnniversaryResponseDto>(employee);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetListAnniversaryResponseDto>>> GetCalendarAniversary()
        {
            var response = new Response<List<GetListAnniversaryResponseDto>>();
            response.Data = new List<GetListAnniversaryResponseDto>();
            try
            {
                using var context = new SqlCoreContext();
                var aniversaries = await context.Anniversaries.Where(x => x.Enable == true).ToListAsync();
                var production = await context.ProductionClosures.Where(x =>x.Enable == true).ToListAsync();
               
                if(aniversaries.Count > 0)
                {
                    foreach (var item in aniversaries)
                    {
                        DateTime startDate = new DateTime(DateTime.Now.Year, item.StartDate.Month, item.StartDate.Day, item.StartDate.Hour, item.StartDate.Minute, item.StartDate.Second);

                        DateTime endDate = item.EndDate ?? new DateTime(DateTime.Now.Year, item.StartDate.Month, item.StartDate.Day, 23, 59, 59);


                        response.Data.Add(new GetListAnniversaryResponseDto
                        {
                            Id = item.Id.ToString(),
                            Title = item.Name,
                            Start = startDate,
                            End = endDate,
                            ClassName = item.ClassName,
                            GroupId = "FI",
                            Details = item.Observations
                        });
                    }
                }
                if (production.Count > 0)
                {
                    foreach (var item in production)
                    {
                        response.Data.Add(new GetListAnniversaryResponseDto
                        {
                            Id = item.Id.ToString(),
                            Title = item.Title,
                            Start = item.EndDate,
                            End = item.EndDate.Value.AddSeconds(1),
                            ClassName = "fc-event-success",
                            GroupId = "CP",
                            Details = item.Observations
                        });
                    }
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

        public async Task<Response<List<GetAnniversaryResponseDto>>> GetCurrentAnniversary()
        {
            var response = new Response<List<GetAnniversaryResponseDto>>();
            try
            {
                var anniversaries = await _anniversaryDomain.GetAllAsync();
                if (anniversaries == null)
                {

                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                }
                anniversaries=  anniversaries.Where(x=>GetCurrentAnniversaries(x.StartDate) ).ToList();
                response.Data = _mapper.Map<List<GetAnniversaryResponseDto>>(anniversaries);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        private bool GetCurrentAnniversaries(DateTime startDate)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            var startDateStr=startDate.Day.ToString("D2")+"/"+startDate.Month.ToString("D2")+"/"+DateTime.Now.Year.ToString();

            var days= (DateTime.ParseExact(startDateStr, "dd/MM/yyyy", provider)-DateTime.Now).Days;           
            return days<=7 && days>=0;
        }
    }
}
