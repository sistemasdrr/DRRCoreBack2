using DRRCore.Domain.Entities.SQLContext;
using DRRCore.Domain.Interfaces.EmailDomain;
using DRRCore.Infraestructure.Interfaces.Repository;

namespace DRRCore.Domain.Main.EmailDomain
{
    public class ApiUserDomain : IApiUserDomain
    {
        public readonly IApiUserRepository _repository;
        public ApiUserDomain(IApiUserRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> DeleteApiUserAsync(int id)
        {
            return _repository.DeleteApiUserAsync(id);
        }

        public Task<ApiUser> GetApiUserByCodeAsync(string code)
        {
            return _repository.GetApiUserByCodeAsync(code);
        }

        public Task<ApiUser> GetApiUserByTokenAsync(string token)
        {
            return _repository.GetApiUserByTokenAsync(token);
        }
        public Task<ApiUser> GetApiUserByAbonadoAndEnvironmentAsync(string codigoabonado, string environment)
        {
            return _repository.GetApiUserByAbonadoAndEnvironmentAsync(codigoabonado, environment);
        }
        public Task<List<ApiUser>> GetApiUserListAllAsync()
        {
            return _repository.GetApiUserListAllAsync();
        }

        public Task<bool> InsertApiUserAsync(ApiUser obj)
        {
            return _repository.InsertApiUserAsync(obj);
        }

        public Task<bool> UpdateApiUserAsync(ApiUser obj)
        {
            return _repository.UpdateApiUserAsync(obj);
        }
    }
}
