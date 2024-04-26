namespace DRRCore.Application.DTO.Core.Request
{
    public class AddOrUpdateSubscriberPriceRequestDto
    {
        public int Id { get; set; }

        public int? IdSubscriber { get; set; } 

        public string? Date { get; set; } 

        public int? IdContinent { get; set; }

        public int? IdCountry { get; set; }

        public int? IdCurrency { get; set; }

        public decimal? PriceT1 { get; set; }

        public int? DayT1 { get; set; }

        public decimal? PriceT2 { get; set; }

        public int? DayT2 { get; set; }

        public decimal? PriceT3 { get; set; }

        public int? DayT3 { get; set; }

        public int? PriceB { get; set; }
    }
}
