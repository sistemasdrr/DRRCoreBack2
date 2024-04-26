using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly ILogger _logger;
        public DocumentTypeRepository(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<bool> AddAsync(DocumentType obj)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    await context.DocumentTypes.AddAsync(obj);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {

            try
            {
                using (var context = new SqlCoreContext())
                {
                    var obj = await context.DocumentTypes.FindAsync(id) ?? throw new Exception("No existe el país solicitado");
                    obj.Enable = false;
                    context.DocumentTypes.Update(obj);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<List<DocumentType>> GetAllAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.DocumentTypes.Where(x => x.Enable == true).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<DocumentType>();
            }
        }

        public async Task<List<DocumentType>> GetAllInternationalDocumentAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.DocumentTypes.Where(x => x.IsNational==false).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<DocumentType>();
            }
        }

        public async Task<List<DocumentType>> GetAllLegalDocumentAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.DocumentTypes.Where(x => x.IsLegal==true).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<DocumentType>();
            }
        }

        public async Task<List<DocumentType>> GetAllNationalDocumentAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.DocumentTypes.Where(x => x.IsNational == true).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<DocumentType>();
            }
        }

        public async Task<List<DocumentType>> GetAllNaturalDocumentAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.DocumentTypes.Where(x => x.IsNatural == true).OrderBy(x=>x.Id).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<DocumentType>();
            }
        }

        public async Task<DocumentType> GetByIdAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.DocumentTypes.FindAsync(id) ?? throw new Exception("No existe el país solicitado");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<List<DocumentType>> GetByNameAsync(string name)
        {
            try
            {
                using var context = new SqlCoreContext();
                return await context.DocumentTypes.Where(x => x.Name.Contains(name)).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<DocumentType>();
            }
        }

        public async Task<bool> UpdateAsync(DocumentType obj)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    context.DocumentTypes.Update(obj);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
