using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class FamilyBondyTypeDomain : IFamilyBondyTypeDomain
    {
        private readonly IFamilyBondTypeRepository _familyBondTypeRepository;
        public FamilyBondyTypeDomain( IFamilyBondTypeRepository familyBondTypeRepository)
        {
            _familyBondTypeRepository = familyBondTypeRepository;
        }
        public Task<bool> AddAsync(FamilyBondType obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<FamilyBondType>> GetAllAsync()
        {
            return _familyBondTypeRepository.GetAllAsync();
        }

        public Task<FamilyBondType> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<FamilyBondType>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(FamilyBondType obj)
        {
            throw new NotImplementedException();
        }
    }
}
