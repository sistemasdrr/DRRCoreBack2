using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Emit;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ILogger _logger;
        public PersonRepository(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<bool> ActivateWebAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var existingPerson = await context.People.FindAsync(id);
                if (existingPerson != null)
                {
                    existingPerson.OnWeb = true;
                    context.People.Update(existingPerson);
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }

        public async Task<bool> AddAsync(Person obj)
        {
            List<Traduction> traductions = new List<Traduction>();
            try
            {
                using var context = new SqlCoreContext();
                foreach (var item in Constants.TRADUCTIONS_FORMS_PERSON)
                {
                    var exist = obj.Traductions.Where(x => x.Identifier == item).FirstOrDefault();
                    if (exist == null)
                    {
                        obj.Traductions.Add(new Traduction
                        {
                            IdCompany = null,
                            IdPerson = obj.Id,
                            Identifier = item,
                            IdLanguage = 1,
                            LastUpdaterUser = 1
                        });
                    }
                }
                await context.People.AddAsync(obj);
                await context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }

        public async Task<int> AddPersonAsync(Person person)
        {
            List<Traduction> traductions = new List<Traduction>();
            try
            {
                using var context = new SqlCoreContext();
                await context.People.AddAsync(person);
                foreach (var item in Constants.TRADUCTIONS_FORMS_PERSON)
                {
                    var exist = person.Traductions.Where(x => x.Identifier == item).FirstOrDefault();
                    if (exist == null)
                    {
                        person.Traductions.Add(new Traduction
                        {
                            IdCompany = null,
                            IdPerson = person.Id,
                            Identifier = item,
                            IdLanguage = 1,
                            LastUpdaterUser = 1
                        });
                    }
                }
                await context.SaveChangesAsync();
                return person.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return 0;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var existingPerson = await context.People.FindAsync(id);
                if(existingPerson != null)
                {
                    existingPerson.DeleteDate = DateTime.Now;
                    existingPerson.Enable = false;
                    context.People.Update(existingPerson);
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }

        public async Task<bool> DesactivateWebAsync(int id)
        {
            try
            {
                using var context = new SqlCoreContext();
                var existingPerson = await context.People.FindAsync(id);
                if (existingPerson != null)
                {
                    existingPerson.OnWeb = false;
                    context.People.Update(existingPerson);
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }

        public Task<List<Person>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Person>> GetAllByAsync(string fullname, string form, int idCountry, bool haveReport, string filterBy)
        {
           List<Person> people = new List<Person>();
                try
                {
                    using var context = new SqlCoreContext();
                    if (filterBy == "N")
                    {
                        people = await context.People
                            .Include(x => x.Traductions)
                            .Include(x => x.IdCreditRiskNavigation)
                            .Include(x => x.IdDocumentTypeNavigation)
                            .Include(x => x.IdCountryNavigation)
                            .Where(x => (idCountry == 0 || x.IdCountry == idCountry)
                            && (form == "C" ? x.Fullname.Contains(fullname) : form == "I" ? x.Fullname.StartsWith(fullname) : false))
                            .Take(100).ToListAsync();
                    }
                    else if (filterBy == "D")
                    {
                        people = await context.People
                            .Include(x => x.Traductions)
                            .Include(x => x.IdCreditRiskNavigation)
                            .Include(x => x.IdDocumentTypeNavigation)
                            .Include(x => x.IdCountryNavigation)
                            .Where(x => (idCountry == 0 || x.IdCountry == idCountry)
                            && (form == "C" ? x.Address.Contains(fullname) : form == "I" ? x.Address.StartsWith(fullname) : false)).Take(100).ToListAsync();
                    }
                    else if (filterBy == "R")
                    {
                        people = await context.People
                            .Include(x => x.Traductions)
                            .Include(x => x.IdCreditRiskNavigation)
                            .Include(x => x.IdDocumentTypeNavigation)
                            .Include(x => x.IdCountryNavigation)
                            .Where(x => (idCountry == 0 || x.IdCountry == idCountry)
                            && (form == "C" ? x.TaxTypeCode.Contains(fullname) : form == "I" ? x.TaxTypeCode.StartsWith(fullname) : false)).Take(100).ToListAsync();
                    }
                    else if (filterBy == "T")
                    {
                        people = await context.People
                            .Include(x => x.Traductions)
                            .Include(x => x.IdCreditRiskNavigation)
                            .Include(x => x.IdDocumentTypeNavigation)
                            .Include(x => x.IdCountryNavigation)
                            .Where(x => (idCountry == 0 || x.IdCountry == idCountry)
                            && (form == "C" ? x.Cellphone.Contains(fullname) : form == "I" ? x.Cellphone.StartsWith(fullname) : false)).Take(100).ToListAsync();
                    }
                return people;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    return null;
                }
            
            }


        public async Task<List<Company>> GetByNameAsync(string name, string form, int idCountry, bool haveReport, bool similar)
        {
          
            List<Company> companys = new List<Company>();
            try
            {
                using var context = new SqlCoreContext();
                if (haveReport)
                {
                    if (form == "C")
                    {
                        if (idCountry == 0)
                        {
                            companys = await context.Companies.Include(x => x.Traductions).Include(x => x.IdCreditRiskNavigation).
                                Include(x => x.IdCountryNavigation).Where(x => (x.Name.Contains(name) || x.SocialName.Contains(name)) && x.HaveReport == haveReport).Take(100).ToListAsync();
                        }
                        else
                        {
                            companys = await context.Companies.Include(x => x.Traductions).Include(x => x.IdCreditRiskNavigation).
                                Include(x => x.IdCountryNavigation).Where(x => x.IdCountry == idCountry && (x.Name.Contains(name) || x.SocialName.Contains(name)) && x.HaveReport == haveReport).Take(100).ToListAsync();
                        }

                    }
                    else
                    {
                        if (idCountry == 0)
                        {
                            companys = await context.Companies.Include(x => x.Traductions).Include(x => x.IdCreditRiskNavigation).
                                Include(x => x.IdCountryNavigation).Where(x => (x.Name.StartsWith(name) || x.SocialName.StartsWith(name)) && x.HaveReport == haveReport).Take(100).ToListAsync();
                        }
                        else
                        {
                            companys = await context.Companies.Include(x => x.Traductions).Include(x => x.IdCreditRiskNavigation).
                                Include(x => x.IdCountryNavigation).Where(x => x.IdCountry == idCountry && (x.Name.StartsWith(name) || x.SocialName.StartsWith(name)) && x.HaveReport == haveReport).Take(100).ToListAsync();
                        }

                    }
                }
                else
                {
                    if (form == "C")
                    {
                        if (idCountry == 0)
                        {
                            companys = await context.Companies.Include(x => x.Traductions).Include(x => x.IdCreditRiskNavigation).
                                Include(x => x.IdCountryNavigation).Where(x => (x.Name.Contains(name) || x.SocialName.Contains(name))).Take(100).ToListAsync();
                        }
                        else
                        {
                            companys = await context.Companies.Include(x => x.Traductions).Include(x => x.IdCreditRiskNavigation).
                                Include(x => x.IdCountryNavigation).Where(x => x.IdCountry == idCountry && (x.Name.Contains(name) || x.SocialName.Contains(name))).Take(100).ToListAsync();
                        }

                    }
                    else
                    {
                        if (idCountry == 0)
                        {
                            companys = await context.Companies.Include(x => x.Traductions).Include(x => x.IdCreditRiskNavigation).
                                Include(x => x.IdCountryNavigation).Where(x => x.Name.StartsWith(name) || x.SocialName.StartsWith(name)).Take(100).ToListAsync();
                        }
                        else
                        {
                            companys = await context.Companies.Include(x => x.Traductions).Include(x => x.IdCreditRiskNavigation).
                                Include(x => x.IdCountryNavigation).Where(x => x.IdCountry == idCountry && (x.Name.StartsWith(name) || x.SocialName.StartsWith(name))).Take(100).ToListAsync();
                        }

                    }

                }


                return companys;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            List<Traduction> traductions = new List<Traduction>();
            try
            {
                using var context = new SqlCoreContext();
                var person = await context.People.Where(x => x.Id == id).Include(x=>x.IdCountryNavigation).FirstOrDefaultAsync() ?? throw new Exception("No existe la persona solicitada");
                traductions.AddRange(await context.Traductions.Where(x => x.IdPerson == id && x.Identifier.Contains("_P_")).ToListAsync());
                person.Traductions = traductions;
                return person;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Task<List<Person>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Person obj)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    var existTraduction = obj.Traductions;
                    obj.Traductions = new List<Traduction>();
                    obj.UpdateDate = DateTime.Now;
                    context.People.Update(obj);

                    foreach (var item in existTraduction)
                    {
                        var modifierTraduction = await context.Traductions.Where(x => x.IdPerson == obj.Id && x.Identifier == item.Identifier).FirstOrDefaultAsync();
                        if (modifierTraduction != null)
                        {
                            modifierTraduction.ShortValue = item.ShortValue;
                            modifierTraduction.LargeValue = item.LargeValue;
                            modifierTraduction.LastUpdaterUser = item.LastUpdaterUser;
                            context.Traductions.Update(modifierTraduction);
                        }
                        else
                        {
                            var newTraduction = new Traduction();
                            newTraduction.Id = 0;
                            newTraduction.IdPerson = obj.Id;
                            newTraduction.Identifier = item.Identifier;
                            newTraduction.ShortValue = item.ShortValue;
                            newTraduction.LargeValue = item.LargeValue;
                            newTraduction.LastUpdaterUser = item.LastUpdaterUser;
                            await context.Traductions.AddAsync(newTraduction);
                        }
                    }
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public Task<int> UpdatePersonAsync(Person person)
        {
            throw new NotImplementedException();
        }

        public async Task<Person> GetByOldCode(string? empresa)
        {

            try
            {
                using var context = new SqlCoreContext();
                var person = await context.People.Include(x => x.IdCountryNavigation).FirstOrDefaultAsync(x => x.OldCode == empresa);
                return person;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<List<Person>> GetPersonSituation(string typeSearch, string? search, int? idCountry)
        {
            try
            {
                using var context = new SqlCoreContext();
                var persons = new List<Person>();
                if (typeSearch == "N")
                {
                    persons = await context.People.Include(x => x.IdCountryNavigation)
                        .Where(x => x.Fullname.Contains(search) || x.Fullname.Contains(search) && x.IdCountry == idCountry).Take(100).ToListAsync();
                }
                else if (typeSearch == "R")
                {
                    persons = await context.People.Include(x => x.IdCountryNavigation)
                        .Where(x => x.TaxTypeCode.Contains(search) || x.TaxTypeCode.Contains(search) && x.IdCountry == idCountry).Take(100).ToListAsync();
                }
                else if (typeSearch == "T")
                {
                    persons = await context.People.Include(x => x.IdCountryNavigation)
                        .Where(x => x.Cellphone.Contains(search) || x.Cellphone.Contains(search) && x.IdCountry == idCountry).Take(100).ToListAsync();
                }
                return persons;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
