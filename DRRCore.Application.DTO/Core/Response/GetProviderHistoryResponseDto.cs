namespace DRRCore.Application.DTO.Core.Response
{
    public class GetProviderHistoryResponseDto
    {
        public int? IdTicket { get; set; }
        public string? Ticket { get; set; }
        public int? NumReferences { get; set; }
        public string? ReferentName { get; set; }
        public string? Date { get; set; }
    }
}
