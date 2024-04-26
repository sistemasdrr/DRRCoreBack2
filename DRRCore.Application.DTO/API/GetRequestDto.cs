using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DRRCore.Application.DTO.API
{
    public class GetRequestDto
    {

        [JsonPropertyName("DRR_REQCLI")]
        [JsonPropertyOrder(0)]
        public RequestClientDto RequestClient { get; set; } = new RequestClientDto();
        [JsonPropertyName("DRR_CODEID")]
        [MaxLength(17)]
        [JsonPropertyOrder(1)]
        public string Code { get; set; }=string.Empty;
        [JsonPropertyName("DRR_LANGUA")]
        [MaxLength(3)]
        [JsonPropertyOrder(2)]
        public string Language { get; set; }=string.Empty;
        [JsonPropertyName("DRR_QAINFO")]
        [MaxLength(1)]
        [JsonPropertyOrder(3)]
        public string QualityInformation { get; set; } = string.Empty;
    }
}
