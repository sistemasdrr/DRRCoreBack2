using DRRCore.Application.Interfaces;
using DRRCore.Domain.Interfaces.EmailDomain;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using Microsoft.IdentityModel.Tokens;

namespace DRRCore.Application.Main
{
    public class TokenValidationApplication : ITokenValidationApplication
    {
        public readonly IApiUserDomain _apiUserDomain;
        private readonly IFunction _function;

        public TokenValidationApplication(IApiUserDomain apiUserDomain, IFunction function)
        {
            _apiUserDomain = apiUserDomain;             
            _function = function;
        }

        public async Task<Response<bool>> ValidationTokenAsync()
        {
            var response = new Response<bool>();
            string tokenEncriptado = await _function.GetTokenByHeader();
            try
            {
                if (tokenEncriptado.IsNullOrEmpty())
                {
                    response.Message = Messages.TokenNotSend;
                    return response;
                }
                else
                {
                    var tokenDesencriptado = await _function.Decrypt(tokenEncriptado);//Desencripta el token
                    if (tokenDesencriptado.IsNullOrEmpty())
                    {
                        response.IsSuccess = false;
                        response.IsWarning = true;
                        response.Message = "Ocurrio un error al desencriptar el token.";
                        return response;
                    }
                    else
                    {
                        var comprobarToken = await _apiUserDomain.GetApiUserByTokenAsync(tokenDesencriptado); //obtiene el apiuser mediante el token
                        if (comprobarToken != null && comprobarToken.Enable == true && comprobarToken.Active == true) //comprueba si existe
                        {
                            response.IsWarning = false;
                            response.Message = Messages.AuthorizedUser;

                        }
                        else
                        {
                            response.Message = Messages.UserNotFound;
                        }
                        return response;
                    }
                }

            }
            catch (Exception ex)
            {
                response.IsWarning = true;
                response.IsSuccess = false;
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Response<bool>> ValidationTokenAndEnvironmentAsync(string environment)
        {
            var response = new Response<bool>();
            string tokenEncriptado = await _function.GetTokenByHeader();
            try
            {
                if (tokenEncriptado.IsNullOrEmpty())
                {
                    response.Message = Messages.TokenNotSend;
                    response.IsSuccess = false;
                    response.IsWarning = true;
                    return response;
                }
                else
                {
                    var tokenDesencriptado =await _function.Decrypt(tokenEncriptado);//Desencripta el token
                    if (tokenDesencriptado.IsNullOrEmpty())
                    {
                        response.IsSuccess = false;
                        response.IsWarning = true;
                        response.Message = "Ocurrio un error al desencriptar el token.";
                        return response;
                    }
                    else
                    {
                        var comprobarToken = await _apiUserDomain.GetApiUserByTokenAsync(tokenDesencriptado); //obtiene el apiuser mediante el token
                        if (comprobarToken != null && comprobarToken.Enable == true && comprobarToken.Active == true && comprobarToken.Environment == environment) //comprueba si existe
                        {
                            response.IsWarning = false;
                            response.Message = Messages.AuthorizedUser;
                        }
                        else
                        {
                            response.IsSuccess = false;
                            response.IsWarning = true;
                            response.Message = Messages.UserNotFound;
                        }
                        return response;
                    }
                }

            }
            catch (Exception ex)
            {
                response.IsWarning = true;
                response.IsSuccess = false;
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Response<string>> EncryptTokenAsync(string token)
        {
            var response = new Response<string>();
            try
            {
                var tokenEncriptado =await _function.Encrypt(token);//Encripta el token
                response.IsSuccess = true;
                response.Data = tokenEncriptado;
                response.Message = "Token Encriptado";
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
       
      
        public async Task<Response<string>> decryptTokenAsync(string token)
        {
            var response = new Response<string>();
            if (token != null)
            {
                string tokenDesencriptado =await _function.Decrypt(token);
                response.IsSuccess = true;
                response.Message = "Token Desencriptado";
                response.Data = tokenDesencriptado;
            }
            return response;
        }
        public async Task<Response<string>> EncriptTokenAsync(string token)
        {
            var response = new Response<string>();
            try
            {
                var tokenEncriptado = await _function.Encrypt(token);//Encripta el token
                response.IsSuccess = true;
                response.Data = tokenEncriptado;
                response.Message = "Token Encriptado";
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

       
    }
}

