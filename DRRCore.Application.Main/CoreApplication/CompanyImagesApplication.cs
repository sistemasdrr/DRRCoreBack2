using AutoMapper;
using CoreFtp;

using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Domain.Interfaces.EmailDomain;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace DRRCore.Application.Main.CoreApplication
{
    public class CompanyImagesApplication : ICompanyImagesApplication
    {
        private readonly ICompanyImageDomain _companyImagesDomain;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public CompanyImagesApplication(ICompanyImageDomain companyImagesDomain, IMapper mapper, ILogger logger)
        {
            _companyImagesDomain = companyImagesDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<int?>> AddOrUpdateImages(AddOrUpdateCompanyImagesRequestDto obj)
        {
            var response = new Response<int?>();
            try
            {
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.WrongParameter;
                    _logger.LogError(response.Message);
                    return response;
                }
                if (obj.Id == 0)
                {
                    var newImages = _mapper.Map<CompanyImage>(obj);
                    response.Data = await _companyImagesDomain.AddCompanyImage(newImages);
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }

        public Task<Response<bool>> DeleteImage(int idCompany, int number)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<GetImagentDto>>> GetImageByIdCompany(int idCompany)
        {
            var response = new Response<List<GetImagentDto>>();
            MemoryStream ms = new MemoryStream();
            try
            {
                for (var i = 0; i < 3; i++)
                {
                    ms.Position = 0;
                    string path = idCompany + "_" + (i + 1) + ".png";
                    ms = await DescargarArchivo(path);
                    var imagenDto = new GetImagentDto();
                    imagenDto.File = ms;
                    imagenDto.ContentType = "image/png";
                    imagenDto.FileName = path + ".png";
                    response.Data.Add(imagenDto);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<GetCompanyImageResponseDto>> GetCompanyImagesByIdCompany(int idCompany)
        {
            var response = new Response<GetCompanyImageResponseDto>();
            try
            {
                var images = await _companyImagesDomain.GetImagesByIdCompany(idCompany);
                if (images == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetCompanyImageResponseDto>(images);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = Messages.BadQuery;
                _logger.LogError(response.Message, ex);
            }
            return response;
        }
        public async Task<Response<bool>> UploadImage(IFormFile File)
        {
            var response = new Response<bool>();
            response.Data = false;
            try
            {
                using (var ftpClient = new FtpClient(GetFtpClientConfiguration()))
                {
                    await ftpClient.LoginAsync();

                    using (var writeStream = await ftpClient.OpenFileWriteStreamAsync(File.FileName))
                    {
                        File.CopyTo(writeStream);
                    }
                }
                response.Data = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
        private async Task<MemoryStream> DescargarArchivo(string? path)
        {
            using (var ftpClient = new FtpClient(GetFtpClientConfiguration()))
            {
                await ftpClient.LoginAsync();

                using (var ftpReadStream = await ftpClient.OpenFileReadStreamAsync(path))
                {
                    using (var stream = new MemoryStream())
                    {
                        await ftpReadStream.CopyToAsync(stream);
                        return stream;
                    }
                }
            }
        }


        private FtpClientConfiguration GetFtpClientConfiguration()
        {
            return new FtpClientConfiguration
            {
                Host = "win5248.site4now.net",
                Port = 21,
                Username = "drrimagenes",
                Password = "drrti2023"
            };
        }

        public async Task<Response<GetImagentDto>> GetImageByPath(string path)
        {
            var response = new Response<GetImagentDto>();
            MemoryStream ms = new MemoryStream();
            try
            {
                ms.Position = 0;
                ms = await DescargarArchivo(path);

                var documentDto = new GetImagentDto();
                string contentType = "image/png";
                documentDto.File = ms;
                documentDto.ContentType = contentType;
                documentDto.FileName = path;
                response.Data = documentDto;

            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<string>> GetBase64eByPath(string path)
        {
            var response = new Response<string>();
            try
            {
                MemoryStream ms = await DescargarArchivo(path);

                byte[] byteArray = ms.ToArray();

                string base64String = Convert.ToBase64String(byteArray);

                response.Data = base64String;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> UpdateImageCompany(int idCompany, int number, string? description, string? descriptionEng, bool? print, IFormFile file)
        {
            var response = new Response<bool>();
            try
            {
                string base64Data = "";

                // Verificar si el archivo no es nulo y tiene contenido
                if (file != null && file.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);
                        byte[] bytes = memoryStream.ToArray();
                        base64Data = Convert.ToBase64String(bytes);
                    }
                }

                var result = await _companyImagesDomain.UpdateImageCompany(idCompany, number, base64Data, description, descriptionEng, print);
                response.Data = result; 
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<GetPersonImageResponseDto>> GetPersonImgByIdPerson(int idPerson)
        {
            var response = new Response<GetPersonImageResponseDto>();
            var data = new GetPersonImageResponseDto();
            try
            {
                using var context = new SqlCoreContext();
                var images = await context.PhotoPeople.Where(x => x.IdPerson == idPerson && x.Enable==true).ToListAsync();

                if (images != null)
                {
                    data.IdPerson = idPerson;
                    foreach (var item in images)
                    {
                        if (item.NumImg == 1)
                        {
                            data.Id1 = item.Id;
                            data.Img1 = item.Base64;
                            data.ImgDesc1 = item.Description;
                            data.ImgDescEng1= item.DescriptionEng;
                            data.ImgPrint1 = item.PrintImg;
                        }
                        if (item.NumImg == 2)
                        {
                            data.Id2 = item.Id;
                            data.Img2 = item.Base64;
                            data.ImgDesc2 = item.Description;
                            data.ImgDescEng2 = item.DescriptionEng;
                            data.ImgPrint2 = item.PrintImg;
                        }
                        if (item.NumImg == 3)
                        {
                            data.Id3 = item.Id;
                            data.Img3 = item.Base64;
                            data.ImgDesc3 = item.Description;
                            data.ImgDescEng3 = item.DescriptionEng;
                            data.ImgPrint3 = item.PrintImg;
                        }
                        if (item.NumImg == 4)
                        {
                            data.Id4 = item.Id;
                            data.Img4 = item.Base64;
                            data.ImgDesc4 = item.Description;
                            data.ImgDescEng4 = item.DescriptionEng;
                            data.ImgPrint4 = item.PrintImg;
                        }
                       
                    }
                    data.ImgPrint1 = data.Id1 == 0 ? true : data.ImgPrint1;
                    data.ImgPrint2 = data.Id2 == 0 ? true : data.ImgPrint2;
                    data.ImgPrint3 = data.Id3 == 0 ? true : data.ImgPrint3;
                    data.ImgPrint4 = data.Id4 == 0 ? true : data.ImgPrint4;
                    response.Data=data;
                   
                }
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<Response<bool>> UpdateImagePerson(int idPerson, int number, string description, string descriptionEng, bool? print, IFormFile file)
        {
            var response = new Response<bool>();
            try{
                string base64Data = "";
                using var context = new SqlCoreContext();
                // Verificar si el archivo no es nulo y tiene contenido
                if (file != null && file.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);
                        byte[] bytes = memoryStream.ToArray();
                        base64Data = Convert.ToBase64String(bytes);
                    }
                }
                var image = await context.PhotoPeople.Where(x => x.IdPerson == idPerson && x.NumImg == number).FirstOrDefaultAsync();
                if(image != null)
                {
                    image.Description = description;
                    image.DescriptionEng=descriptionEng;
                    image.Base64= base64Data;
                    image.PrintImg = print;

                    context.PhotoPeople.Update(image);
                }
                else
                {
                    context.PhotoPeople.Add(new PhotoPerson
                    {
                        Description = description,
                        DescriptionEng = descriptionEng,
                        Base64 = base64Data,
                        PrintImg = print,
                        IdPerson = idPerson,
                        NumImg = number
                    });
                }
                await context.SaveChangesAsync();
               response.Data = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.Data = false;
                response.IsSuccess = false;
            }
            return response;

        }
       
    }
}
