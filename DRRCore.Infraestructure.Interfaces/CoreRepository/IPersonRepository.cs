using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface IPersonRepository: IBaseRepository<Person>
    {
        Task<List<Person>> GetAllByAsync(string fullname, string form, int idCountry, bool haveReport, string filterBy);
        Task<int> AddPersonAsync(Person person); 
        Task<int> UpdatePersonAsync(Person person);
        Task<bool> ActivateWebAsync(int id);
        Task<bool> DesactivateWebAsync(int id);
        Task<Person> GetByOldCode(string? empresa);
        Task<List<Person>> GetPersonSituation(string typeSearch, string? search, int? idCountry);
    }
}
