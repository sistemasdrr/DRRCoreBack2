using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Transversal.Common;
using Microsoft.AspNetCore.Http;

namespace DRRCore.Application.Interfaces.CoreApplication
{
    public interface ICompanyImagesApplication
    {
        Task<Response<int?>> AddOrUpdateImages(AddOrUpdateCompanyImagesRequestDto obj); 
        Task<Response<GetCompanyImageResponseDto>> GetCompanyImagesByIdCompany(int idCompany);
        Task<Response<bool>> UploadImage(IFormFile File);
        Task<Response<bool>> UpdateImageCompany(int idCompany, int number,string? description, string? descriptionEng, bool? print, IFormFile File);
        Task<Response<bool>> DeleteImage(int idCompany, int number);
        Task<Response<List<GetImagentDto>>> GetImageByIdCompany(int idCompany);
        Task<Response<GetImagentDto>> GetImageByPath(string path);
        Task<Response<string>> GetBase64eByPath(string path);
        Task<Response<GetPersonImageResponseDto>> GetPersonImgByIdPerson(int idPerson);
        Task<Response<bool>> UpdateImagePerson(int idPerson, int number, string description, string descriptionEng, bool? print, IFormFile file);
    }
}
