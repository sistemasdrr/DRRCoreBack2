using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IDocumentTypeRepository:IBaseRepository<DocumentType>
    {
        Task<List<DocumentType>> GetAllNaturalDocumentAsync();
        Task<List<DocumentType>> GetAllLegalDocumentAsync();
        Task<List<DocumentType>> GetAllNationalDocumentAsync();
        Task<List<DocumentType>> GetAllInternationalDocumentAsync();
    }
}
