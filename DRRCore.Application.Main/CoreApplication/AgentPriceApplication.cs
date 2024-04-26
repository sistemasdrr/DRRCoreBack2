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
    public class AgentPriceApplication : IAgentPriceApplication
    {
        private IAgentPriceDomain _agentPriceDomain;
        private IMapper _mapper;
        private ILogger _logger;
        public AgentPriceApplication(IAgentPriceDomain agentPriceDomain, IMapper mapper, ILogger logger)
        {
            _agentPriceDomain = agentPriceDomain;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<bool>> AddOrUpdateAgentPrice(AddOrUpdateAgentPriceRequestDto request)
        {
            var response = new Response<bool>();
            try
            {
                if(request == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.WrongParameter;
                    _logger.LogError(response.Message);
                    return response;
                }
                if(request.Id == 0)
                {
                    var newPrice = _mapper.Map<AgentPrice>(request);
                    response.Data = await _agentPriceDomain.AddAsync(newPrice);
                }
                else
                {
                    var existingPrice = await _agentPriceDomain.GetByIdAsync(request.Id);
                    if (existingPrice == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataFound;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    existingPrice = _mapper.Map(request, existingPrice);
                    existingPrice.UpdateDate = DateTime.Now;
                    await _agentPriceDomain.UpdateAsync(existingPrice);
                }

            }catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<bool>> DeleteAgentPrice(int id)
        {
            var response = new Response<bool>();
            try
            {
                var existingPrice = await _agentPriceDomain.GetByIdAsync(id);
                if(existingPrice == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.WrongParameter;
                    _logger.LogError(response.Message);
                    return response;
                }
                else
                {
                    response.Data = await _agentPriceDomain.DeleteAsync(id);
                }
            }catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<AddOrUpdateAgentPriceRequestDto>> GetPriceById(int id)
        {
            var response = new Response<AddOrUpdateAgentPriceRequestDto>();
            try
            {
                var existingPrice = await _agentPriceDomain.GetByIdAsync(id);
                if (existingPrice == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.WrongParameter;
                    _logger.LogError(response.Message);
                    return response;
                }
                else
                {
                    response.Data = _mapper.Map<AddOrUpdateAgentPriceRequestDto>(existingPrice);
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

        public async Task<Response<List<GetListAgentPriceResponseDto>>> GetPricesById(int idAgent)
        {
            var response = new Response<List<GetListAgentPriceResponseDto>>();
            try
            {
                var list = await _agentPriceDomain.GetPricesByIdAsync(idAgent);
                if (list == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.WrongParameter;
                    _logger.LogError(response.Message);
                    return response;
                }
                else
                {
                    response.Data = _mapper.Map<List<GetListAgentPriceResponseDto>>(list);
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
    }
}
