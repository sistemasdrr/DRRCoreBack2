using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class OpcionalCommentarySbsDomain : IOpcionalCommentarySbsDomain
    {
        private readonly IOpcionalCommentarySbsRepository _opcionalCommentarySbsRepository;
        public OpcionalCommentarySbsDomain(IOpcionalCommentarySbsRepository opcionalCommentarySbsRepository)
        {
            _opcionalCommentarySbsRepository = opcionalCommentarySbsRepository;
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
            return await _opcionalCommentarySbsRepository.GetAllAsync();
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
