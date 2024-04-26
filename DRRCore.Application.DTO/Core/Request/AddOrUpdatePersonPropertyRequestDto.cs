namespace DRRCore.Application.DTO.Core.Request
{
    public class AddOrUpdatePersonPropertyRequestDto
    {
        public int Id { get; set; }

        public int? IdPerson { get; set; }

        public string? PropertiesCommentary { get; set; }

        public List<TraductionDto> Traductions { get; set; } = new List<TraductionDto>();
    }
}
