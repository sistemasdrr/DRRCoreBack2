namespace DRRCore.Application.DTO.Core.Request
{
    public class AddOrUpdateAgentPriceRequestDto
    {
        public int Id { get; set; }
        public int? IdAgent { get; set; }
        public string? Date{ get; set; }
        public int? IdContinent { get; set; }
        public int? IdCountry { get; set; }
        public int? IdCurrency { get; set; }
        public int PriceT1 { get; set; }
        public int DayT1 { get; set; }
        public int PriceT2 { get; set; }
        public int DayT2 { get; set; }
        public int PriceT3 { get; set; }
        public int DayT3 { get; set; }
        public int PricePN { get; set; }
        public int DayPN { get; set; }
        public int PriceBD { get; set; }
        public int DayBD { get; set; }
        public int PriceRP { get; set; }
        public int DayRP { get; set; }
        public int PriceCR { get; set; }
        public int DayCR { get; set; }
    }
}
