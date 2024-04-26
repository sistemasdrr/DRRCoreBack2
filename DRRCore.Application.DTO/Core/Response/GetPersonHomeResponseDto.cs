using DRRCore.Application.DTO.Core.Request;

namespace DRRCore.Application.DTO.Core.Response
{
    public class GetPersonHomeResponseDto
    {
        public int Id { get; set; }

        public int? IdPerson { get; set; }

        public bool? OwnHome { get; set; }

        public string? Value { get; set; }

        public string? HomeCommentary { get; set; }

        public List<TraductionDto> Traductions { get; set; } = new List<TraductionDto>();

    }
}
