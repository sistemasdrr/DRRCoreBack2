using System.Text.Json.Serialization;

namespace DRRCore.Application.DTO.API
{
    public class ExecutiveShareholderDto
    {
        [JsonPropertyName("DRR_EXECUT_LISTEX")]
        public List<ListExecutiveShareholderDto> ListExecutives { get; set; }= new List<ListExecutiveShareholderDto>();
        [JsonPropertyName("DRR_EXECUT_PARPER")]
        public double ParticipationPercentage { get; set; }
        [JsonPropertyName("DRR_EXECUT_OTHPPE")]
        public double OtherParticipationPercentage { get; set; }
    }
    public class ListExecutiveShareholderDto
    {
        [JsonPropertyName("DRR_EXECUT_NAAMEE")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("DRR_EXECUT_TITTLE")]
        public string Title { get; set; } = string.Empty;
        [JsonPropertyName("DRR_EXECUT_SINDAT")]
        public string SinceDate { get; set; } = string.Empty;
    }
}
