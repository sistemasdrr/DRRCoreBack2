namespace DRRCore.Application.DTO.Core.Response
{
    public class GetListWorkersHistoryResponseDto
    {
        public int Id { get; set; }

        public int? IdCompany { get; set; }

        public int? NumberWorker { get; set; }

        public int? NumberYear { get; set; }
        public string? Observations { get; set; }
    }
}
