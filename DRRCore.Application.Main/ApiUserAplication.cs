using AutoMapper;
using DRRCore.Application.DTO.API;
using DRRCore.Application.Interfaces;
using DRRCore.Domain.Entities.SqlContext;
using DRRCore.Domain.Entities.SQLContext;
using DRRCore.Domain.Interfaces.EmailDomain;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;

namespace DRRCore.Application.Main
{
    public class ApiUserAplication : IApiUserApplication
    {
        public readonly IApiUserDomain _apiUserDomain;
        private readonly ITokenValidationApplication _tokenValidationApplication;
        private readonly IFunction _function;
        private IMapper _mapper { get; }

        public ApiUserAplication(IApiUserDomain apiUserDomain,IFunction function, IMapper mapper, ITokenValidationApplication tokenValidationApplication)
        {
            _apiUserDomain = apiUserDomain;
            _mapper = mapper;
            _tokenValidationApplication = tokenValidationApplication;
            _function = function;
        }
        public async Task<Response<string>> AddApiUserAsync(ApiUserDto obj)
        {
            var response = new Response<string>();
            try
            {
                var result = await _apiUserDomain.InsertApiUserAsync(_mapper.Map<ApiUser>(obj));
                if (result)
                {
                    var apiUser = await _apiUserDomain.GetApiUserByAbonadoAndEnvironmentAsync(obj.CodigoAbonado, obj.Environment);
                    var tokenEncriptado =await _function.Encrypt(apiUser.Token.ToString());
                    response.Data = tokenEncriptado;
                    response.IsSuccess = true;
                    response.IsWarning = false;
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Response<string>> GetTokenByInsertApiUser(ApiUserDto obj)
        {
            var response = new Response<string>();
            try
            {
                var result = await _apiUserDomain.GetApiUserByAbonadoAndEnvironmentAsync(obj.CodigoAbonado, obj.Environment);
                if (result != null)
                {
                    var codigoEncriptado = await _tokenValidationApplication.EncryptTokenAsync(result.Token.ToString());
                    response.Data = codigoEncriptado.Data;
                    response.IsSuccess = true;
                    response.IsWarning = false;
                    response.Message = string.Format(Messages.InsertedUser, obj.CodigoAbonado); ;
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
