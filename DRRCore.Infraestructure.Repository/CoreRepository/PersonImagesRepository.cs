using CoreFtp;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Infraestructure.Interfaces.CoreRepository;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Infraestructure.Repository.CoreRepository
{
    public class PersonImagesRepository : IPersonImagesRepository
    {
        private readonly ILogger _logger;
        public PersonImagesRepository(ILogger logger)
        {
            _logger = logger;
        }

        public Task<bool> AddAsync(PersonImage obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> AddPersonImage(PersonImage obj, List<Traduction> traductions)
        {
            try
            {
                using var context = new SqlCoreContext();
                var trad = await context.TraductionPeople.Where(x => x.IdPerson == obj.IdPerson).FirstOrDefaultAsync();
                if (trad != null)
                {
                    trad.TCcurjob = traductions.Where(x => x.Identifier == "S_C_CURJOB").FirstOrDefault().ShortValue;
                    trad.TCstartDate = traductions.Where(x => x.Identifier == "S_C_STARTDT").FirstOrDefault().ShortValue;
                    trad.TCenddt = traductions.Where(x => x.Identifier == "S_C_ENDDT").FirstOrDefault().ShortValue;
                    trad.TCincome = traductions.Where(x => x.Identifier == "S_C_INCOME").FirstOrDefault().ShortValue;
                    trad.TCdetails = traductions.Where(x => x.Identifier == "L_C_DETAILS").FirstOrDefault().LargeValue;
                    trad.UploadDate = DateTime.Now;
                    context.TraductionPeople.Update(trad);
                }
                else
                {
                    trad = new TraductionPerson();
                    trad.TCcurjob = traductions.Where(x => x.Identifier == "S_C_CURJOB").FirstOrDefault().ShortValue;
                    trad.TCstartDate = traductions.Where(x => x.Identifier == "S_C_STARTDT").FirstOrDefault().ShortValue;
                    trad.TCenddt = traductions.Where(x => x.Identifier == "S_C_ENDDT").FirstOrDefault().ShortValue;
                    trad.TCincome = traductions.Where(x => x.Identifier == "S_C_INCOME").FirstOrDefault().ShortValue;
                    trad.TCdetails = traductions.Where(x => x.Identifier == "L_C_DETAILS").FirstOrDefault().LargeValue;
                    await context.TraductionPeople.AddAsync(trad);
                }
                context.PersonImages.Add(obj);

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

        public Task<List<PersonImage>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PersonImage> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonImage> GetByIdPerson(int idPerson)
        {
            throw new NotImplementedException();
        }

        public Task<List<PersonImage>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(PersonImage obj)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> UpdatePersonImage(PersonImage obj, List<Traduction> traductions)
        {
            throw new NotImplementedException();
        }
    }
}
