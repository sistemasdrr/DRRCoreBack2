﻿using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class PersonGeneralInfoRepository : IPersonGeneralInfoRepository
    {
        private readonly ILogger _logger;
        public PersonGeneralInfoRepository(ILogger logger)
        {
            _logger = logger;
        }
        public Task<bool> AddAsync(PersonGeneralInformation obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> AddPersonGeneralInfoAsync(PersonGeneralInformation obj, List<Traduction> traductions)
        {
            try
            {
                using var context = new SqlCoreContext();
                var trad = await context.TraductionPeople.Where(x => x.IdPerson == obj.IdPerson).FirstOrDefaultAsync();
                if (trad != null)
                {
                    trad.TIgdetails= traductions.Where(x => x.Identifier == "L_IG_DETAILS").FirstOrDefault().LargeValue;
                    context.TraductionPeople.Update(trad);
                }
                else
                {
                    trad = new TraductionPerson();
                    trad.TIgdetails = traductions.Where(x => x.Identifier == "L_IG_DETAILS").FirstOrDefault().LargeValue;
                    await context.TraductionPeople.AddAsync(trad);
                }
                context.PersonGeneralInformations.Add(obj);

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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new Exception(ex.Message);
            }
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
            List<Traduction> traductions = new List<Traduction>();
            try
            {
                using var context = new SqlCoreContext();
                var obj = await context.PersonGeneralInformations
                    .Include(x => x.IdPersonNavigation).ThenInclude(x => x.TraductionPeople)
                    .Where(x => x.IdPerson == idPerson).FirstOrDefaultAsync() ?? throw new Exception("No existe la empresa solicitada");

                if (obj.IdPersonNavigation.TraductionPeople.Any())
                {
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_IG_DETAILS",
                        LargeValue = obj.IdPersonNavigation.TraductionPeople.FirstOrDefault().TIgdetails ?? "",
                    });

                }
                else
                {
                    traductions.Add(new Traduction
                    {
                        Identifier = "L_IG_DETAILS",
                        LargeValue = "",
                    });
                }
                //traductions.AddRange(await context.Traductions.Where(x => x.IdPerson == idPerson && x.Identifier.Contains("_IG_")).ToListAsync());

                if (obj.IdPersonNavigation == null)
                    throw new Exception("No existe la persona");

                obj.IdPersonNavigation.Traductions = traductions;
                return obj;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
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
            try
            {
                using (var context = new SqlCoreContext())
                {
                    obj.UpdateDate = DateTime.Now;
                    if (obj.IdPersonNavigation.TraductionPeople.FirstOrDefault() != null)
                    {
                        obj.IdPersonNavigation.TraductionPeople.FirstOrDefault().TIgdetails = traductions.Where(x => x.Identifier == "L_IG_DETAILS").FirstOrDefault().LargeValue;
                        obj.IdPersonNavigation.TraductionPeople.FirstOrDefault().UploadDate = DateTime.Now;
                    }
                    obj.IdPersonNavigation.Traductions = null;
                    context.PersonGeneralInformations.Update(obj);

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
