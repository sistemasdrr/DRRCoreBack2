using DRRCore.Application.Interfaces;
using DRRCore.Transversal.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DRRCore.Application.Main
{
    public class TokenGeneratorApplication : ITokenGeneratorApplication
    {

        private readonly IConfiguration Configuration;
        public TokenGeneratorApplication(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<Response<string>> GetTokenAsync()
        {
            var response = new Response<string>(); //se crea el response 
            try
            {
                var claims = new[] //claims
                  {
                     new Claim(ClaimTypes.Name, "RolEjemplo")
                   };

                var tokenHandler = new JwtSecurityTokenHandler(); 
                var key = Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]); //se obtiene la key desde appsettings
                var tokenDescriptor = new SecurityTokenDescriptor //el token con todos sus datos
                {
                    Issuer= Configuration["Jwt:Issuer"],
                    Audience= Configuration["Jwt:Audience"],
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor); //se crea el token
                response.Data = tokenHandler.WriteToken(token); //se guarda el token en el campo Data del response
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response; //se retorna el response 
        }
    }
}
