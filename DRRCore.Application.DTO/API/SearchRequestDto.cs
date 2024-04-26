using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DRRCore.Application.DTO.API
{
    public class SearchRequestDto
    {
        [JsonPropertyName("DRR_REQCLI")]
        [JsonRequired]
        [JsonPropertyOrder(0)]
        public string SearchText { get; set; } = string.Empty;
        [JsonPropertyName("DRR_ISOCOU")]
        [MaxLength(3)]
        [JsonPropertyOrder(1)]
        public string IsoCountry { get; set; }= string.Empty;
        [JsonPropertyName("DRR_PRIORI")]
        [MaxLength(1)]
        [JsonPropertyOrder(2)]
        public string Priority { get; set; } = string.Empty;
    }
}
