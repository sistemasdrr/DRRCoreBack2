using DRRCore.Application.DTO.Core.Request;

namespace DRRCore.Application.DTO.Core.Response
{
    public class GetPersonHistoryResponseDto
    {
        public int Id { get; set; }

        public int? IdPerson { get; set; }

        public string? HistoryCommentary { get; set; }

        public List<TraductionDto> Traductions { get; set; } = new List<TraductionDto>();
    }
}
