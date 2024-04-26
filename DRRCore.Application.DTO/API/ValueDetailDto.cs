using System.Text.Json.Serialization;

namespace DRRCore.Application.DTO.API
{
    public class ValueDetailDto
    {
        [JsonPropertyName("DRR_VARDET_CODDEE")]
        public string Code { get; set; } = string.Empty;
        [JsonPropertyName("DRR_VARDET_DESCRI")]
        public string Description { get; set; } = string.Empty;
    }
   
}
