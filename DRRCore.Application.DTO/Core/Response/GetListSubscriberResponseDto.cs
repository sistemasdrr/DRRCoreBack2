namespace DRRCore.Application.DTO.Core.Response
{
    public class GetListSubscriberResponseDto
    {
        public int Id { get; set; } = new int();
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Acronym { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string FlagCountry { get; set; } = string.Empty;
        public string IsoCountry { get; set; } = string.Empty;
        public string FacturationType { get; set; } = string.Empty;
        public Boolean Enable { get; set; } = new bool();

    }
}
