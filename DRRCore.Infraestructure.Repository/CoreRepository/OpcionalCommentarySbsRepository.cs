using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class OpcionalCommentarySbsRepository : IOpcionalCommentarySbsRepository
    {
        private readonly ILogger _logger;
        public OpcionalCommentarySbsRepository(ILogger logger)
        {
            _logger = logger;
        }

        public Task<bool> AddAsync(OpcionalCommentarySb obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OpcionalCommentarySb>> GetAllAsync()
        {
            try
            {
                using var context = new SqlCoreContext();
                var list = await context.OpcionalCommentarySbs.Where(x => x.Enable == true).ToListAsync();
                return list;
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public Task<OpcionalCommentarySb> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<OpcionalCommentarySb>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(OpcionalCommentarySb obj)
        {
            throw new NotImplementedException();
        }
    }
}
