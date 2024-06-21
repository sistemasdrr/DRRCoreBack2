using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class PersonSBSRepository : IPersonSBSRepository
    {
        private readonly ILogger _logger;
        public PersonSBSRepository(ILogger logger)
        {
            _logger = logger;
        }
        public Task<bool> AddAsync(PersonSb obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> AddPersonSBS(PersonSb obj, List<Traduction> traductions)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    var trad = await context.TraductionPeople.Where(x => x.IdPerson == obj.IdPerson).FirstOrDefaultAsync();
                    if (trad != null)
                    {
                        trad.TSbsantecedente= traductions.Where(x => x.Identifier == "L_SBS_ANTEC").FirstOrDefault().LargeValue;
                        trad.TSbsrickCnt = traductions.Where(x => x.Identifier == "L_SBS_RISKCNT").FirstOrDefault().LargeValue;
                        trad.TSbscommentSbs= traductions.Where(x => x.Identifier == "L_SBS_COMMENTSBS").FirstOrDefault().LargeValue;
                        trad.TSbscommentBank = traductions.Where(x => x.Identifier == "L_SBS_COMMENTBANK").FirstOrDefault().LargeValue;
                        trad.TSbslitig = traductions.Where(x => x.Identifier == "L_SBS_LITIG").FirstOrDefault().LargeValue;
                        context.TraductionPeople.Update(trad);
                    }
                    else
                    {
                        trad = new TraductionPerson();
                        trad.TSbsantecedente = traductions.Where(x => x.Identifier == "L_SBS_ANTEC").FirstOrDefault().LargeValue;
                        trad.TSbsrickCnt = traductions.Where(x => x.Identifier == "L_SBS_RISKCNT").FirstOrDefault().LargeValue;
                        trad.TSbscommentSbs = traductions.Where(x => x.Identifier == "L_SBS_COMMENTSBS").FirstOrDefault().LargeValue;
                        trad.TSbscommentBank = traductions.Where(x => x.Identifier == "L_SBS_COMMENTBANK").FirstOrDefault().LargeValue;
                        trad.TSbslitig = traductions.Where(x => x.Identifier == "L_SBS_LITIG").FirstOrDefault().LargeValue;
                        await context.TraductionPeople.AddAsync(trad);
                    }
                    context.PersonSbs.Add(obj);

                    //foreach (var item in traductions)
                    //{
                    //    var modifierTraduction = await context.Traductions.Where(x => x.IdPerson == obj.IdPerson && x.Identifier == item.Identifier).FirstOrDefaultAsync();
                    //    if (modifierTraduction != null)
                    //    {
                    //        modifierTraduction.ShortValue = item.ShortValue;
                    //        modifierTraduction.LargeValue = item.LargeValue;
                    //        modifierTraduction.LastUpdaterUser = item.LastUpdaterUser;
                    //        context.Traductions.Update(modifierTraduction);
                    //    }
                    //    else
                    //    {
                    //        var newTraduction = new Traduction();
                    //        newTraduction.Id = 0;
                    //        newTraduction.IdPerson = obj.IdPerson;
                    //        newTraduction.Identifier = item.Identifier;
                    //        newTraduction.ShortValue = item.ShortValue;
                    //        newTraduction.LargeValue = item.LargeValue;
                    //        newTraduction.LastUpdaterUser = item.LastUpdaterUser;
                    //        await context.Traductions.AddAsync(newTraduction);
                    //    }
                    //}
                    await context.SaveChangesAsync();
                    return obj.Id;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PersonSb>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PersonSb> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonSb> GetByIdPerson(int idPerson)
        {
            List<Traduction> traductions = new List<Traduction>();
            try
            {
                using var context = new SqlCoreContext();
                var obj = await context.PersonSbs
                    .Include(x => x.IdPersonNavigation).ThenInclude(x => x.TraductionPeople)
                    .Where(x => x.IdPerson == idPerson)
                    .FirstOrDefaultAsync() ?? throw new Exception("No existe la empresa solicitada");

                if (obj.IdPersonNavigation.TraductionPeople.Any())
                {
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_SBS_ANTEC",
                        LargeValue = obj.IdPersonNavigation.TraductionPeople.FirstOrDefault().TSbsantecedente ?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_SBS_RISKCNT",
                        LargeValue = obj.IdPersonNavigation.TraductionPeople.FirstOrDefault().TSbsrickCnt ?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_SBS_COMMENTSBS",
                        LargeValue = obj.IdPersonNavigation.TraductionPeople.FirstOrDefault().TSbscommentSbs ?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_SBS_COMMENTBANK",
                        LargeValue = obj.IdPersonNavigation.TraductionPeople.FirstOrDefault().TSbscommentBank ?? "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_SBS_LITIG",
                        LargeValue = obj.IdPersonNavigation.TraductionPeople.FirstOrDefault().TSbslitig ?? "",
                    });
                }
                else
                {
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_SBS_ANTEC",
                        LargeValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_SBS_RISKCNT",
                        LargeValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_SBS_COMMENTSBS",
                        LargeValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_SBS_COMMENTBANK",
                        LargeValue = "",
                    });
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_SBS_LITIG",
                        LargeValue = "",
                    });
                }
                //traductions.AddRange(await context.Traductions.Where(x => x.IdPerson == idPerson && x.Identifier.Contains("_SBS_")).ToListAsync());

                if (obj.IdPersonNavigation == null)
                    throw new Exception("No existe la empresa");

                obj.IdPersonNavigation.Traductions = traductions;
                return obj;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Task<List<PersonSb>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(PersonSb obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> UpdatePersonSBS(PersonSb obj, List<Traduction> traductions)
        {
            try
            {
                using (var context = new SqlCoreContext())
                {
                    obj.UpdateDate = DateTime.Now;
                    if (obj.IdPersonNavigation.TraductionPeople.FirstOrDefault() != null)
                    {
                        obj.IdPersonNavigation.TraductionPeople.FirstOrDefault().TSbsantecedente= traductions.Where(x => x.Identifier == "L_SBS_ANTEC").FirstOrDefault().LargeValue;
                        obj.IdPersonNavigation.TraductionPeople.FirstOrDefault().TSbsrickCnt= traductions.Where(x => x.Identifier == "L_SBS_RISKCNT").FirstOrDefault().LargeValue;
                        obj.IdPersonNavigation.TraductionPeople.FirstOrDefault().TSbscommentSbs= traductions.Where(x => x.Identifier == "L_SBS_COMMENTSBS").FirstOrDefault().LargeValue;
                        obj.IdPersonNavigation.TraductionPeople.FirstOrDefault().TSbscommentBank= traductions.Where(x => x.Identifier == "L_SBS_COMMENTBANK").FirstOrDefault().LargeValue;
                        obj.IdPersonNavigation.TraductionPeople.FirstOrDefault().TSbslitig= traductions.Where(x => x.Identifier == "L_SBS_LITIG").FirstOrDefault().LargeValue;
                    }
                    context.PersonSbs.Update(obj);

                    //foreach (var item in traductions)
                    //{
                    //    var modifierTraduction = await context.Traductions.Where(x => x.IdPerson == obj.IdPerson && x.Identifier == item.Identifier).FirstOrDefaultAsync();
                    //    if (modifierTraduction != null)
                    //    {
                    //        modifierTraduction.ShortValue = item.ShortValue;
                    //        modifierTraduction.LargeValue = item.LargeValue;
                    //        modifierTraduction.LastUpdaterUser = item.LastUpdaterUser;
                    //        context.Traductions.Update(modifierTraduction);
                    //    }
                    //    else
                    //    {
                    //        var newTraduction = new Traduction();
                    //        newTraduction.Id = 0;
                    //        newTraduction.IdPerson = obj.IdPerson;
                    //        newTraduction.Identifier = item.Identifier;
                    //        newTraduction.ShortValue = item.ShortValue;
                    //        newTraduction.LargeValue = item.LargeValue;
                    //        newTraduction.LastUpdaterUser = item.LastUpdaterUser;
                    //        await context.Traductions.AddAsync(newTraduction);
                    //    }
                    //}
                    await context.SaveChangesAsync();
                    return obj.Id;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
