namespace DRRCore.Application.DTO.Core.Response
{
    public class GetEndorsementsResponseDto
    {
        public int Id { get; set; }

        public int? IdCompany { get; set; }

        public string? EndorsementName { get; set; }

        public string? Ruc { get; set; }

        public decimal? AmountUs { get; set; }

        public decimal? AmountNc { get; set; }

        public string? Date { get; set; }

        public string? ReceivingEntity { get; set; }
    }
}
