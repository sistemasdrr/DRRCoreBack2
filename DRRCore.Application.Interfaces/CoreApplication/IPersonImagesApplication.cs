using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Transversal.Common;
using Microsoft.AspNetCore.Http;

namespace DRRCore.Application.Interfaces.CoreApplication
{
    public interface IPersonImagesApplication
    {
        Task<Response<int?>> AddOrUpdateImages(AddOrUpdatePersonImagesRequestDto obj);
        Task<Response<GetPersonImagesResponseDto>> GetPersonImagesByIdPerson(int idPerson);
        Task<Response<bool>> UploadImage(IFormFile File);
        Task<Response<bool>> DeleteImage(int idPerson, int number);
        Task<Response<List<GetImagentDto>>> GetImageByIdPerson(int idPerson);
        Task<Response<GetImagentDto>> GetImageByPath(string path);
    }
}
