using System;
using System.Text.Json.Serialization;

namespace DRRCore.Application.DTO.API
{
    public class RequestClientDto
    {
        [JsonPropertyName("DRR_REQCLI_REQDAT")]
        public string RequestDate { get;set; }=string.Empty;    
     
        [JsonPropertyName("DRR_REQCLI_PRIORI")]
        public string Priority { get; set; }=string.Empty;
        [JsonPropertyName("DRR_REQCLI_REQUES")]
        public string Request { get; set; }=string.Empty;
        [JsonPropertyName("DRR_REQCLI_ENVIRO")]
        public string Environment { get; set; } = string.Empty;
    }
}
