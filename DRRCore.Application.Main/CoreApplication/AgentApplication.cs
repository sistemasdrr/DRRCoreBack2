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
    public class AgentApplication : IAgentApplication
    {
        private readonly IAgentDomain _agentDomain;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public AgentApplication(IAgentDomain agentDomain, IMapper mapper, ILogger logger)
        {
            _agentDomain = agentDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<int>> AddOrUpdateAgent(AddOrUpdateAgentResponseDto obj)
        {
            var response = new Response<int>();
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
                    var newAgent = _mapper.Map<Agent>(obj);
                    response.Data = await _agentDomain.AddAgent(newAgent);
                }else if(obj.Id > 0) 
                {
                    var existingAgent = await _agentDomain.GetByIdAsync(obj.Id);
                    if (existingAgent == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataFound;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    existingAgent = _mapper.Map(obj, existingAgent);
                    existingAgent.UpdateDate = DateTime.Now;
                    await _agentDomain.UpdateAsync(existingAgent);
                    response.Data = existingAgent.Id;
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

        public async Task<Response<AddOrUpdateAgentResponseDto>> GetAgentById(int idAgent)
        {
            var response = new Response<AddOrUpdateAgentResponseDto>();
            try
            {
                var agent = await _agentDomain.GetByIdAsync(idAgent);
                response.Data = _mapper.Map<AddOrUpdateAgentResponseDto>(agent);
            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public async Task<Response<List<GetListAgentResponseDto>>> GetListAgentAsync(string code, string name, string state)
        {
            var response = new Response<List<GetListAgentResponseDto>>();
            try
            {
                var list = await _agentDomain.GetAllAgentsAsync(code, name, state);
                if(list == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.WrongParameter;
                    _logger.LogError(response.Message);
                    return response;
                }
                else
                {
                    response.Data = _mapper.Map<List<GetListAgentResponseDto>>(list);
                }
            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
    }
}
