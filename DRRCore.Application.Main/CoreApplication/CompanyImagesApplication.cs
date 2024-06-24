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
    }
}
