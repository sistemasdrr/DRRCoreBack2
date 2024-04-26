namespace DRRCore.Application.DTO.Core.Request
{
    public class AddOrUpdateCompanyGeneralInformationRequestDto
    {
        public int Id { get; set; }

        public int? IdCompany { get; set; }

        public string? GeneralInfo { get; set; }
        public List<TraductionDto> Traductions { get; set; } = new List<TraductionDto>();

    }
}
