using System.Text.Json.Serialization;

namespace DRRCore.Application.DTO.API
{
    public class SearchResponseDto
    {
        [JsonPropertyName("DRR_REQCLI")]
        [JsonPropertyOrder(0)]
        public RequestClientDto RequestClient { get; set; }=new RequestClientDto();
        [JsonPropertyName("DRR_REPDAT")]
        [JsonPropertyOrder(1)]
        public List<ReportDataDto> Data { get; set; } =new List<ReportDataDto>();


    }
    public class ReportDataDto
    {
        [JsonPropertyName("DRR_REPDAT_COODEE")]
        [JsonPropertyOrder(0)]
        public string Code { get; set; }=string.Empty;
        [JsonPropertyName("DRR_REPDAT_BUSNAM")]
        [JsonPropertyOrder(1)]
        public string BussinessName { get; set; } = string.Empty;
        [JsonPropertyName("DRR_REPDAT_TAXIDD")]
        [JsonPropertyOrder(2)]
        public string TaxId { get; set; } = string.Empty;
        [JsonPropertyName("DRR_REPDAT_ISOCOU")]
        [JsonPropertyOrder(3)]
        public string IsoCountry { get; set; } = string.Empty;
        [JsonPropertyName("DRR_REPDAT_LASREP")]
        [JsonPropertyOrder(4)]
        public string LastReport { get; set; } = string.Empty;
        [JsonPropertyName("DRR_REPDAT_QAINFO")]
        [JsonPropertyOrder(5)]
        public List<string> QualityInformationAvailable { get; set; } = new List<string>();

    }
}
