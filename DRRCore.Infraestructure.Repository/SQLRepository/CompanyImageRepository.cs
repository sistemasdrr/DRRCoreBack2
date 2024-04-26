using DRRCore.Domain.Entities.SqlContext;
using DRRCore.Domain.Entities.SQLContext;
using DRRCore.Infraestructure.Interfaces.Repository;
using DRRCore.Transversal.Common.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DRRCore.Infraestructure.Repository.SQLRepository
{
    public class CompanyImageRepository : ICompanyImageRepository
    {
        private ILogger _logger;
        public CompanyImageRepository(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<bool> AddAsync(CompanyImage obj)
        {
            try
            {
                using var context = new SqlContext();
                await context.CompanyImages.AddAsync(obj);
                await context.SaveChangesAsync();
                return true;
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }

        public async Task<int?> AddCompanyImage(CompanyImage obj)
        {
            try
            {
                using var context = new SqlContext();
                await context.CompanyImages.AddAsync(obj);
                await context.SaveChangesAsync();
                return obj.Id;
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CompanyImage>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CompanyImage> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CompanyImage>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyImage> GetImagesByIdCompany(int idCompany)
        {
            try
            {
                using var context = new SqlContext();
                var images = await context.CompanyImages.Where(x => x.IdCompany == idCompany).FirstOrDefaultAsync();
                return images != null ? images : null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Task<bool> UpdateAsync(CompanyImage obj)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateImageCompany(int idCompany, int number, string? base64, string? description, string? descriptionEng, bool? print)
        {
            try
            {
                using var context = new SqlContext();
                var images = await context.CompanyImages.Where(x => x.IdCompany == idCompany).FirstOrDefaultAsync();
                if (images != null)
                {
                    if(number == 1)
                    {
                        images.Img1 = base64;
                        images.ImgDesc1 = description;
                        images.ImgDescEng1 = descriptionEng;
                        images.ImgPrint1 = print;
                    }
                    else if(number == 2)
                    {
                        images.Img2 = base64;
                        images.ImgDesc2 = description;
                        images.ImgDescEng2 = descriptionEng;
                        images.ImgPrint2 = print;
                    }
                    else if (number == 3)
                    {
                        images.Img3 = base64;
                        images.ImgDesc3 = description;
                        images.ImgDescEng3 = descriptionEng;
                        images.ImgPrint3 = print;
                    }
                    else if (number == 4)
                    {
                        images.Img4 = base64;
                        images.ImgDesc4 = description;
                        images.ImgDescEng4 = descriptionEng;
                        images.ImgPrint4 = print;
                    }
                    context.CompanyImages.Update(images);
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    var imageCompany = new CompanyImage();
                    imageCompany.IdCompany = idCompany;
                    if (number == 1)
                    {
                        imageCompany.Img1 = base64;
                        imageCompany.ImgDesc1 = description;
                        imageCompany.ImgDescEng1 = descriptionEng;
                        imageCompany.ImgPrint1 = print;
                    }
                    else if (number == 2)
                    {
                        imageCompany.Img2 = base64;
                        imageCompany.ImgDesc2 = description;
                        imageCompany.ImgDescEng2 = descriptionEng;
                        imageCompany.ImgPrint2 = print;
                    }
                    else if (number == 3)
                    {
                        imageCompany.Img3 = base64;
                        imageCompany.ImgDesc3 = description;
                        imageCompany.ImgDescEng3 = descriptionEng;
                        imageCompany.ImgPrint3 = print;
                    }
                    else if (number == 4)
                    {
                        imageCompany.Img4 = base64;
                        imageCompany.ImgDesc4 = description;
                        imageCompany.ImgDescEng4 = descriptionEng;
                        imageCompany.ImgPrint4 = print;
                    }
                    await context.CompanyImages.AddAsync(imageCompany);
                    await context.SaveChangesAsync();
                    return true;
                }
            }catch(Exception ex)
            { 
                _logger.LogError(ex.Message, ex);
                return false;
            }

        }
    }
}
