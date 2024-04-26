namespace DRRCore.Application.DTO.Core.Response
{
    public class GetListAgentResponseDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string FlagCountry { get; set; } = string.Empty;
        public bool Status{ get; set; }
    }
}
