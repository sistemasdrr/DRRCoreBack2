namespace DRRCore.Application.DTO.Core.Request
{
    public class AddOrUpdateAgentResponseDto
    {
        public int Id{ get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string StartDate { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telephone{ get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;
        public string Supervisor { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public int? IdCountry{ get; set; }
        public string Observations { get; set; } = string.Empty;
        public bool Status { get; set; }
        public bool SpecialCase { get; set; }
        public bool AgentSubscriber{ get; set; }
    }
}
