using DRRCore.Application.DTO.Core.Request;

namespace DRRCore.Application.DTO.Core.Response
{
    public class GetCompanyGeneralInformationResponseDto
    {
        public int Id { get; set; }

        public int? IdCompany { get; set; }

        public string? GeneralInfo { get; set; }

        public List<TraductionDto> Traductions { get; set; } = new List<TraductionDto>();

    }
}
