namespace DRRCore.Application.DTO.Core.Request
{
    public class SendTicketQueryRequestDto
    {
        public int IdTicket { get; set; }
        public string QueryDate { get; set; } = string.Empty;
        public int? IdSubscriber { get; set; }
        public string Language { get; set; } = null!;
        public string? Email { get; set; }
        public string? Message { get; set; }
        public int Status { get; set; }
        public string User { get; set; }

    }
}
