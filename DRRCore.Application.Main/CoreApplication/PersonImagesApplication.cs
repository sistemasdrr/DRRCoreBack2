using AutoMapper;
using CoreFtp;
using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.Interfaces.CoreApplication;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;
using Microsoft.AspNetCore.Http;

namespace DRRCore.Application.Main.CoreApplication
{
    public class PersonImagesApplication : IPersonImagesApplication
    {
        private readonly IPersonImagesDomain _personImagesDomain;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public PersonImagesApplication(IPersonImagesDomain personImagesDomain, IMapper mapper, ILogger logger)
        {
            _personImagesDomain = personImagesDomain;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<int?>> AddOrUpdateImages(AddOrUpdatePersonImagesRequestDto obj)
        {
            List<Traduction> traductions = new List<Traduction>();
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
                    foreach (var item in obj.Traductions)
                    {
                        traductions.Add(new Traduction
                        {
                            Identifier = item.Key,
                            ShortValue = item.Key.Split('_')[0] == "S" ? item.Value : string.Empty,
                            LargeValue = item.Key.Split('_')[0] == "L" ? item.Value : string.Empty,
                            IdLanguage = 1,
                            LastUpdaterUser = 1
                        });
                    }
                    var newObj = _mapper.Map<PersonImage>(obj);
                    response.Data = await _personImagesDomain.AddPersonImage(newObj, traductions);
                }
                else
                {
                    var existingObj= await _personImagesDomain.GetByIdAsync((int)obj.IdPerson);
                    if (existingObj == null)
                    {
                        response.IsSuccess = false;
                        response.Message = Messages.MessageNoDataCompany;
                        _logger.LogError(response.Message);
                        return response;
                    }
                    existingObj = _mapper.Map(obj, existingObj);

                    foreach (var item in obj.Traductions)
                    {
                        traductions.Add(new Traduction
                        {
                            Identifier = item.Key,
                            ShortValue = item.Key.Split('_')[0] == "S" ? item.Value : string.Empty,
                            LargeValue = item.Key.Split('_')[0] == "L" ? item.Value : string.Empty,
                            IdLanguage = 1,
                            LastUpdaterUser = 1
                        });
                    }
                    existingObj.UpdateDate = DateTime.Now;
                    response.Data = await _personImagesDomain.UpdatePersonImage(existingObj, traductions);
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

        public Task<Response<bool>> DeleteImage(int idPerson, int number)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<GetImagentDto>>> GetImageByIdPerson(int idPerson)
        {
            var response = new Response<List<GetImagentDto>>();
            MemoryStream ms = new MemoryStream();
            try
            {
                for (var i = 0; i < 3; i++)
                {
                    ms.Position = 0;
                    string path = idPerson + "_" + (i + 1) + "_P.png";
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
        public async Task<Response<GetPersonImagesResponseDto>> GetPersonImagesByIdPerson(int idPerson)
        {
            var response = new Response<GetPersonImagesResponseDto>();
            try
            {
                var images = await _personImagesDomain.GetByIdPerson(idPerson);
                if (images == null)
                {
                    response.IsSuccess = false;
                    response.Message = Messages.MessageNoDataFound;
                    _logger.LogError(response.Message);
                    return response;
                }
                response.Data = _mapper.Map<GetPersonImagesResponseDto>(images);
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
    }
}
