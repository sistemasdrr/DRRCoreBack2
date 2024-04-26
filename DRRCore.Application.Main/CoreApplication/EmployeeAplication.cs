using AutoMapper;
using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;

namespace DRRCore.Application.Main.CoreApplication
{
    public class EmployeeAplication : IEmployeeApplication
    {
        private readonly IEmployeeDomain _employeeDomain;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public EmployeeAplication( IEmployeeDomain employeeDomain, ILogger logger, IMapper mapper) { 
           _employeeDomain= employeeDomain;
            _logger = logger;
            _mapper = mapper;
        }
       

        public async Task<Response<GetEmployeeResponseDto>> GetByIdAsync(int id)
        {
            var response = new Response<GetEmployeeResponseDto>();
            try
            {
                var employee= await _employeeDomain.GetByIdAsync(id);
                if(employee == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data= _mapper.Map<GetEmployeeResponseDto>(employee);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetEmployeeResponseDto>>> GetAllAsync()
        {
            var response = new Response<List<GetEmployeeResponseDto>>();
            try
            {
                var employee = await _employeeDomain.GetAllAsync();
                if (employee == null)
                {
                    
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                }
                response.Data = _mapper.Map<List<GetEmployeeResponseDto>>(employee);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetEmployeeResponseDto>>> GetByNameAsync(string name)
        {
            var response = new Response<List<GetEmployeeResponseDto>>();
            try
            {
                var employee = await _employeeDomain.GetByNameAsync(name);
                if (employee == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                }
                response.Data = _mapper.Map<List<GetEmployeeResponseDto>>(employee);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> AddOrUpdateAsync(AddOrUpdateEmployeeRequestDto obj)
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
                    var newEmployee = _mapper.Map<Employee>(obj);
                    response.Data = await _employeeDomain.AddAsync(newEmployee);
                }
                else
                {
                    var existingEmployee=await _employeeDomain.GetByIdAsync(obj.Id);
                    if(existingEmployee == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataFoundEmployee;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    existingEmployee = _mapper.Map(obj, existingEmployee);
                    existingEmployee.UpdateDate = DateTime.Now;
                    response.Data = await _employeeDomain.UpdateAsync(existingEmployee);
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
               response.Data = await _employeeDomain.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
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
                response.Data = await _employeeDomain.ActiveEmployeeAsync(id);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
    }
}
