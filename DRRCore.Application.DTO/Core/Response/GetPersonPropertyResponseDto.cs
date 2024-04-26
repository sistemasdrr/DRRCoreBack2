using DRRCore.Application.DTO.Core.Request;

namespace DRRCore.Application.DTO.Core.Response
{
    public class GetPersonPropertyResponseDto
    {
        public int Id { get; set; }

        public int? IdPerson { get; set; }

        public string? PropertiesCommentary { get; set; }

        public List<TraductionDto> Traductions { get; set; } = new List<TraductionDto>();
    }
}
