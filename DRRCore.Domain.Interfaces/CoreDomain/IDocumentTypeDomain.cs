using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IDocumentTypeDomain: IBaseDomain<DocumentType>
    {
        Task<List<DocumentType>> GetAllNaturalDocumentAsync();
        Task<List<DocumentType>> GetAllLegalDocumentAsync();
        Task<List<DocumentType>> GetAllNationalDocumentAsync();
        Task<List<DocumentType>> GetAllInternationalDocumentAsync();
    }
}
