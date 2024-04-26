using System.Text.Json.Serialization;

namespace DRRCore.Application.DTO.API
{
    public class RelatedCompanyDto
    {
        [JsonPropertyName("DRR_RELCOM_NAAMEE")]
        public string Name { get; set; } = string.Empty;
        
        [JsonPropertyName("DRR_RELCOM_ISOCOU")]
        public string IsoCountry { get; set; } = string.Empty;
        [JsonPropertyName("DRR_RELCOM_SITCOM")]
        public string SituationCompany { get; set; } = string.Empty;
        [JsonPropertyName("DRR_RELCOM_REGNUM")]
        public string RegistrationNumber { get;set; } = string.Empty;
        [JsonPropertyName("DRR_RELCOM_RELATI")]
        public string Relation { get; set; } = string.Empty;
        [JsonPropertyName("DRR_RELCOM_BUSACT")]
        public string BussinessActivity { get; set; } = string.Empty;

    }
}
