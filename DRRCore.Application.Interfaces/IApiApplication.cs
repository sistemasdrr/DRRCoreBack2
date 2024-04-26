using DRRCore.Application.DTO.API;
using DRRCore.Transversal.Common;

namespace DRRCore.Application.Interfaces
{
    public interface IApiApplication
    {
        Task<Response<SearchResponseDto>> Search(SearchRequestDto request, string environment);
        Task<Response<ReportDto>> GetDummyReportAsync(GetRequestDto request);
        Task<Response<ReportDto>> GetReportByCodeAndEnvironmentAsync(string code, string environment);

    }
}
