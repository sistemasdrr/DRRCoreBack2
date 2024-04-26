namespace DRRCore.Application.DTO.Core.Request
{
    public class AddOrUpdatePersonHistoryRequestDto
    {
        public int Id { get; set; }

        public int? IdPerson { get; set; }

        public string? HistoryCommentary { get; set; }

        public List<TraductionDto> Traductions { get; set; } = new List<TraductionDto>();
    }
}
