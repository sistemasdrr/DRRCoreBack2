using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class ImportsAndExportsDomain : IImportsAndExportsDomain
    {
        private readonly IImportsAndExportsRepository _repository;
        public ImportsAndExportsDomain(IImportsAndExportsRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddAsync(ImportsAndExport obj)
        {
            return await _repository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public Task<List<ImportsAndExport>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ImportsAndExport> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public Task<List<ImportsAndExport>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ImportsAndExport>> GetExports(int idCompany)
        {
            return await _repository.GetExports(idCompany);
        }

        public async Task<List<ImportsAndExport>> GetImports(int idCompany)
        {
            return await _repository.GetImports(idCompany);
        }

        public async Task<bool> UpdateAsync(ImportsAndExport obj)
        {
            return await _repository.UpdateAsync(obj);
        }
    }
}
