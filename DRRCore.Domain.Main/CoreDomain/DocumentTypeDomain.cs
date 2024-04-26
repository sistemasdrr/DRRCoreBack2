using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class DocumentTypeDomain:IDocumentTypeDomain
    {
        private readonly IDocumentTypeRepository _repository;
        public DocumentTypeDomain(IDocumentTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddAsync(DocumentType obj)
        {
            return await _repository.AddAsync(obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<List<DocumentType>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<List<DocumentType>> GetAllInternationalDocumentAsync()
        {
            return await _repository.GetAllInternationalDocumentAsync();
        }

        public async Task<List<DocumentType>> GetAllLegalDocumentAsync()
        {
            return await _repository.GetAllLegalDocumentAsync();
        }

        public async Task<List<DocumentType>> GetAllNationalDocumentAsync()
        {
            return await _repository.GetAllNationalDocumentAsync();
        }

        public async Task<List<DocumentType>> GetAllNaturalDocumentAsync()
        {
            return await _repository.GetAllNaturalDocumentAsync();
        }

        public async Task<DocumentType> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<DocumentType>> GetByNameAsync(string name)
        {
            return await _repository.GetByNameAsync(name);
        }

        public async Task<bool> UpdateAsync(DocumentType obj)
        {
            return await _repository.UpdateAsync(obj);
        }
    }
}
