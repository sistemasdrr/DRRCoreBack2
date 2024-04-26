using System.Text.Json.Serialization;

namespace DRRCore.Application.DTO.API
{
    public class PaymentRecordsDto
    {
        [JsonPropertyName("DRR_PAYREC_PRIPRO")]
        public List<Provider> PrimaryProviders { get; set; } = new List<Provider>();
        [JsonPropertyName("DRR_PAYREC_SECPRO")]
        public List<Provider> SecondaryProviders { get; set; } = new List<Provider>();

    }
    public class Provider
    {
        [JsonPropertyName("DRR_PROVID_NAAMEE")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("DRR_PROVID_ISOCOU")]
        public string IsoCountry { get; set; } = string.Empty;
        [JsonPropertyName("DRR_PROVID_PHONEE")]
        
        public string Phone { get; set; } = string.Empty;
        [JsonPropertyName("DRR_PROVID_PRSERQ")]
        public string ProductsOrServicesRequires { get; set; } = string.Empty;
        [JsonPropertyName("DRR_PROVID_CLISIN")]
        public string ClientSince { get; set; } = string.Empty;
        [JsonPropertyName("DRR_PROVID_TERMSS")]
        public string Terms { get; set; } = string.Empty;
        [JsonPropertyName("DRR_PROVID_PERFOR")]
        public string Performance { get; set; } = string.Empty;
        [JsonPropertyName("DRR_PROVID_COMMEN")]
        public string Comments { get; set; } = string.Empty;
    }
}
