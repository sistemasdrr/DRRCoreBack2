using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class PersonGeneralInfoDomain : IPersonGeneralInfoDomain
    {
        private readonly IPersonGeneralInfoRepository _personGeneralInfoRepository;
        public PersonGeneralInfoDomain(IPersonGeneralInfoRepository personGeneralInfoRepository)
        {
            _personGeneralInfoRepository = personGeneralInfoRepository;
        }

        public Task<bool> AddAsync(PersonGeneralInformation obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> AddPersonGeneralInfoAsync(PersonGeneralInformation obj, List<Traduction> traductions)
        {
            return await _personGeneralInfoRepository.AddPersonGeneralInfoAsync(obj, traductions);
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PersonGeneralInformation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PersonGeneralInformation> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonGeneralInformation> GetByIdPersonAsync(int idPerson)
        {
            return await _personGeneralInfoRepository.GetByIdPersonAsync(idPerson);
        }

        public Task<List<PersonGeneralInformation>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(PersonGeneralInformation obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> UpdatePersonGeneralInfoAsync(PersonGeneralInformation obj, List<Traduction> traductions)
        {
            return await _personGeneralInfoRepository.UpdatePersonGeneralInfoAsync(obj, traductions);
        }
    }
}
