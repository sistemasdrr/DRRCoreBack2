namespace DRRCore.Application.DTO.Core.Response
{
    public class GetListAgentPriceResponseDto
    {
        public int Id { get; set; }
        public int IdAgente { get; set; }
        public string? Date { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public string? PriceT1 { get; set; }
        public string? PriceT2 { get; set; }
        public string? PriceT3 { get; set; }
        public string? PricePN { get; set; }
        public string? PriceBD { get; set; }
        public string? PriceRP { get; set; }
        public string? PriceCR { get; set; }
        public string? Currency { get; set; }
    }
}
