using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Emit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

                var traduction = new TraductionPerson();
                traduction.TPnacionality = obj.Traductions.Where(x => x.Identifier == "S_P_NACIONALITY").FirstOrDefault().ShortValue;
                traduction.TPbirthPlace = obj.Traductions.Where(x => x.Identifier == "S_P_BIRTHPLACE").FirstOrDefault().ShortValue;
                traduction.TPmarriedTo = obj.Traductions.Where(x => x.Identifier == "S_P_MARRIEDTO").FirstOrDefault().ShortValue;
                traduction.TPprofession = obj.Traductions.Where(x => x.Identifier == "S_P_PROFESSION").FirstOrDefault().ShortValue;
                traduction.TPnewcomm = obj.Traductions.Where(x => x.Identifier == "L_P_NEWSCOMM").FirstOrDefault().LargeValue;
                traduction.TPreputation = obj.Traductions.Where(x => x.Identifier == "L_P_REPUTATION").FirstOrDefault().LargeValue;
                obj.TraductionPeople.Add(traduction);

                //foreach (var item in Constants.TRADUCTIONS_FORMS_PERSON)
                //{
                //    var exist = obj.Traductions.Where(x => x.Identifier == item).FirstOrDefault();
                //    if (exist == null)
                //    {
                //        obj.Traductions.Add(new Traduction
                //        {
                //            IdCompany = null,
                //            IdPerson = obj.Id,
                //            Identifier = item,
                //            IdLanguage = 1,
                //            LastUpdaterUser = 1
                //        });
                //    }
                //}
                await context.People.AddAsync(obj);
                await context.SaveChangesAsync();
                obj.OldCode = "N"+obj.Id.ToString("D6");
                context.People.Update(obj);
                await context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }

        public async Task<int> AddPersonAsync(Person obj)
        {
            List<Traduction> traductions = new List<Traduction>();
            try
            {
                using var context = new SqlCoreContext();

                var traduction = new TraductionPerson();
                traduction.TPnacionality = obj.Traductions.Where(x => x.Identifier == "S_P_NACIONALITY").FirstOrDefault().ShortValue;
                traduction.TPbirthPlace = obj.Traductions.Where(x => x.Identifier == "S_P_BIRTHPLACE").FirstOrDefault().ShortValue;
                traduction.TPmarriedTo = obj.Traductions.Where(x => x.Identifier == "S_P_MARRIEDTO").FirstOrDefault().ShortValue;
                traduction.TPprofession = obj.Traductions.Where(x => x.Identifier == "S_P_PROFESSION").FirstOrDefault().ShortValue;
                traduction.TPnewcomm = obj.Traductions.Where(x => x.Identifier == "L_P_NEWSCOMM").FirstOrDefault().LargeValue;
                traduction.TPreputation = obj.Traductions.Where(x => x.Identifier == "L_P_REPUTATION").FirstOrDefault().LargeValue;
                obj.Traductions = null;
                obj.TraductionPeople.Add(traduction);

                //foreach (var item in Constants.TRADUCTIONS_FORMS_PERSON)
                //{
                //    var exist = obj.Traductions.Where(x => x.Identifier == item).FirstOrDefault();
                //    if (exist == null)
                //    {
                //        obj.Traductions.Add(new Traduction
                //        {
                //            IdCompany = null,
                //            IdPerson = obj.Id,
                //            Identifier = item,
                //            IdLanguage = 1,
                //            LastUpdaterUser = 1
                //        });
                //    }
                //}
                await context.People.AddAsync(obj);
                await context.SaveChangesAsync();
                obj.OldCode = "N" + obj.Id.ToString("D6");
                context.People.Update(obj);
                await context.SaveChangesAsync();
                return obj.Id;
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
                            .Include(x => x.IdCreditRiskNavigation)
                            .Include(x => x.IdDocumentTypeNavigation)
                            .Include(x => x.IdCountryNavigation)
                            .Where(x => (idCountry == 0 || x.IdCountry == idCountry)
                            && (form == "C" ? x.Address.Contains(fullname) : form == "I" ? x.Address.StartsWith(fullname) : false)).Take(100).ToListAsync();
                    }
                    else if (filterBy == "R")
                    {
                        people = await context.People
                            .Include(x => x.IdCreditRiskNavigation)
                            .Include(x => x.IdDocumentTypeNavigation)
                            .Include(x => x.IdCountryNavigation)
                            .Where(x => (idCountry == 0 || x.IdCountry == idCountry)
                            && (form == "C" ? x.TaxTypeCode.Contains(fullname) : form == "I" ? x.TaxTypeCode.StartsWith(fullname) : false)).Take(100).ToListAsync();
                    }
                    else if (filterBy == "T")
                    {
                        people = await context.People
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

        public async Task<Person> GetByIdAsync(int id)
        {
            List<Traduction> traductions = new List<Traduction>();
            try
            {
                using var context = new SqlCoreContext();
                var person = await context.People
                    .Where(x => x.Id == id)
                    .Include(x => x.TraductionPeople)
                    .Include(x=>x.IdCountryNavigation)
                    .FirstOrDefaultAsync() ?? throw new Exception("No existe la persona solicitada");
                if (person.TraductionPeople.Any())
                {
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_P_NACIONALITY",
                        ShortValue = person.TraductionPeople.FirstOrDefault().TPnacionality ?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_P_BIRTHPLACE",
                        ShortValue = person.TraductionPeople.FirstOrDefault().TPbirthPlace ?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_P_MARRIEDTO",
                        ShortValue = person.TraductionPeople.FirstOrDefault().TPmarriedTo ?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_P_PROFESSION",
                        ShortValue = person.TraductionPeople.FirstOrDefault().TPprofession ?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_P_NEWSCOMM",
                        LargeValue = person.TraductionPeople.FirstOrDefault().TPnewcomm ?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_P_REPUTATION",
                        LargeValue = person.TraductionPeople.FirstOrDefault().TPreputation ?? "",
                    });
                }
                else
                {
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_P_NACIONALITY",
                        ShortValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_P_BIRTHPLACE",
                        ShortValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_P_MARRIEDTO",
                        ShortValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "S_P_PROFESSION",
                        ShortValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_P_NEWSCOMM",
                        LargeValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_P_REPUTATION",
                        LargeValue = "",
                    });
                }
                //traductions.AddRange(await context.Traductions.Where(x => x.IdPerson == id && x.Identifier.Contains("_P_")).ToListAsync());
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
                    obj.UpdateDate = DateTime.Now;

                    if (obj.TraductionPeople.FirstOrDefault() != null)
                    {
                        obj.TraductionPeople.FirstOrDefault().TPnacionality= obj.Traductions.Where(x => x.Identifier == "S_P_NACIONALITY").FirstOrDefault().ShortValue;
                        obj.TraductionPeople.FirstOrDefault().TPbirthPlace= obj.Traductions.Where(x => x.Identifier == "S_P_BIRTHPLACE").FirstOrDefault().ShortValue;
                        obj.TraductionPeople.FirstOrDefault().TPmarriedTo = obj.Traductions.Where(x => x.Identifier == "S_P_MARRIEDTO").FirstOrDefault().ShortValue;
                        obj.TraductionPeople.FirstOrDefault().TPprofession= obj.Traductions.Where(x => x.Identifier == "S_P_PROFESSION").FirstOrDefault().ShortValue;
                        obj.TraductionPeople.FirstOrDefault().TPnewcomm = obj.Traductions.Where(x => x.Identifier == "L_P_NEWSCOMM").FirstOrDefault().LargeValue;
                        obj.TraductionPeople.FirstOrDefault().TPreputation = obj.Traductions.Where(x => x.Identifier == "L_P_REPUTATION").FirstOrDefault().LargeValue;
                    }
                    else
                    {
                        var traduction = new TraductionPerson();
                        traduction.TPnacionality = obj.Traductions.Where(x => x.Identifier == "S_P_NACIONALITY").FirstOrDefault().ShortValue;
                        traduction.TPbirthPlace = obj.Traductions.Where(x => x.Identifier == "S_P_BIRTHPLACE").FirstOrDefault().ShortValue;
                        traduction.TPmarriedTo = obj.Traductions.Where(x => x.Identifier == "S_P_MARRIEDTO").FirstOrDefault().ShortValue;
                        traduction.TPprofession = obj.Traductions.Where(x => x.Identifier == "S_P_PROFESSION").FirstOrDefault().ShortValue;
                        traduction.TPnewcomm = obj.Traductions.Where(x => x.Identifier == "L_P_NEWSCOMM").FirstOrDefault().LargeValue;
                        traduction.TPreputation = obj.Traductions.Where(x => x.Identifier == "L_P_REPUTATION").FirstOrDefault().LargeValue;
                        obj.TraductionPeople.Add(traduction);
                    }
                    obj.Traductions = null;
                    context.People.Update(obj);
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
