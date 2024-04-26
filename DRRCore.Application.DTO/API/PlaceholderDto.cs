using System.Text.Json.Serialization;

namespace DRRCore.Application.DTO.API
{
    public class PlaceholderDto
    {
        [JsonPropertyName("DRR_PLAHOL_NAAMEE")]
        public string Name { get; set; }= string.Empty;
        [JsonPropertyName("DRR_PLAHOL_RELATI")]
        public string Relation { get; set; }=string.Empty;
        [JsonPropertyName("DRR_PLAHOL_ISOCOU")]
        public string IsoCountry { get; set; } = string.Empty;
    }
}
